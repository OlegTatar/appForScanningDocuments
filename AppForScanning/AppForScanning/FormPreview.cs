using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AppForScanning.Logic;
using AppForScanning.Models;
using WIA;

namespace AppForScanning
{
    public partial class FormPreview : Form
    {
        public FormPreview()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }

        private void buttonNewScan_Click(object sender, System.EventArgs e)
        {
            if (ScanDto.Device != null)
            {
                var device = ScanDto.Device.Connect();

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
                    ScanDto.ImageFile = (ImageFile)scanResult;

                    var imageBytes = (byte[])ScanDto.ImageFile.FileData.get_BinaryData();
                    var ms = new MemoryStream(imageBytes);
                    var img = Image.FromStream(ms);

                    pictureBoxPreview.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBoxPreview.Image = img;
                }
            }
        }

        private void ProcessScanning(int resolution = 150, int width_pixel = 1250, int height_pixel = 1700, int color_mode = 1)
        {
            try
            {
                if (string.IsNullOrEmpty(ScanDto.FilePathForSaveScanDocument))
                    throw new Exception("Не указан путь сохранения документа");

                if (string.IsNullOrEmpty(textBoxFileName.Text))
                    throw new Exception("Название документа не может быть пустым");

                ScanDto.FilePathForSaveScanDocument = $@"{ScanDto.FilePathForSaveScanDocument}\{textBoxFileName.Text}.jpeg";

                if (File.Exists(ScanDto.FilePathForSaveScanDocument))
                    throw new Exception("Файл с таким именем уже существует");

                if (ScanDto.Device != null)
                {
                    var device = ScanDto.Device.Connect();

                    var scannerItem = device.Items[1];

                    Settings.SetScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, 0, 0, color_mode);

                    var dlg = new WIA.CommonDialog();

                    object scanResult = dlg.ShowTransfer(scannerItem, "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}", true);

                    if (scanResult != null)
                    {
                        ScanDto.ImageFile = (ImageFile)scanResult;
                    }
                    else
                    {
                        throw new Exception("Не удалось получить документ из сканера");
                    }
                }
            }
            catch (COMException comException)
            {
                // Convert the error code to UINT
                uint errorCode = (uint)comException.ErrorCode;

                // See the error codes
                if (errorCode == 0x80210006)
                {
                    throw new Exception("The scanner is busy or isn't ready");
                }
                else if (errorCode == 0x80210064)
                {
                    throw new Exception("The scanning process has been cancelled.");
                }
                else if (errorCode == 0x8021000C)
                {
                    throw new Exception("There is an incorrect setting on the WIA device.");
                }
                else if (errorCode == 0x80210005)
                {
                    throw new Exception("The device is offline. Make sure the device is powered on and connected to the PC.");
                }
                else if (errorCode == 0x80210001)
                {
                    throw new Exception("An unknown error has occurred with the WIA device.");
                }
            }
        }

        private void buttonScanAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessScanning(resolution: 150);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPreview_Load_1(object sender, EventArgs e)
        {
            if (ScanDto.Device != null && ScanDto.ImageFile == null && ScanDto.Image != null)
            {
                pictureBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxPreview.Image = ScanDto.Image;
            }
        }
    }
}
