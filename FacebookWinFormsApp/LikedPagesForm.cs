using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class LikedPagesForm : Form, IRestoreListener
    {
        private const string k_AboutText = "About";
        private const string k_GoBackLikedPagesText = "Go Back To Liked Pages";
        private const string k_DeletedLikedPagesText = "Deleted Liked Pages";
        private const string k_LikedPagesFormText = "LikedPagesForm";
        private User User { get; }
        private readonly Collection<IRestorableFacebookObjectBase> r_CurrentLikedPages;
        private readonly GeneratedDataDisplayer r_LikedPagesDisplayer;

        public LikedPagesForm(User i_User)
        {
            InitializeComponent();
            User = i_User;
            r_LikedPagesDisplayer = new GeneratedDataDisplayer(panelLikedPages);
            r_CurrentLikedPages = new Collection<IRestorableFacebookObjectBase>();

            foreach (Page likedPage in User.LikedPages)
            {
                r_CurrentLikedPages.Add(
                    new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: likedPage));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showLikedPages();
        }

        private void showLikedPages()
        {
            r_LikedPagesDisplayer.DisplayFacebookObjects(
                i_FacebookObjects: r_CurrentLikedPages,
                i_DeleteFacebookObjectButtonClickEvent: deleteFacebookObjectButton_Click,
                i_NameLinkLabelClickEvent: likedPageNameLinkLabel_Click);
        }

        private void likedPageNameLinkLabel_Click(object sender, EventArgs e)
        {
            string likedPageName = (sender as LinkLabel).Text;

            foreach (Page likedPage in User.LikedPages)
            {
                if (likedPage.Name == likedPageName)
                {
                    MessageBox.Show(likedPage.Description, k_AboutText, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
        }

        private void deleteFacebookObjectButton_Click(object sender, EventArgs e)
        {
            FacebookObjectButton button = sender as FacebookObjectButton;

            User.LikedPages.Remove(button.FacebookObject as Page);
            FacebookObjectRemover.RemoveFacebookObjectInCollection(i_Collection: r_CurrentLikedPages, i_FacebookObject: button.FacebookObject);
            FacebookObjectRemover.RemoveFacebookObjectInScrollableControl(i_ScrollableControl: panelLikedPages, i_FacebookObjectButton: button);
            RecycleBinForm.Instance.AddRestorableFacebookObject(new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: button.FacebookObject));
        }

        void IRestoreListener.RestoreFacebookObject(IRestorableFacebookObjectBase i_FacebookObject)
        {
            User.LikedPages.Insert(index: 0, item: i_FacebookObject.FacebookObject as Page);
            r_CurrentLikedPages.Insert(index: 0, item: i_FacebookObject);
        }

        private void linkLabelDeletedLikedPages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Text = k_DeletedLikedPagesText;
            linkLabelDeletedLikedPages.Text = k_GoBackLikedPagesText;
            showDeletedLikedPages();
            linkLabelDeletedLikedPages.LinkClicked -= linkLabelDeletedLikedPages_LinkClicked;
            linkLabelDeletedLikedPages.LinkClicked += linkLabelGoBackToLikedPages_LinkClicked;
        }

        private void linkLabelGoBackToLikedPages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Text = k_LikedPagesFormText;
            linkLabelDeletedLikedPages.Text = k_DeletedLikedPagesText;
            showLikedPages();
            linkLabelDeletedLikedPages.LinkClicked -= linkLabelGoBackToLikedPages_LinkClicked;
            linkLabelDeletedLikedPages.LinkClicked += linkLabelDeletedLikedPages_LinkClicked;
        }

        private void showDeletedLikedPages()
        {
            Collection<IRestorableFacebookObjectBase> deletedLikedPages = new Collection<IRestorableFacebookObjectBase>();

            foreach (IRestorableFacebookObjectBase restorableFacebookObjectBase in RecycleBinForm.Instance)
            {
                if(restorableFacebookObjectBase.FacebookObject is Page)
                {
                    deletedLikedPages.Add(restorableFacebookObjectBase);
                }
            }

            r_LikedPagesDisplayer.DisplayFacebookObjects(i_FacebookObjects: deletedLikedPages);
        }
    }
}