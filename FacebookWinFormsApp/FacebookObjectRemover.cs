using FacebookWrapper.ObjectModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class FacebookObjectRemover
    {
        public static void RemoveFacebookObjectInScrollableControl(
            ScrollableControl i_ScrollableControl, FacebookObjectButton i_FacebookObjectButton)
        {
            i_ScrollableControl.Controls.Remove(i_FacebookObjectButton.FacebookObjectPicture);
            i_ScrollableControl.Controls.Remove(i_FacebookObjectButton.FacebookObjectNameLinkLabel);
            foreach (Button button in i_FacebookObjectButton.Buttons)
            {
                i_ScrollableControl.Controls.Remove(button);
            }

            i_ScrollableControl.Controls.Remove(i_FacebookObjectButton);
            int newLocationY = GeneratedDataDisplayer.StartingLocationY;
            int heightSpaceSeperstin = GeneratedDataDisplayer.HeightSpaceSeperstin;

            foreach (Control control in i_ScrollableControl.Controls)
            {
                if (control is FacebookObjectButton && control.Text.StartsWith("Delete"))
                {
                    FacebookObjectButton facebookObjectButton = control as FacebookObjectButton;

                    facebookObjectButton.FacebookObjectPicture.Top = newLocationY;
                    facebookObjectButton.FacebookObjectNameLinkLabel.Top = newLocationY;
                    foreach (Button button in facebookObjectButton.Buttons)
                    {
                        button.Top = newLocationY;
                    }

                    facebookObjectButton.Top = newLocationY;
                    newLocationY += facebookObjectButton.FacebookObjectPicture.Size.Height + heightSpaceSeperstin;
                }
            }
        }

        internal static void RemoveFacebookObjectInCollection(Collection<IRestorableFacebookObjectBase> i_Collection, FacebookObject i_FacebookObject)
        {
            IRestorableFacebookObjectBase objectToRemove = null;

            foreach (IRestorableFacebookObjectBase restorableFacebookObject in i_Collection)
            {
                if(restorableFacebookObject.FacebookObject == i_FacebookObject)
                {
                    objectToRemove = restorableFacebookObject;
                    break;
                }
            }

            if(objectToRemove != null)
            {
                i_Collection.Remove(objectToRemove);
            }
        }
    }
}
