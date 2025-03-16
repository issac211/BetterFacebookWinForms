using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class AlbumPicturesForm : Form
    {
        private readonly Album r_Album;

        public AlbumPicturesForm(Album i_Album)
        {
            r_Album = i_Album;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showPictures();
        }

        private void showPictures()
        {
            GeneratedDataDisplayer picturesDisplayer = new GeneratedDataDisplayer(panelPictures);

            picturesDisplayer.DisplayPhotosCollection(r_Album.Photos);
        }
    }
}