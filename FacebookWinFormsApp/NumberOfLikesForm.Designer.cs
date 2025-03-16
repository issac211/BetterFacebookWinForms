namespace BasicFacebookFeatures
{
    partial class NumberOfLikesForm
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
            this.labelNumOfLikesExplanation = new System.Windows.Forms.Label();
            this.buttonShowFriendsByNumberOfLikes = new System.Windows.Forms.Button();
            this.explanationLabel = new System.Windows.Forms.Label();
            this.labelChooseNumberOfLikes = new System.Windows.Forms.Label();
            this.textBoxNumberOfLikes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNumOfLikesExplanation
            // 
            this.labelNumOfLikesExplanation.AutoSize = true;
            this.labelNumOfLikesExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumOfLikesExplanation.Location = new System.Drawing.Point(59, 24);
            this.labelNumOfLikesExplanation.Name = "labelNumOfLikesExplanation";
            this.labelNumOfLikesExplanation.Size = new System.Drawing.Size(365, 40);
            this.labelNumOfLikesExplanation.TabIndex = 9;
            this.labelNumOfLikesExplanation.Text = "Show all your friends who gave you number of likes\r\nthat is greater or equal to y" +
    "our chosen number";
            // 
            // buttonShowFriendsByNumberOfLikes
            // 
            this.buttonShowFriendsByNumberOfLikes.AutoSize = true;
            this.buttonShowFriendsByNumberOfLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowFriendsByNumberOfLikes.Location = new System.Drawing.Point(301, 118);
            this.buttonShowFriendsByNumberOfLikes.Name = "buttonShowFriendsByNumberOfLikes";
            this.buttonShowFriendsByNumberOfLikes.Size = new System.Drawing.Size(145, 30);
            this.buttonShowFriendsByNumberOfLikes.TabIndex = 8;
            this.buttonShowFriendsByNumberOfLikes.Text = "Show your friends";
            this.buttonShowFriendsByNumberOfLikes.UseVisualStyleBackColor = true;
            this.buttonShowFriendsByNumberOfLikes.Click += new System.EventHandler(this.buttonShowFriendsByNumberOfLikes_Click);
            // 
            // explanationLabel
            // 
            this.explanationLabel.AutoSize = true;
            this.explanationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.explanationLabel.Location = new System.Drawing.Point(218, 64);
            this.explanationLabel.Name = "explanationLabel";
            this.explanationLabel.Size = new System.Drawing.Size(0, 20);
            this.explanationLabel.TabIndex = 7;
            // 
            // labelChooseNumberOfLikes
            // 
            this.labelChooseNumberOfLikes.AutoSize = true;
            this.labelChooseNumberOfLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChooseNumberOfLikes.Location = new System.Drawing.Point(12, 123);
            this.labelChooseNumberOfLikes.Name = "labelChooseNumberOfLikes";
            this.labelChooseNumberOfLikes.Size = new System.Drawing.Size(179, 20);
            this.labelChooseNumberOfLikes.TabIndex = 6;
            this.labelChooseNumberOfLikes.Text = "Choose number of likes:";
            // 
            // textBoxNumberOfLikes
            // 
            this.textBoxNumberOfLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfLikes.Location = new System.Drawing.Point(195, 120);
            this.textBoxNumberOfLikes.Name = "textBoxNumberOfLikes";
            this.textBoxNumberOfLikes.Size = new System.Drawing.Size(100, 26);
            this.textBoxNumberOfLikes.TabIndex = 5;
            // 
            // NumberOfLikesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 196);
            this.Controls.Add(this.labelNumOfLikesExplanation);
            this.Controls.Add(this.buttonShowFriendsByNumberOfLikes);
            this.Controls.Add(this.explanationLabel);
            this.Controls.Add(this.labelChooseNumberOfLikes);
            this.Controls.Add(this.textBoxNumberOfLikes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NumberOfLikesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NumberOfLikesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumOfLikesExplanation;
        private System.Windows.Forms.Button buttonShowFriendsByNumberOfLikes;
        private System.Windows.Forms.Label explanationLabel;
        private System.Windows.Forms.Label labelChooseNumberOfLikes;
        private System.Windows.Forms.TextBox textBoxNumberOfLikes;
    }
}