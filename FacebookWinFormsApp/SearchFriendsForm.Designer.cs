namespace BasicFacebookFeatures
{
    partial class SearchFriendsForm
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
            this.buttonShowFriends = new System.Windows.Forms.Button();
            this.labelSearchFriendExplanation = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearchFriends = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonShowFriends
            // 
            this.buttonShowFriends.AutoSize = true;
            this.buttonShowFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowFriends.Location = new System.Drawing.Point(538, 210);
            this.buttonShowFriends.Name = "buttonShowFriends";
            this.buttonShowFriends.Size = new System.Drawing.Size(75, 30);
            this.buttonShowFriends.TabIndex = 7;
            this.buttonShowFriends.Text = "Show";
            this.buttonShowFriends.UseVisualStyleBackColor = true;
            this.buttonShowFriends.Click += new System.EventHandler(this.buttonShowFriends_Click);
            // 
            // labelSearchFriendExplanation
            // 
            this.labelSearchFriendExplanation.AutoSize = true;
            this.labelSearchFriendExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchFriendExplanation.Location = new System.Drawing.Point(203, 148);
            this.labelSearchFriendExplanation.Name = "labelSearchFriendExplanation";
            this.labelSearchFriendExplanation.Size = new System.Drawing.Size(405, 20);
            this.labelSearchFriendExplanation.TabIndex = 6;
            this.labelSearchFriendExplanation.Text = "Search your friends to see how many likes they gave you";
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch.Location = new System.Drawing.Point(137, 212);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(64, 20);
            this.labelSearch.TabIndex = 5;
            this.labelSearch.Text = "Search:";
            // 
            // textBoxSearchFriends
            // 
            this.textBoxSearchFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchFriends.Location = new System.Drawing.Point(207, 212);
            this.textBoxSearchFriends.Name = "textBoxSearchFriends";
            this.textBoxSearchFriends.Size = new System.Drawing.Size(325, 26);
            this.textBoxSearchFriends.TabIndex = 4;
            // 
            // SearchFriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonShowFriends);
            this.Controls.Add(this.labelSearchFriendExplanation);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.textBoxSearchFriends);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchFriendsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchFriendsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShowFriends;
        private System.Windows.Forms.Label labelSearchFriendExplanation;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearchFriends;
    }
}