﻿namespace BasicFacebookFeatures
{
    partial class RecycleBinForm
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
            this.panelRecycleBin = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelRecycleBin
            // 
            this.panelRecycleBin.AutoScroll = true;
            this.panelRecycleBin.Location = new System.Drawing.Point(1, -1);
            this.panelRecycleBin.Name = "panelRecycleBin";
            this.panelRecycleBin.Size = new System.Drawing.Size(800, 451);
            this.panelRecycleBin.TabIndex = 0;
            // 
            // RecycleBinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRecycleBin);
            this.Name = "RecycleBinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RecycleBinForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRecycleBin;
    }
}