namespace BasicFacebookFeatures
{
    partial class LikedPagesForm
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
            this.panelLikedPages = new System.Windows.Forms.Panel();
            this.linkLabelDeletedLikedPages = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // panelLikedPages
            // 
            this.panelLikedPages.AutoScroll = true;
            this.panelLikedPages.Location = new System.Drawing.Point(3, 3);
            this.panelLikedPages.Name = "panelLikedPages";
            this.panelLikedPages.Size = new System.Drawing.Size(797, 410);
            this.panelLikedPages.TabIndex = 0;
            // 
            // linkLabelDeletedLikedPages
            // 
            this.linkLabelDeletedLikedPages.AutoSize = true;
            this.linkLabelDeletedLikedPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDeletedLikedPages.Location = new System.Drawing.Point(589, 416);
            this.linkLabelDeletedLikedPages.Name = "linkLabelDeletedLikedPages";
            this.linkLabelDeletedLikedPages.Size = new System.Drawing.Size(211, 25);
            this.linkLabelDeletedLikedPages.TabIndex = 75;
            this.linkLabelDeletedLikedPages.TabStop = true;
            this.linkLabelDeletedLikedPages.Text = "Deleted Liked Pages";
            this.linkLabelDeletedLikedPages.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDeletedLikedPages_LinkClicked);
            // 
            // LikedPagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.linkLabelDeletedLikedPages);
            this.Controls.Add(this.panelLikedPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LikedPagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LikedPagesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLikedPages;
        private System.Windows.Forms.LinkLabel linkLabelDeletedLikedPages;
    }
}