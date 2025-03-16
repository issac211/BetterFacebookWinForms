using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Collections;

namespace BasicFacebookFeatures
{
    public sealed partial class RecycleBinForm : Form, IEnumerable<IRestorableFacebookObjectBase>
    {
        private static readonly object sr_CreationalLockContext = new object();
        private static RecycleBinForm s_Instance = null;
        private readonly Collection<IRestorableFacebookObjectBase> r_DeletedFacebookObjects;
        private readonly GeneratedDataDisplayer r_RecycleBinDisplayer;

        private RecycleBinForm()
        {
            InitializeComponent();
            r_DeletedFacebookObjects = new Collection<IRestorableFacebookObjectBase>();
            r_RecycleBinDisplayer = new GeneratedDataDisplayer(panelRecycleBin);
        }

        public static RecycleBinForm Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_CreationalLockContext)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new RecycleBinForm();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public void AddFormMainLogoutEvent(FormMain i_FormMain)
        {
            i_FormMain.LogoutClicked += formMain_LogoutClicked;
        }

        private void formMain_LogoutClicked()
        {
            resetRecycleBin();
        }

        private void resetRecycleBin()
        {
            r_DeletedFacebookObjects.Clear();
            panelRecycleBin.Controls.Clear();
        }

        public void AddRestorableFacebookObject(IRestorableFacebookObjectBase i_FacebookObject)
        {
            r_DeletedFacebookObjects.Add(i_FacebookObject);
            updateForm();
        }

        private void updateForm()
        {
            r_RecycleBinDisplayer.DisplayFacebookObjects(
                i_FacebookObjects: r_DeletedFacebookObjects,
                i_RestoreFacebookObjectButtonClickEvent: restoreFacebookObjectButton_Click,
                i_DeleteFacebookObjectButtonClickEvent: deleteFacebookObjectButton_Click);
        }

        private void restoreFacebookObjectButton_Click(object sender, EventArgs e)
        {
            FacebookObjectButton button = sender as FacebookObjectButton;
            IRestorableFacebookObjectBase restorableFacebookObject = findRestorableFacebookObject(button.FacebookObject);

            notifyListener(restorableFacebookObject);
            r_DeletedFacebookObjects.Remove(restorableFacebookObject);
            FacebookObjectRemover.RemoveFacebookObjectInScrollableControl(
                i_ScrollableControl: panelRecycleBin, i_FacebookObjectButton: button);
        }

        private void notifyListener(IRestorableFacebookObjectBase i_FacebookObject)
        {
            i_FacebookObject.FormListener.RestoreFacebookObject(i_FacebookObject);
        }

        private void deleteFacebookObjectButton_Click(object sender, EventArgs e)
        {
            FacebookObjectButton button = sender as FacebookObjectButton;
            IRestorableFacebookObjectBase restorableFacebookObject = findRestorableFacebookObject(button.FacebookObject);

            r_DeletedFacebookObjects.Remove(restorableFacebookObject);
            FacebookObjectRemover.RemoveFacebookObjectInScrollableControl(
                i_ScrollableControl: panelRecycleBin, i_FacebookObjectButton: button);
        }

        private IRestorableFacebookObjectBase findRestorableFacebookObject(FacebookObject i_FacebookObject)
        {
            IRestorableFacebookObjectBase restorableFacebookObject = null;

            foreach (IRestorableFacebookObjectBase currentFacebookObject in r_DeletedFacebookObjects)
            {
                if (currentFacebookObject.FacebookObject == i_FacebookObject)
                {
                    restorableFacebookObject = currentFacebookObject;
                    break;
                }
            }

            return restorableFacebookObject;
        }

        public IEnumerator<IRestorableFacebookObjectBase> GetEnumerator()
        {
            return r_DeletedFacebookObjects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return r_DeletedFacebookObjects.GetEnumerator();
        }
    }
}
