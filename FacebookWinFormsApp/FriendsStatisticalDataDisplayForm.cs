using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FriendsStatisticalDataDisplayForm : Form
    {
        private const string k_FriendsLikesLabelDescription = "Likes";
        private readonly Dictionary<User, int> r_FriendsAndTheirNumberOfLikes;

        public FriendsStatisticalDataDisplayForm(Dictionary<User, int>  i_FriendsAndTheirNumberOfLikes)
        {
            InitializeComponent();
            r_FriendsAndTheirNumberOfLikes = i_FriendsAndTheirNumberOfLikes;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showFriendsAndTheirNumberOfLikes();
        }

        private void showFriendsAndTheirNumberOfLikes()
        {
            GeneratedDataDisplayer friendsAndTheirNumberOfLikesDisplayer =
                new GeneratedDataDisplayer(panelFriendsStatisticalData);

            friendsAndTheirNumberOfLikesDisplayer.DisplayUsersAndTheirLabels(
                r_FriendsAndTheirNumberOfLikes, k_FriendsLikesLabelDescription);
        }
    }
}
