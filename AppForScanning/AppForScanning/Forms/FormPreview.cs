using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AppForScanning.Domain.Common;
using AppForScanning.Domain.Models;

namespace AppForScanning.Forms
{
    public partial class FormPreview : Form
    {
        public Scanner Scanner { get; private set; }

        public FormPreview(Scanner scanner)
        {
            Scanner = scanner;

            InitializeComponent();
        }

        private void ScanPreviewLoad()
        {
            if (Scanner != null && Scanner.ImageFile != null)
            {
                var imageBytes = (byte[])Scanner.ImageFile.FileData.get_BinaryData();
                var ms = new MemoryStream(imageBytes);
                Scanner.Image = Image.FromStream(ms);

                pictureBoxPreview.SizeMode = PictureBoxSizeMode.Normal;
                pictureBoxPreview.Image = new Bitmap(Scanner.Image, new Size(pictureBoxPreview.Width, pictureBoxPreview.Height));
            }
            else
            {
                MessageBox.Show("Не удалось загрузить предварительный просмотр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckFileName()
        {
            if (Scanner == null || string.IsNullOrEmpty(Scanner.FilePathForSaveScanDocument))
                throw new Exception("Не удалось получить путь для сохранения документов");

            if (string.IsNullOrEmpty(textBoxFileName.Text))
                throw new Exception("Имя файла не может быть пустым");

            if (File.Exists(Scanner.FilePathForSaveScanDocument + @"\" + textBoxFileName.Text))
                throw new Exception("Файл с таким именем уже сущестувует!");

            Scanner.FilePathForSaveScanDocument += @"\" + textBoxFileName.Text + ".jpeg";
        }

        private void FormPreview_Load(object sender, EventArgs e)
        {
            ScanPreviewLoad();

            textBoxFileName.Text = $@"Page_{Guid.NewGuid()}";
        }

        private void buttonNewScan_Click(object sender, EventArgs e)
        {
            if (Scanner != null)
            {
                Scanner.ImageFile = new ScannerProcesses().GetImageFileFromScanner(Scanner);

                ScanPreviewLoad();
            }
            else
            {
                MessageBox.Show("Метод не получил объект Scanner", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonScanAccept_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFileName();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
