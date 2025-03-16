using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FriendsForm : Form, IRestoreListener
    {
        private User User { get; }
        private readonly Collection<IRestorableFacebookObjectBase> r_CurrentFriends;
        private readonly GeneratedDataDisplayer r_FriendsDisplayer;
        private const string k_GoBackFriendsText = "Go Back To Friends";
        private const string k_DeletedFriendsText = "Deleted Friends";
        private const string k_FriendsFormText = "FriendsForm";

        public FriendsForm(User i_User)
        {
            InitializeComponent();
            User = i_User;
            r_FriendsDisplayer = new GeneratedDataDisplayer(panelFriends);
            r_CurrentFriends = new Collection<IRestorableFacebookObjectBase>();

            foreach (User frend in User.Friends)
            {
                r_CurrentFriends.Add(
                    new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: frend));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showFriends();
        }

        private void showFriends()
        {
            r_FriendsDisplayer.DisplayFacebookObjects(
                i_FacebookObjects: r_CurrentFriends,
                i_DeleteFacebookObjectButtonClickEvent: deleteFacebookObjectButton_Click);
        }

        private void deleteFacebookObjectButton_Click(object sender, EventArgs e)
        {
            FacebookObjectButton button = sender as FacebookObjectButton;

            User.Friends.Remove(button.FacebookObject as User);
            FacebookObjectRemover.RemoveFacebookObjectInCollection(i_Collection: r_CurrentFriends, i_FacebookObject: button.FacebookObject);
            FacebookObjectRemover.RemoveFacebookObjectInScrollableControl(i_ScrollableControl: panelFriends, i_FacebookObjectButton: button);
            RecycleBinForm.Instance.AddRestorableFacebookObject(new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: button.FacebookObject));
        }

        void IRestoreListener.RestoreFacebookObject(IRestorableFacebookObjectBase i_FacebookObject)
        {
            User.Friends.Insert(index: 0, item: i_FacebookObject.FacebookObject as User);
            r_CurrentFriends.Insert(index: 0, item: i_FacebookObject);
        }

        private void linkLabelDeletedFriends_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Text = k_DeletedFriendsText;
            linkLabelDeletedFriends.Text = k_GoBackFriendsText;
            showDeletedFriends();
            linkLabelDeletedFriends.LinkClicked -= linkLabelDeletedFriends_LinkClicked;
            linkLabelDeletedFriends.LinkClicked += linkLabelGoBackToFriends_LinkClicked;
        }

        private void linkLabelGoBackToFriends_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Text = k_FriendsFormText;
            linkLabelDeletedFriends.Text = k_DeletedFriendsText;
            showFriends();
            linkLabelDeletedFriends.LinkClicked -= linkLabelGoBackToFriends_LinkClicked;
            linkLabelDeletedFriends.LinkClicked += linkLabelDeletedFriends_LinkClicked;
        }

        private void showDeletedFriends()
        {
            Collection<IRestorableFacebookObjectBase> deletedFriends = new Collection<IRestorableFacebookObjectBase>();

            foreach (IRestorableFacebookObjectBase restorableFacebookObjectBase in RecycleBinForm.Instance)
            {
                if (restorableFacebookObjectBase.FacebookObject is User)
                {
                    deletedFriends.Add(restorableFacebookObjectBase);
                }
            }

            r_FriendsDisplayer.DisplayFacebookObjects(i_FacebookObjects: deletedFriends);
        }
    }
}