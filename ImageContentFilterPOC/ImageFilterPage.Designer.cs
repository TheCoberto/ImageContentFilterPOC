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
            BrowseFiles = new Button();
            label1 = new Label();
            ResultLabel = new Label();
            imageBox = new PictureBox();
            button1 = new Button();
            button3 = new Button();
            AdultScoreLabel = new Label();
            label3 = new Label();
            label4 = new Label();
            RacyScoreLabel = new Label();
            label6 = new Label();
            AdultScoreTextBox = new TextBox();
            RacyScoreTextBox = new TextBox();
            IsRacyLabel = new Label();
            IsAdultLabel = new Label();
            IsAdultTextBox = new TextBox();
            IsRacyTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            SuspendLayout();
            // 
            // BrowseFiles
            // 
            BrowseFiles.Location = new Point(277, 1533);
            BrowseFiles.Margin = new Padding(7, 8, 7, 8);
            BrowseFiles.Name = "BrowseFiles";
            BrowseFiles.Size = new Size(294, 66);
            BrowseFiles.TabIndex = 0;
            BrowseFiles.Text = "Adult Or Racy";
            BrowseFiles.UseVisualStyleBackColor = true;
            BrowseFiles.Click += AdultOrRacy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(701, 1634);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 41);
            label1.TabIndex = 1;
            label1.Text = "Results:";
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(813, 1634);
            ResultLabel.Margin = new Padding(7, 0, 7, 0);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(562, 41);
            ResultLabel.TabIndex = 2;
            ResultLabel.Text = "Select an image file (.jpeg, .jpg, .png, .gif)";
            // 
            // imageBox
            // 
            imageBox.Location = new Point(277, 96);
            imageBox.Margin = new Padding(5, 3, 5, 3);
            imageBox.Name = "imageBox";
            imageBox.Size = new Size(3381, 1427);
            imageBox.TabIndex = 3;
            imageBox.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(274, 1621);
            button1.Margin = new Padding(5, 3, 5, 3);
            button1.Name = "button1";
            button1.Size = new Size(296, 66);
            button1.TabIndex = 4;
            button1.Text = "Driver's License";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DriversLicense_Click;
            // 
            // button3
            // 
            button3.Location = new Point(277, 1706);
            button3.Margin = new Padding(5, 3, 5, 3);
            button3.Name = "button3";
            button3.Size = new Size(296, 60);
            button3.TabIndex = 6;
            button3.Text = "Credit Card";
            button3.UseVisualStyleBackColor = true;
            button3.Click += CreditCard_Click;
            // 
            // AdultScoreLabel
            // 
            AdultScoreLabel.AutoSize = true;
            AdultScoreLabel.Location = new Point(1778, 1599);
            AdultScoreLabel.Margin = new Padding(7, 0, 7, 0);
            AdultScoreLabel.Name = "AdultScoreLabel";
            AdultScoreLabel.Size = new Size(178, 41);
            AdultScoreLabel.TabIndex = 7;
            AdultScoreLabel.Text = "Adult Score:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2465, 1645);
            label3.Margin = new Padding(7, 0, 7, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 41);
            label3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1972, 1599);
            label4.Margin = new Padding(7, 0, 7, 0);
            label4.Name = "label4";
            label4.Size = new Size(360, 41);
            label4.TabIndex = 9;
            label4.Text = "0 is lowest; 1.00 is highest";
            // 
            // RacyScoreLabel
            // 
            RacyScoreLabel.AutoSize = true;
            RacyScoreLabel.Location = new Point(1778, 1660);
            RacyScoreLabel.Margin = new Padding(7, 0, 7, 0);
            RacyScoreLabel.Name = "RacyScoreLabel";
            RacyScoreLabel.Size = new Size(169, 41);
            RacyScoreLabel.TabIndex = 10;
            RacyScoreLabel.Text = "Racy Score:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1972, 1660);
            label6.Margin = new Padding(7, 0, 7, 0);
            label6.Name = "label6";
            label6.Size = new Size(360, 41);
            label6.TabIndex = 11;
            label6.Text = "0 is lowest; 1.00 is highest";
            // 
            // AdultScoreTextBox
            // 
            AdultScoreTextBox.Location = new Point(2354, 1596);
            AdultScoreTextBox.Name = "AdultScoreTextBox";
            AdultScoreTextBox.Size = new Size(250, 47);
            AdultScoreTextBox.TabIndex = 12;
            // 
            // RacyScoreTextBox
            // 
            RacyScoreTextBox.Location = new Point(2354, 1667);
            RacyScoreTextBox.Name = "RacyScoreTextBox";
            RacyScoreTextBox.Size = new Size(250, 47);
            RacyScoreTextBox.TabIndex = 13;
            // 
            // IsRacyLabel
            // 
            IsRacyLabel.AutoSize = true;
            IsRacyLabel.Location = new Point(2836, 1673);
            IsRacyLabel.Margin = new Padding(7, 0, 7, 0);
            IsRacyLabel.Name = "IsRacyLabel";
            IsRacyLabel.Size = new Size(116, 41);
            IsRacyLabel.TabIndex = 14;
            IsRacyLabel.Text = "Is Racy:";
            // 
            // IsAdultLabel
            // 
            IsAdultLabel.AutoSize = true;
            IsAdultLabel.Location = new Point(2836, 1602);
            IsAdultLabel.Margin = new Padding(7, 0, 7, 0);
            IsAdultLabel.Name = "IsAdultLabel";
            IsAdultLabel.Size = new Size(125, 41);
            IsAdultLabel.TabIndex = 15;
            IsAdultLabel.Text = "Is Adult:";
            // 
            // IsAdultTextBox
            // 
            IsAdultTextBox.Location = new Point(2977, 1593);
            IsAdultTextBox.Name = "IsAdultTextBox";
            IsAdultTextBox.Size = new Size(250, 47);
            IsAdultTextBox.TabIndex = 16;
            // 
            // IsRacyTextBox
            // 
            IsRacyTextBox.Location = new Point(2977, 1667);
            IsRacyTextBox.Name = "IsRacyTextBox";
            IsRacyTextBox.Size = new Size(250, 47);
            IsRacyTextBox.TabIndex = 17;
            // 
            // ImageFilterPage
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3735, 1793);
            Controls.Add(IsRacyTextBox);
            Controls.Add(IsAdultTextBox);
            Controls.Add(IsAdultLabel);
            Controls.Add(IsRacyLabel);
            Controls.Add(RacyScoreTextBox);
            Controls.Add(AdultScoreTextBox);
            Controls.Add(label6);
            Controls.Add(RacyScoreLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(AdultScoreLabel);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(imageBox);
            Controls.Add(ResultLabel);
            Controls.Add(label1);
            Controls.Add(BrowseFiles);
            Margin = new Padding(7, 8, 7, 8);
            Name = "ImageFilterPage";
            Text = "Content Moderator POC";
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}