using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AppForScanning.Logic;
using AppForScanning.Models;
using WIA;

namespace AppForScanning
{
    public partial class FormMain : Form
    {
        private Dictionary<string, DeviceInfo> listDevicesFromSystem { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonGetScanDevices_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceManager = new DeviceManager();

                listDevicesFromSystem = new Dictionary<string, DeviceInfo>();
                var listComboBoxDeviceItems = new List<ComboBoxDeviceItem>();

                foreach (var item in deviceManager.DeviceInfos)
                {
                    if (item is DeviceInfo deviceInfo && deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                    {
                        var deviceName = deviceInfo.Properties["Name"].get_Value() as string;

                        if (!string.IsNullOrEmpty(deviceName))
                        {
                            if (!listDevicesFromSystem.ContainsKey(deviceName))
                                listDevicesFromSystem.Add(deviceName, deviceInfo);

                            if (listComboBoxDeviceItems.Any(x => x.Value == deviceName) == false)
                            {
                                listComboBoxDeviceItems.Add(new ComboBoxDeviceItem()
                                {
                                    Text = deviceName,
                                    Value = deviceName
                                });
                            }
                        }
                    }
                }

                comboBoxDevices.DisplayMember = "Text";
                comboBoxDevices.ValueMember = "Value";
                comboBoxDevices.Items.Clear();

                foreach (var deviceItem in listComboBoxDeviceItems)
                {
                    comboBoxDevices.Items.Add(deviceItem);
                }

                if (deviceManager.DeviceInfos.Count > 0)
                {
                    var commonDialog = new WIA.CommonDialog();
                    var defaultScannerDevice = commonDialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false);

                    if (defaultScannerDevice != null)
                    {
                        var defaultScannerDeviceName = defaultScannerDevice.Properties["Name"].get_Value() as string;

                        var activeComboBoxDeviceItem =
                            listComboBoxDeviceItems.FirstOrDefault(x => x.Value == defaultScannerDeviceName);

                        if (activeComboBoxDeviceItem != null)
                            comboBoxDevices.SelectedItem = activeComboBoxDeviceItem;
                    }
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

                var filesList = Directory.GetFiles(textBoxPathSaveOutputDocs.Text, "*.jpeg");

                textBox1.Text = string.Empty;

                foreach (var file in filesList)
                {
                    textBox1.Text += Path.GetFileNameWithoutExtension(file) + Environment.NewLine;
                }
            }
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDevicesFromSystem != null &&
                    listDevicesFromSystem.Count > 0 &&
                    !string.IsNullOrEmpty(textBoxPathSaveOutputDocs.Text) &&
                    comboBoxDevices.Items.Count > 0)
                {
                    var deviceName = (comboBoxDevices.SelectedItem as ComboBoxDeviceItem)?.Value;

                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        var device = listDevicesFromSystem[deviceName].Connect();

                        var scannerItem = device.Items[1];

                        int resolution = 150;
                        int width_pixel = 1250;
                        int height_pixel = 1700;
                        int color_mode = 1;

                        Settings.SetScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, 0, 0, color_mode);

                        var dlg = new WIA.CommonDialog();

                        object scanResult = dlg.ShowTransfer(scannerItem, "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}", true);

                        if (scanResult != null)
                        {
                            var ImageFile = (ImageFile)scanResult;

                            var imageBytes = (byte[])ImageFile.FileData.get_BinaryData();
                            var ms = new MemoryStream(imageBytes);
                            var img = Image.FromStream(ms);

                            ScanDto.Device = listDevicesFromSystem[deviceName];
                            ScanDto.FilePathForSaveScanDocument = textBoxPathSaveOutputDocs.Text;
                            ScanDto.Image = img;
                        }

                        if (ScanDto.Device != null)
                        {
                            var frmScanPreview = new FormPreview();

                            if (frmScanPreview.ShowDialog() == DialogResult.OK)
                            {
                                if (ScanDto.ImageFile != null && !string.IsNullOrEmpty(ScanDto.FilePathForSaveScanDocument))
                                {
                                    ScanDto.ImageFile.SaveFile(ScanDto.FilePathForSaveScanDocument);

                                    var filesList = Directory.GetFiles(textBoxPathSaveOutputDocs.Text, "*.jpeg");

                                    textBox1.Text = string.Empty;

                                    foreach (var file in filesList)
                                    {
                                        textBox1.Text += Path.GetFileNameWithoutExtension(file) + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
