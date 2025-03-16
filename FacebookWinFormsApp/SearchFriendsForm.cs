using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class SearchFriendsForm : Form
    {
        private string m_SelectedFriendsName = null;

        public SearchFriendsForm()
        {
            InitializeComponent();
        }

        public string SelectedFriendsName
        {
            get => m_SelectedFriendsName;
        }

        private void buttonShowFriends_Click(object sender, EventArgs e)
        {
            m_SelectedFriendsName = textBoxSearchFriends.Text;
            Close();
        }
    }
}
