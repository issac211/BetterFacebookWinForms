using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class GroupsForm : Form, IRestoreListener
    {
        private const string k_AboutText = "About";
        private User User { get; }
        private readonly Collection<IRestorableFacebookObjectBase> r_CurrentGroups;
        private readonly GeneratedDataDisplayer r_GroupsDisplayer;

        public GroupsForm(User i_User)
        {
            InitializeComponent();
            User = i_User;
            r_GroupsDisplayer = new GeneratedDataDisplayer(panelGroups);
            r_CurrentGroups = new Collection<IRestorableFacebookObjectBase>();

            foreach (Group group in User.Groups)
            {
                r_CurrentGroups.Add(
                    new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: group));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showGroups();
        }

        private void showGroups()
        {
            r_GroupsDisplayer.DisplayFacebookObjects(
                i_FacebookObjects: r_CurrentGroups,
                i_DeleteFacebookObjectButtonClickEvent: deleteFacebookObjectButton_Click,
                i_NameLinkLabelClickEvent: groupNameLinkLabel_Click);
        }

        private void groupNameLinkLabel_Click(object sender, EventArgs e)
        {
            string groupName = (sender as LinkLabel).Text;

            foreach (Group group in User.Groups)
            {
                if (group.Name == groupName)
                {
                    MessageBox.Show(group.Description, k_AboutText, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
        }

        private void deleteFacebookObjectButton_Click(object sender, EventArgs e)
        {
            FacebookObjectButton button = sender as FacebookObjectButton;

            User.Groups.Remove(button.FacebookObject as Group);
            FacebookObjectRemover.RemoveFacebookObjectInCollection(i_Collection: r_CurrentGroups, i_FacebookObject: button.FacebookObject);
            FacebookObjectRemover.RemoveFacebookObjectInScrollableControl(i_ScrollableControl: panelGroups, i_FacebookObjectButton: button);
            RecycleBinForm.Instance.AddRestorableFacebookObject(new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: button.FacebookObject));
        }

        void IRestoreListener.RestoreFacebookObject(IRestorableFacebookObjectBase i_FacebookObject)
        {
            User.Groups.Insert(index: 0, item: i_FacebookObject.FacebookObject as Group);
            r_CurrentGroups.Insert(index: 0, item: i_FacebookObject);
        }
    }
}