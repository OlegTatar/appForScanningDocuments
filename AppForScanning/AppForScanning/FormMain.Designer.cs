
namespace AppForScanning
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonGetScanDevices = new System.Windows.Forms.Button();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.buttonChangePathSaveOutputDocs = new System.Windows.Forms.Button();
            this.textBoxPathSaveOutputDocs = new System.Windows.Forms.TextBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGetScanDevices
            // 
            this.buttonGetScanDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetScanDevices.Location = new System.Drawing.Point(12, 12);
            this.buttonGetScanDevices.Name = "buttonGetScanDevices";
            this.buttonGetScanDevices.Size = new System.Drawing.Size(193, 30);
            this.buttonGetScanDevices.TabIndex = 0;
            this.buttonGetScanDevices.Text = "Получить все сканеры";
            this.buttonGetScanDevices.UseVisualStyleBackColor = true;
            this.buttonGetScanDevices.Click += new System.EventHandler(this.buttonGetScanDevices_Click);
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(211, 12);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(509, 26);
            this.comboBoxDevices.TabIndex = 2;
            // 
            // buttonChangePathSaveOutputDocs
            // 
            this.buttonChangePathSaveOutputDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangePathSaveOutputDocs.Location = new System.Drawing.Point(12, 57);
            this.buttonChangePathSaveOutputDocs.Name = "buttonChangePathSaveOutputDocs";
            this.buttonChangePathSaveOutputDocs.Size = new System.Drawing.Size(193, 30);
            this.buttonChangePathSaveOutputDocs.TabIndex = 3;
            this.buttonChangePathSaveOutputDocs.Text = "Путь сохранения";
            this.buttonChangePathSaveOutputDocs.UseVisualStyleBackColor = true;
            this.buttonChangePathSaveOutputDocs.Click += new System.EventHandler(this.buttonChangePathSaveDocs_Click);
            // 
            // textBoxPathSaveOutputDocs
            // 
            this.textBoxPathSaveOutputDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPathSaveOutputDocs.Location = new System.Drawing.Point(211, 57);
            this.textBoxPathSaveOutputDocs.Name = "textBoxPathSaveOutputDocs";
            this.textBoxPathSaveOutputDocs.ReadOnly = true;
            this.textBoxPathSaveOutputDocs.Size = new System.Drawing.Size(509, 24);
            this.textBoxPathSaveOutputDocs.TabIndex = 4;
            // 
            // buttonScan
            // 
            this.buttonScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonScan.Location = new System.Drawing.Point(12, 127);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(193, 40);
            this.buttonScan.TabIndex = 5;
            this.buttonScan.Text = "Новое сканирование";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "scan.jpeg");
            this.imageList1.Images.SetKeyName(1, "scan.jpeg");
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(211, 127);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(509, 575);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(208, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Отсканированные файлы";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 714);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.textBoxPathSaveOutputDocs);
            this.Controls.Add(this.buttonChangePathSaveOutputDocs);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.buttonGetScanDevices);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сканирование документов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetScanDevices;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.Button buttonChangePathSaveOutputDocs;
        private System.Windows.Forms.TextBox textBoxPathSaveOutputDocs;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

