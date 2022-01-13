
namespace AppForScanning.Forms
{
    partial class FormPreview
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
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonNewScan = new System.Windows.Forms.Button();
            this.buttonScanAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFileName.Location = new System.Drawing.Point(165, 12);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(386, 24);
            this.textBoxFileName.TabIndex = 0;
            this.textBoxFileName.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название документа";
            this.label1.UseWaitCursor = true;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(15, 55);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(536, 737);
            this.pictureBoxPreview.TabIndex = 2;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.UseWaitCursor = true;
            // 
            // buttonNewScan
            // 
            this.buttonNewScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewScan.Location = new System.Drawing.Point(198, 811);
            this.buttonNewScan.Name = "buttonNewScan";
            this.buttonNewScan.Size = new System.Drawing.Size(178, 28);
            this.buttonNewScan.TabIndex = 3;
            this.buttonNewScan.Text = "Пересканировать";
            this.buttonNewScan.UseVisualStyleBackColor = true;
            this.buttonNewScan.UseWaitCursor = true;
            this.buttonNewScan.Click += new System.EventHandler(this.buttonNewScan_Click);
            // 
            // buttonScanAccept
            // 
            this.buttonScanAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonScanAccept.Location = new System.Drawing.Point(433, 811);
            this.buttonScanAccept.Name = "buttonScanAccept";
            this.buttonScanAccept.Size = new System.Drawing.Size(118, 28);
            this.buttonScanAccept.TabIndex = 4;
            this.buttonScanAccept.Text = "Сохранить";
            this.buttonScanAccept.UseVisualStyleBackColor = true;
            this.buttonScanAccept.UseWaitCursor = true;
            this.buttonScanAccept.Click += new System.EventHandler(this.buttonScanAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(16, 811);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(118, 28);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.UseWaitCursor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormPreview
            // 
            this.AcceptButton = this.buttonScanAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(563, 851);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonScanAccept);
            this.Controls.Add(this.buttonNewScan);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Предпросмотр";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.FormPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button buttonNewScan;
        private System.Windows.Forms.Button buttonScanAccept;
        private System.Windows.Forms.Button buttonCancel;
    }
}