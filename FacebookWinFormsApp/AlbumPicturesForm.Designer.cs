namespace BasicFacebookFeatures
{
    partial class AlbumPicturesForm
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
            this.panelPictures = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelPictures
            // 
            this.panelPictures.AutoScroll = true;
            this.panelPictures.Location = new System.Drawing.Point(3, 1);
            this.panelPictures.Name = "panelPictures";
            this.panelPictures.Size = new System.Drawing.Size(795, 448);
            this.panelPictures.TabIndex = 0;
            // 
            // AlbumPicturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPictures);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AlbumPicturesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlbumPicturesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPictures;
    }
}