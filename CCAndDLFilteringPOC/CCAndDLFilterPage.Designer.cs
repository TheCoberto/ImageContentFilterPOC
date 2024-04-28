using System.Windows.Forms;

namespace ImageContentFilterPOC
{
    partial class CCAndDLFilterPage
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
            this.BrowseFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BrowseFiles
            // 
            this.BrowseFiles.Location = new System.Drawing.Point(52, 409);
            this.BrowseFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseFiles.Name = "BrowseFiles";
            this.BrowseFiles.Size = new System.Drawing.Size(139, 24);
            this.BrowseFiles.TabIndex = 0;
            this.BrowseFiles.Text = "Browse Files";
            this.BrowseFiles.UseVisualStyleBackColor = true;
            this.BrowseFiles.Click += new System.EventHandler(this.BrowseFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 414);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Passes Check:";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(372, 414);
            this.ResultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(248, 16);
            this.ResultLabel.TabIndex = 2;
            this.ResultLabel.Text = "Select an image file (.jpeg, .jpg, .png, .gif)";
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(131, 38);
            this.imageBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(403, 321);
            this.imageBox.TabIndex = 3;
            this.imageBox.TabStop = false;
            // 
            // CCAndDLFilterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 480);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseFiles);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CCAndDLFilterPage";
            this.Text = "DL & CC Moderator POC";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BrowseFiles;
        private Label label1;
        private Label ResultLabel;
        private PictureBox imageBox;
    }
}