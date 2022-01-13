
namespace AppForScanning.Forms
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
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.buttonChangePathSaveOutputDocs = new System.Windows.Forms.Button();
            this.textBoxPathSaveOutputDocs = new System.Windows.Forms.TextBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listViewScanningDocs = new System.Windows.Forms.ListView();
            this.checkBoxPreviewDialog = new System.Windows.Forms.CheckBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(708, 26);
            this.comboBoxDevices.TabIndex = 2;
            this.comboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.comboBoxDevices_SelectedIndexChanged);
            // 
            // buttonChangePathSaveOutputDocs
            // 
            this.buttonChangePathSaveOutputDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangePathSaveOutputDocs.Location = new System.Drawing.Point(565, 43);
            this.buttonChangePathSaveOutputDocs.Name = "buttonChangePathSaveOutputDocs";
            this.buttonChangePathSaveOutputDocs.Size = new System.Drawing.Size(155, 28);
            this.buttonChangePathSaveOutputDocs.TabIndex = 3;
            this.buttonChangePathSaveOutputDocs.Text = "Изменить путь";
            this.buttonChangePathSaveOutputDocs.UseVisualStyleBackColor = true;
            this.buttonChangePathSaveOutputDocs.Click += new System.EventHandler(this.buttonChangePathSaveDocs_Click);
            // 
            // textBoxPathSaveOutputDocs
            // 
            this.textBoxPathSaveOutputDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPathSaveOutputDocs.Location = new System.Drawing.Point(12, 44);
            this.textBoxPathSaveOutputDocs.Name = "textBoxPathSaveOutputDocs";
            this.textBoxPathSaveOutputDocs.ReadOnly = true;
            this.textBoxPathSaveOutputDocs.Size = new System.Drawing.Size(547, 24);
            this.textBoxPathSaveOutputDocs.TabIndex = 4;
            // 
            // buttonScan
            // 
            this.buttonScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonScan.Location = new System.Drawing.Point(565, 387);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(155, 28);
            this.buttonScan.TabIndex = 5;
            this.buttonScan.Text = "Сканировать";
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
            // listViewScanningDocs
            // 
            this.listViewScanningDocs.HideSelection = false;
            this.listViewScanningDocs.Location = new System.Drawing.Point(12, 74);
            this.listViewScanningDocs.Name = "listViewScanningDocs";
            this.listViewScanningDocs.Size = new System.Drawing.Size(708, 307);
            this.listViewScanningDocs.TabIndex = 6;
            this.listViewScanningDocs.UseCompatibleStateImageBehavior = false;
            // 
            // checkBoxPreviewDialog
            // 
            this.checkBoxPreviewDialog.AutoSize = true;
            this.checkBoxPreviewDialog.Location = new System.Drawing.Point(12, 392);
            this.checkBoxPreviewDialog.Name = "checkBoxPreviewDialog";
            this.checkBoxPreviewDialog.Size = new System.Drawing.Size(210, 21);
            this.checkBoxPreviewDialog.TabIndex = 7;
            this.checkBoxPreviewDialog.Text = "Отображать предпросмотр";
            this.checkBoxPreviewDialog.UseVisualStyleBackColor = true;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(262, 387);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(136, 28);
            this.buttonOpen.TabIndex = 8;
            this.buttonOpen.Text = "Открыть";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(406, 387);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(136, 28);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 424);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.checkBoxPreviewDialog);
            this.Controls.Add(this.listViewScanningDocs);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.textBoxPathSaveOutputDocs);
            this.Controls.Add(this.buttonChangePathSaveOutputDocs);
            this.Controls.Add(this.comboBoxDevices);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сканирование документов";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.Button buttonChangePathSaveOutputDocs;
        private System.Windows.Forms.TextBox textBoxPathSaveOutputDocs;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listViewScanningDocs;
        private System.Windows.Forms.CheckBox checkBoxPreviewDialog;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonDelete;
    }
}

