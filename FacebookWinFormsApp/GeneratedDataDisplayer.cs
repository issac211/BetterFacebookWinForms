using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class GeneratedDataDisplayer
    {
        private const int k_WidthSpaceSeperstin = 50;
        private const int k_HeightSpaceSeperstin = 50;
        private const int k_StartingLocationX = 10;
        private const int k_StartingLocationY = 10;
        private const int k_PictureSize = 100;
        private const int k_FontSize = 12;
        private const string k_FontFamily = "Arial";
        private const string k_NoDataMessage = "There is no data to display";
        private const string k_DeleteButtonTitleMessage = "Delete ";
        private const string k_RestoreButtonTitleMessage = "Restore ";
        private ScrollableControl DisplayControl { get; }

        public GeneratedDataDisplayer(ScrollableControl i_DisplayControl)
        {
            DisplayControl = i_DisplayControl;
        }

        public static int HeightSpaceSeperstin
        {
            get
            {
                return k_HeightSpaceSeperstin;
            }
        }

        public static int WidthSpaceSeperstin
        {
            get
            {
                return k_WidthSpaceSeperstin;
            }
        }

        public static int StartingLocationX
        {
            get
            {
                return k_StartingLocationX;
            }
        }

        public static int StartingLocationY
        {
            get
            {
                return k_StartingLocationY;
            }
        }

        public void DisplayUsersAndTheirLabels<T>(Dictionary<User, T> i_UsersAndTheirLabels,
                                                    string i_LabelsDescription = "")
        {
            int newLocationX = k_StartingLocationX;
            int newLocationY = k_StartingLocationY;

            DisplayControl.Controls.Clear();

            if (i_UsersAndTheirLabels.Count > 0)
            {
                foreach (User user in i_UsersAndTheirLabels.Keys.ToArray())
                {
                    PictureBox userPicture = new PictureBox();
                    Label userNameLabel = new Label();
                    Label userDataLabel = new Label();

                    userPicture.Location = new Point(newLocationX, newLocationY);
                    userPicture.Size = new Size(k_PictureSize, k_PictureSize);
                    userPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    userPicture.LoadAsync(user.PictureSmallURL);
                    userNameLabel.Text = user.Name;
                    userNameLabel.Font = new Font(k_FontFamily, k_FontSize);
                    userNameLabel.Location =
                        new Point(userPicture.Size.Width + k_WidthSpaceSeperstin, userPicture.Location.Y);
                    userNameLabel.AutoSize = true;
                    userDataLabel.Location =
                        new Point(userPicture.Size.Width + userNameLabel.Size.Width + k_WidthSpaceSeperstin, userPicture.Location.Y);
                    userDataLabel.Text = $"{i_UsersAndTheirLabels[user]} {i_LabelsDescription}";
                    userDataLabel.Font = new Font(k_FontFamily, k_FontSize);
                    userDataLabel.AutoSize = true;
                    DisplayControl.Controls.Add(userPicture);
                    DisplayControl.Controls.Add(userNameLabel);
                    DisplayControl.Controls.Add(userDataLabel);
                    newLocationY += userPicture.Size.Height + k_HeightSpaceSeperstin;
                }
            }
            else
            {
                Label noMatchLabel = new Label();

                noMatchLabel.Text = k_NoDataMessage;
                noMatchLabel.Font = new Font(k_FontFamily, k_FontSize + k_FontSize / 2);
                noMatchLabel.Location = new Point(newLocationX, newLocationY);
                noMatchLabel.AutoSize = true;
                DisplayControl.Controls.Add(noMatchLabel);
            }
        }

        public void DisplayFacebookObjects(
            Collection<IRestorableFacebookObjectBase> i_FacebookObjects,
            EventHandler i_RestoreFacebookObjectButtonClickEvent = null,
            EventHandler i_DeleteFacebookObjectButtonClickEvent = null,
            EventHandler i_NameLinkLabelClickEvent = null)
        {
            int newLocationX = k_StartingLocationX;
            int newLocationY = k_StartingLocationY;

            DisplayControl.Controls.Clear();

            foreach (IRestorableFacebookObjectBase facebookObject in i_FacebookObjects)
            {
                PictureBox facebookObjectPicture = new PictureBox();
                LinkLabel facebookObjectNameLinkLabel = new LinkLabel();
                FacebookObjectButton restoreFacebookObjectButton = new FacebookObjectButton();
                FacebookObjectButton deleteFacebookObjectButton = new FacebookObjectButton();

                facebookObjectNameLinkLabel.Click += i_NameLinkLabelClickEvent;
                facebookObjectPicture.Location = new Point(newLocationX, newLocationY);
                facebookObjectPicture.Size = new Size(k_PictureSize, k_PictureSize);
                facebookObjectPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                facebookObjectPicture.LoadAsync(facebookObject.PictureSmallURL);
                facebookObjectNameLinkLabel.Text = facebookObject.Name;
                facebookObjectNameLinkLabel.Font = new Font(k_FontFamily, k_FontSize);
                facebookObjectNameLinkLabel.AutoSize = true;
                facebookObjectNameLinkLabel.Location =
                    new Point(facebookObjectPicture.Size.Width + k_WidthSpaceSeperstin, facebookObjectPicture.Location.Y);
                DisplayControl.Controls.Add(facebookObjectPicture);
                DisplayControl.Controls.Add(facebookObjectNameLinkLabel);

                if (i_RestoreFacebookObjectButtonClickEvent != null)
                {
                    restoreFacebookObjectButton.Text = k_RestoreButtonTitleMessage + facebookObject.FacebookObject.GetType().Name;
                    restoreFacebookObjectButton.Font = new Font(k_FontFamily, k_FontSize);
                    restoreFacebookObjectButton.AutoSize = true;
                    restoreFacebookObjectButton.Location = new Point(
                        facebookObjectNameLinkLabel.Right + (k_WidthSpaceSeperstin / 2),
                        facebookObjectNameLinkLabel.Location.Y);
                    restoreFacebookObjectButton.FacebookObjectNameLinkLabel = facebookObjectNameLinkLabel;
                    restoreFacebookObjectButton.FacebookObjectPicture = facebookObjectPicture;
                    restoreFacebookObjectButton.FacebookObject = facebookObject.FacebookObject;
                    restoreFacebookObjectButton.Click += i_RestoreFacebookObjectButtonClickEvent;

                    if(i_DeleteFacebookObjectButtonClickEvent != null)
                    {
                        restoreFacebookObjectButton.Buttons.Add(deleteFacebookObjectButton);
                    }

                    DisplayControl.Controls.Add(restoreFacebookObjectButton);
                }

                if (i_DeleteFacebookObjectButtonClickEvent != null)
                {
                    deleteFacebookObjectButton.Text = k_DeleteButtonTitleMessage + facebookObject.FacebookObject.GetType().Name;
                    deleteFacebookObjectButton.Font = new Font(k_FontFamily, k_FontSize);
                    deleteFacebookObjectButton.AutoSize = true;
                    deleteFacebookObjectButton.FacebookObjectNameLinkLabel = facebookObjectNameLinkLabel;
                    deleteFacebookObjectButton.FacebookObjectPicture = facebookObjectPicture;
                    deleteFacebookObjectButton.FacebookObject = facebookObject.FacebookObject;
                    deleteFacebookObjectButton.Click += i_DeleteFacebookObjectButtonClickEvent;

                    if (i_RestoreFacebookObjectButtonClickEvent != null)
                    {
                        deleteFacebookObjectButton.Buttons.Add(restoreFacebookObjectButton);
                        deleteFacebookObjectButton.Location = new Point(
                            restoreFacebookObjectButton.Right + (k_WidthSpaceSeperstin / 2),
                            restoreFacebookObjectButton.Location.Y);
                    }
                    else
                    {
                        deleteFacebookObjectButton.Location = new Point(
                            facebookObjectNameLinkLabel.Right + (k_WidthSpaceSeperstin / 2),
                            facebookObjectNameLinkLabel.Location.Y);
                    }

                    DisplayControl.Controls.Add(deleteFacebookObjectButton);
                }

                newLocationY += facebookObjectPicture.Size.Height + k_HeightSpaceSeperstin;
            }
        }

        public void DisplayPhotosCollection(Collection<Photo> i_Photos)
        {
            int newLocationX = k_StartingLocationX;
            int newLocationY = k_StartingLocationY;
            int spaceSeperstin = k_WidthSpaceSeperstin / 2;

            DisplayControl.Controls.Clear();

            foreach (Photo picture in i_Photos)
            {
                PictureBox pictureBox = new PictureBox();

                pictureBox.Size = new Size(k_PictureSize, k_PictureSize);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.LoadAsync(picture.PictureAlbumURL);
                if (newLocationX + pictureBox.Size.Width >= DisplayControl.Size.Width - spaceSeperstin)
                {
                    newLocationX = k_StartingLocationX;
                    newLocationY += pictureBox.Size.Height + spaceSeperstin;
                }

                pictureBox.Location = new Point(newLocationX, newLocationY);
                newLocationX += pictureBox.Size.Width + spaceSeperstin;
                DisplayControl.Controls.Add(pictureBox);
            }

            Label pressOnThePictureLabel = new Label();

            pressOnThePictureLabel.Location =
                new Point(spaceSeperstin, newLocationY + DisplayControl.Height + spaceSeperstin * 2);
            pressOnThePictureLabel.AutoSize = true;
            pressOnThePictureLabel.Font = new Font(k_FontFamily, k_FontSize * 2);
            DisplayControl.Controls.Add(pressOnThePictureLabel);
        }
    }
}
