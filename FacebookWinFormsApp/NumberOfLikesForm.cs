using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class NumberOfLikesForm : Form
    {
        private const string k_InputsNotPositiveNumberMessage = "Your input must be a positive number!";
        private const string k_ErrorText = "Error";
        private int? m_SelectedNumberOfLikes = null;

        public NumberOfLikesForm()
        {
            InitializeComponent();
        }

        public int? SelectedNumberOfLikes
        {
            get => m_SelectedNumberOfLikes;
        }

        private void buttonShowFriendsByNumberOfLikes_Click(object sender, EventArgs e)
        {
            string strNumberOfLikes = textBoxNumberOfLikes.Text;
            int selectedNumberOfLikes;

            if (int.TryParse(strNumberOfLikes, out selectedNumberOfLikes) && selectedNumberOfLikes >= 0)
            {
                m_SelectedNumberOfLikes = selectedNumberOfLikes;
                Close();
            }
            else
            {
                MessageBox.Show(
                    k_InputsNotPositiveNumberMessage, k_ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}