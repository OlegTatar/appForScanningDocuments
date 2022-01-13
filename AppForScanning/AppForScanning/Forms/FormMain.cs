using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AppForScanning.Domain.Common;
using AppForScanning.Domain.Models;
using WIA;

namespace AppForScanning.Forms
{
    public partial class FormMain : Form
    {
        private Dictionary<string, DeviceInfo> ListDevicesFromSystem { get; set; }

        private DeviceInfo ActiveScanner { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void ListViewUpdate()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPathSaveOutputDocs.Text))
                {
                    var listDocuments = new List<ScanDocument>();

                    listViewScanningDocs.Items.Clear();

                    var files = Directory.GetFiles(textBoxPathSaveOutputDocs.Text, "*.jpeg");

                    foreach (var filePath in files)
                    {
                        var document = new ScanDocument()
                        {
                            FileName = Path.GetFileName(filePath),
                            DateCreate = File.GetCreationTime(filePath),
                            SizeInKiloBytes = new FileInfo(filePath).Length / 1024
                        };

                        listDocuments.Add(document);
                    }

                    foreach (var scanDocument in listDocuments)
                    {
                        string[] arr = new string[4];
                        arr[1] = scanDocument.FileName;
                        arr[2] = scanDocument.DateCreate.ToShortDateString();
                        arr[3] = scanDocument.SizeInKiloBytes.ToString();

                        var itm = new ListViewItem(arr);
                        listViewScanningDocs.Items.Add(itm);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var scannerProcesses = new ScannerProcesses();

            scannerProcesses.LoadScannersFromOperationSystemDrivers(out var listScanners, out var defaultScannerName);

            ListDevicesFromSystem = listScanners;

            comboBoxDevices.DisplayMember = "Text";
            comboBoxDevices.ValueMember = "Value";
            comboBoxDevices.Items.Clear();

            var listComboBoxItems = new List<ComboBoxDeviceItem>();
            ComboBoxDeviceItem defaultComboBoxItem = null;

            foreach (var dictionaryScanner in listScanners)
            {
                listComboBoxItems.Add(new ComboBoxDeviceItem()
                {
                    Text = dictionaryScanner.Key,
                    Value = dictionaryScanner.Key
                });

                if (dictionaryScanner.Key == defaultScannerName)
                {
                    defaultComboBoxItem = new ComboBoxDeviceItem()
                    {
                        Text = dictionaryScanner.Key,
                        Value = dictionaryScanner.Key
                    };

                    ActiveScanner = dictionaryScanner.Value;
                }
            }

            comboBoxDevices.DataSource = listComboBoxItems;

            if (defaultComboBoxItem != null)
                comboBoxDevices.SelectedItem = defaultComboBoxItem;

            if (string.IsNullOrEmpty(textBoxPathSaveOutputDocs.Text))
                textBoxPathSaveOutputDocs.Text = @"C:\Users\autum\Downloads\Ouptut";

            listViewScanningDocs.View = View.Details;
            listViewScanningDocs.GridLines = true;
            listViewScanningDocs.FullRowSelect = true;
            listViewScanningDocs.CheckBoxes = true;
            listViewScanningDocs.Columns.Add(string.Empty, 30, HorizontalAlignment.Center);
            listViewScanningDocs.Columns.Add("Название", 120, HorizontalAlignment.Left);
            listViewScanningDocs.Columns.Add("Дата создания", 120, HorizontalAlignment.Left);
            listViewScanningDocs.Columns.Add("Размер, КБайт", 120, HorizontalAlignment.Right);
            listViewScanningDocs.ForeColor = System.Drawing.Color.CornflowerBlue;

            ListViewUpdate();
        }

        private void comboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ListDevicesFromSystem != null && ListDevicesFromSystem.Count > 0 &&
                    comboBoxDevices.SelectedItem is ComboBoxDeviceItem selectedItem)
                {
                    ActiveScanner = ListDevicesFromSystem[selectedItem.Value];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonChangePathSaveDocs_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxPathSaveOutputDocs.Text = folderDlg.SelectedPath;

                ListViewUpdate();
            }
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActiveScanner != null)
                {
                    var scanner = new Scanner()
                    {
                        Device = ActiveScanner.Connect(),
                        FilePathForSaveScanDocument = textBoxPathSaveOutputDocs.Text
                    };

                    scanner.ImageFile = new ScannerProcesses().GetImageFileFromScanner(scanner, 300, 2500, 3400);

                    if (scanner.ImageFile != null)
                    {
                        if (checkBoxPreviewDialog.Checked)
                        {
                            var frmPreview = new FormPreview(scanner);

                            if (frmPreview.ShowDialog() == DialogResult.OK)
                            {
                                scanner.ImageFile.SaveFile(scanner.FilePathForSaveScanDocument);
                            }
                        }
                        else
                        {
                            var fileName = $@"Page_{Guid.NewGuid()}.jpeg";
                            scanner.FilePathForSaveScanDocument += @"\" + fileName;

                            var imageBytes = (byte[])scanner.ImageFile.FileData.get_BinaryData();
                            var ms = new MemoryStream(imageBytes);
                            var imageFromStream = Image.FromStream(ms);

                            scanner.Image = new Bitmap(imageFromStream);
                            scanner.Image.Save(scanner.FilePathForSaveScanDocument);
                        }

                        ListViewUpdate();
                    }
                    else
                    {
                        throw new Exception("Метод GetImageFileFromScanner получил некорректные данные");
                    }
                }
                else
                {
                    throw new Exception("Не выбран сканер для печати");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPathSaveOutputDocs.Text) &&
                listViewScanningDocs.SelectedItems.Count > 0)
            {

                var fileName = listViewScanningDocs.SelectedItems[0].SubItems[1].Text;
                var filePath = textBoxPathSaveOutputDocs.Text + @"\" + fileName;

                Process.Start(filePath);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPathSaveOutputDocs.Text) &&
                    listViewScanningDocs.SelectedItems.Count > 0)
                {

                    var fileName = listViewScanningDocs.SelectedItems[0].SubItems[1].Text;
                    var filePath = textBoxPathSaveOutputDocs.Text + @"\" + fileName;

                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    ListViewUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
