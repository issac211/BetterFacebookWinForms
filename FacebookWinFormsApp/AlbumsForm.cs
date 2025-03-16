using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class AlbumsForm : Form, IRestoreListener
    {
        private AlbumPicturesForm m_AlbumPicturesForm;

        private User User { get; }
        private readonly Collection<IRestorableFacebookObjectBase> r_CurrentAlbums;
        private readonly GeneratedDataDisplayer r_AlbumsDisplayer;

        public AlbumsForm(User i_User)
        {
            InitializeComponent();
            User = i_User;
            r_AlbumsDisplayer = new GeneratedDataDisplayer(panelAlbums);
            r_CurrentAlbums = new Collection<IRestorableFacebookObjectBase>();

            foreach (Album album in User.Albums)
            {
                r_CurrentAlbums.Add(
                    new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: album));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showAlbums();
        }

        private void showAlbums()
        {
            r_AlbumsDisplayer.DisplayFacebookObjects(
                i_FacebookObjects: r_CurrentAlbums,
                i_DeleteFacebookObjectButtonClickEvent: deleteFacebookObjectButton_Click,
                i_NameLinkLabelClickEvent: albumNameLinkLabel_Click);
        }

        private void albumNameLinkLabel_Click(object sender, EventArgs e)
        {
            string albumName = (sender as LinkLabel).Text;

            foreach (Album album in User.Albums)
            {
                if (album.Name == albumName)
                {
                    m_AlbumPicturesForm = new AlbumPicturesForm(album);
                    m_AlbumPicturesForm.ShowDialog();
                    break;
                }
            }
        }

        private void deleteFacebookObjectButton_Click(object sender, EventArgs e)
        {
            FacebookObjectButton button = sender as FacebookObjectButton;

            User.Albums.Remove(button.FacebookObject as Album);
            FacebookObjectRemover.RemoveFacebookObjectInCollection(i_Collection: r_CurrentAlbums, i_FacebookObject: button.FacebookObject);
            FacebookObjectRemover.RemoveFacebookObjectInScrollableControl(i_ScrollableControl: panelAlbums, i_FacebookObjectButton: button);
            RecycleBinForm.Instance.AddRestorableFacebookObject(new RestorableFacebookObject(i_FormListener: this, i_FacebookObject: button.FacebookObject));
        }

        void IRestoreListener.RestoreFacebookObject(IRestorableFacebookObjectBase i_FacebookObject)
        {
            User.Albums.Insert(index: 0, item: i_FacebookObject.FacebookObject as Album);
            r_CurrentAlbums.Insert(index: 0, item: i_FacebookObject);
        }
    }
}