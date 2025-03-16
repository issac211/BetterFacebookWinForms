using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class EventsForm : Form, IRestoreListener
    {
        private User User { get; }
        private readonly Collection<IRestorableFacebookObjectBase> r_CurrentEvents;
        private readonly GeneratedDataDisplayer r_EventsDisplayer;

        public EventsForm(User i_User)
        {
            InitializeComponent();
            User = i_User;
            r_EventsDisplayer = new GeneratedDataDisplayer(panelEvents);
            r_CurrentEvents = new Collection<IRestorableFacebookObjectBase>();

            foreach (Event fbEvent in User.Events)
            {
                r_CurrentEvents.Add(
                    new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: fbEvent));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showEvents();
        }

        private void showEvents()
        {
            r_EventsDisplayer.DisplayFacebookObjects(
                i_FacebookObjects: r_CurrentEvents,
                i_DeleteFacebookObjectButtonClickEvent: deleteFacebookObjectButton_Click,
                i_NameLinkLabelClickEvent: eventNameLinkLabel_Click);
        }

        private void eventNameLinkLabel_Click(object sender, EventArgs e)
        {
            string eventName = (sender as LinkLabel).Text;

            foreach (Event fbEvent in User.Events)
            {
                if (fbEvent.Name == eventName)
                {
                    MessageBox.Show(fbEvent.Description);
                    break;
                }
            }
        }

        private void deleteFacebookObjectButton_Click(object sender, EventArgs e)
        {
            FacebookObjectButton button = sender as FacebookObjectButton;

            User.Events.Remove(button.FacebookObject as Event);
            FacebookObjectRemover.RemoveFacebookObjectInCollection(i_Collection: r_CurrentEvents, i_FacebookObject: button.FacebookObject);
            FacebookObjectRemover.RemoveFacebookObjectInScrollableControl(i_ScrollableControl: panelEvents, i_FacebookObjectButton: button);
            RecycleBinForm.Instance.AddRestorableFacebookObject(new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: button.FacebookObject));
        }

        void IRestoreListener.RestoreFacebookObject(IRestorableFacebookObjectBase i_FacebookObject)
        {
            User.Events.Insert(index: 0, item: i_FacebookObject.FacebookObject as Event);
            r_CurrentEvents.Insert(index: 0, item: i_FacebookObject);
        }
    }
}