namespace ImageContentFilterPOC
{
    partial class ImageFilterPage
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BrowseFiles
            // 
            this.BrowseFiles.Location = new System.Drawing.Point(114, 561);
            this.BrowseFiles.Name = "BrowseFiles";
            this.BrowseFiles.Size = new System.Drawing.Size(121, 24);
            this.BrowseFiles.TabIndex = 0;
            this.BrowseFiles.Text = "Adult Or Racy";
            this.BrowseFiles.UseVisualStyleBackColor = true;
            this.BrowseFiles.Click += new System.EventHandler(this.AdultOrRacy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 602);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Results:";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(674, 602);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(225, 15);
            this.ResultLabel.TabIndex = 2;
            this.ResultLabel.Text = "Select an image file (.jpeg, .jpg, .png, .gif)";
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(114, 35);
            this.imageBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(1248, 522);
            this.imageBox.TabIndex = 3;
            this.imageBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 593);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Driver\'s License";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DriversLicense_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(114, 624);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 22);
            this.button3.TabIndex = 6;
            this.button3.Text = "Credit Card";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CreditCard_Click);
            // 
            // ImageFilterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 656);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseFiles);
            this.Name = "ImageFilterPage";
            this.Text = "Content Moderator POC";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BrowseFiles;
        private Label label1;
        private Label ResultLabel;
        private PictureBox imageBox;
        private Button button1;
        private Button button3;
    }
}