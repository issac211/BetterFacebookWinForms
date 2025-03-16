namespace BasicFacebookFeatures
{
    partial class FriendsForm
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
            this.panelFriends = new System.Windows.Forms.Panel();
            this.linkLabelDeletedFriends = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // panelFriends
            // 
            this.panelFriends.AutoScroll = true;
            this.panelFriends.Location = new System.Drawing.Point(1, 2);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(797, 405);
            this.panelFriends.TabIndex = 0;
            // 
            // linkLabelDeletedFriends
            // 
            this.linkLabelDeletedFriends.AutoSize = true;
            this.linkLabelDeletedFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDeletedFriends.Location = new System.Drawing.Point(634, 416);
            this.linkLabelDeletedFriends.Name = "linkLabelDeletedFriends";
            this.linkLabelDeletedFriends.Size = new System.Drawing.Size(164, 25);
            this.linkLabelDeletedFriends.TabIndex = 76;
            this.linkLabelDeletedFriends.TabStop = true;
            this.linkLabelDeletedFriends.Text = "Deleted Friends";
            this.linkLabelDeletedFriends.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDeletedFriends_LinkClicked);
            // 
            // FriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabelDeletedFriends);
            this.Controls.Add(this.panelFriends);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FriendsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FriendsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelFriends;
        private System.Windows.Forms.LinkLabel linkLabelDeletedFriends;
    }
}