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
            this.AdultOrRacy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AdultScoreLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RacyScoreLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AdultScoreTextBox = new System.Windows.Forms.TextBox();
            this.RacyScoreTextBox = new System.Windows.Forms.TextBox();
            this.IsRacyLabel = new System.Windows.Forms.Label();
            this.IsAdultLabel = new System.Windows.Forms.Label();
            this.IsAdultTextBox = new System.Windows.Forms.TextBox();
            this.IsRacyTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AdultOrRacy
            // 
            this.AdultOrRacy.Location = new System.Drawing.Point(29, 564);
            this.AdultOrRacy.Name = "AdultOrRacy";
            this.AdultOrRacy.Size = new System.Drawing.Size(121, 24);
            this.AdultOrRacy.TabIndex = 0;
            this.AdultOrRacy.Text = "Adult Or Racy";
            this.AdultOrRacy.UseVisualStyleBackColor = true;
            this.AdultOrRacy.Click += new System.EventHandler(this.AdultOrRacy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 601);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Results:";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(250, 601);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(225, 15);
            this.ResultLabel.TabIndex = 2;
            this.ResultLabel.Text = "Select an image file (.jpeg, .jpg, .png, .gif)";
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(239, 85);
            this.imageBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(972, 457);
            this.imageBox.TabIndex = 3;
            this.imageBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 596);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Driver\'s License";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 627);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 22);
            this.button3.TabIndex = 6;
            this.button3.Text = "Credit Card";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AdultScoreLabel
            // 
            this.AdultScoreLabel.AutoSize = true;
            this.AdultScoreLabel.Location = new System.Drawing.Point(869, 596);
            this.AdultScoreLabel.Name = "AdultScoreLabel";
            this.AdultScoreLabel.Size = new System.Drawing.Size(71, 15);
            this.AdultScoreLabel.TabIndex = 7;
            this.AdultScoreLabel.Text = "Adult Score:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1015, 602);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(949, 596);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "0 is lowest; 1.00 is highest";
            // 
            // RacyScoreLabel
            // 
            this.RacyScoreLabel.AutoSize = true;
            this.RacyScoreLabel.Location = new System.Drawing.Point(869, 618);
            this.RacyScoreLabel.Name = "RacyScoreLabel";
            this.RacyScoreLabel.Size = new System.Drawing.Size(67, 15);
            this.RacyScoreLabel.TabIndex = 10;
            this.RacyScoreLabel.Text = "Racy Score:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(949, 618);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "0 is lowest; 1.00 is highest";
            // 
            // AdultScoreTextBox
            // 
            this.AdultScoreTextBox.Location = new System.Drawing.Point(1106, 595);
            this.AdultScoreTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.AdultScoreTextBox.Name = "AdultScoreTextBox";
            this.AdultScoreTextBox.Size = new System.Drawing.Size(105, 23);
            this.AdultScoreTextBox.TabIndex = 12;
            // 
            // RacyScoreTextBox
            // 
            this.RacyScoreTextBox.Location = new System.Drawing.Point(1106, 621);
            this.RacyScoreTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.RacyScoreTextBox.Name = "RacyScoreTextBox";
            this.RacyScoreTextBox.Size = new System.Drawing.Size(105, 23);
            this.RacyScoreTextBox.TabIndex = 13;
            // 
            // IsRacyLabel
            // 
            this.IsRacyLabel.AutoSize = true;
            this.IsRacyLabel.Location = new System.Drawing.Point(1295, 624);
            this.IsRacyLabel.Name = "IsRacyLabel";
            this.IsRacyLabel.Size = new System.Drawing.Size(46, 15);
            this.IsRacyLabel.TabIndex = 14;
            this.IsRacyLabel.Text = "Is Racy:";
            // 
            // IsAdultLabel
            // 
            this.IsAdultLabel.AutoSize = true;
            this.IsAdultLabel.Location = new System.Drawing.Point(1295, 598);
            this.IsAdultLabel.Name = "IsAdultLabel";
            this.IsAdultLabel.Size = new System.Drawing.Size(50, 15);
            this.IsAdultLabel.TabIndex = 15;
            this.IsAdultLabel.Text = "Is Adult:";
            // 
            // IsAdultTextBox
            // 
            this.IsAdultTextBox.Location = new System.Drawing.Point(1349, 595);
            this.IsAdultTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.IsAdultTextBox.Name = "IsAdultTextBox";
            this.IsAdultTextBox.Size = new System.Drawing.Size(105, 23);
            this.IsAdultTextBox.TabIndex = 16;
            // 
            // IsRacyTextBox
            // 
            this.IsRacyTextBox.Location = new System.Drawing.Point(1349, 622);
            this.IsRacyTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.IsRacyTextBox.Name = "IsRacyTextBox";
            this.IsRacyTextBox.Size = new System.Drawing.Size(105, 23);
            this.IsRacyTextBox.TabIndex = 17;
            // 
            // ImageFilterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 656);
            this.Controls.Add(this.IsRacyTextBox);
            this.Controls.Add(this.IsAdultTextBox);
            this.Controls.Add(this.IsAdultLabel);
            this.Controls.Add(this.IsRacyLabel);
            this.Controls.Add(this.RacyScoreTextBox);
            this.Controls.Add(this.AdultScoreTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RacyScoreLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AdultScoreLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdultOrRacy);
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
        private Label AdultScoreLabel;
        private Label label3;
        private Label label4;
        private Label RacyScoreLabel;
        private Label label6;
        private TextBox AdultScoreTextBox;
        private TextBox RacyScoreTextBox;
        private Label IsRacyLabel;
        private Label IsAdultLabel;
        private TextBox IsAdultTextBox;
        private TextBox IsRacyTextBox;
        private Button AdultOrRacy;
    }
}