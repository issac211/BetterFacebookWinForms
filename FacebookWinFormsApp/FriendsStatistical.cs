using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class FriendsStatistical
    {
        private const string k_FriendsNotFoundMessage = "Friends with this name were not found";
        private const string k_ErrorText = "Error";
        private const string k_FriendsGaveLessKikesMessage = "All your friends gave you less likes than the number you selected";
        private User m_User;
        private FriendsStatisticalData m_FriendsStatisticalData = new FriendsStatisticalData();
        private FriendsStatisticalDataDisplayForm m_FriendsStatisticalDataDisplayForm;
        private NumberOfLikesForm m_NumberOfLikesForm;
        private SearchFriendsForm m_SearchFriendsForm;

        public User User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
                m_FriendsStatisticalData.User = value;
            }
        }

        public void ShowFriendsAndNumberOfLikesDialog()
        {
            m_FriendsStatisticalDataDisplayForm =
                new FriendsStatisticalDataDisplayForm(m_FriendsStatisticalData.AllFriendsAndTheirNumberOfLikes);
            m_FriendsStatisticalDataDisplayForm.ShowDialog();
        }

        public void ShowFriendsSortedByNumberOfLikesDialog()
        {
            m_FriendsStatisticalDataDisplayForm =
                new FriendsStatisticalDataDisplayForm(m_FriendsStatisticalData.AllFriendsSortedByNumberOfLikes);
            m_FriendsStatisticalDataDisplayForm.ShowDialog();
        }

        public void ShowLeastLikesDialog()
        {
            m_FriendsStatisticalDataDisplayForm =
                new FriendsStatisticalDataDisplayForm(m_FriendsStatisticalData.FriendsWhoGaveTheLeastLikes);
            m_FriendsStatisticalDataDisplayForm.ShowDialog();
        }

        public void ShowMostLikesDialog()
        {
            m_FriendsStatisticalDataDisplayForm =
                new FriendsStatisticalDataDisplayForm(m_FriendsStatisticalData.FriendsWhoGaveTheMostLikes);
            m_FriendsStatisticalDataDisplayForm.ShowDialog();
        }

        public void ChoosingNumberOfLikes()
        {
            Dictionary<User, int> friendsWithGreaterOrEqualNumOfLikes;

            m_NumberOfLikesForm = new NumberOfLikesForm();
            m_NumberOfLikesForm.ShowDialog();

            if (m_NumberOfLikesForm.SelectedNumberOfLikes != null)
            {
                friendsWithGreaterOrEqualNumOfLikes =
                    m_FriendsStatisticalData.GetFriendsWithGreaterOrEqualNumOfLikesToUserChoice(m_NumberOfLikesForm.SelectedNumberOfLikes);
                
                if (friendsWithGreaterOrEqualNumOfLikes.Count > 0)
                {
                    m_FriendsStatisticalDataDisplayForm =
                        new FriendsStatisticalDataDisplayForm(friendsWithGreaterOrEqualNumOfLikes);
                    m_FriendsStatisticalDataDisplayForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(k_FriendsGaveLessKikesMessage);
                }
            }
        }

        public void SearchFriends()
        {
            Dictionary<User, int> selectedFriends;

            m_SearchFriendsForm = new SearchFriendsForm();
            m_SearchFriendsForm.ShowDialog();

            if (m_SearchFriendsForm.SelectedFriendsName != null)
            {
                selectedFriends =
                    m_FriendsStatisticalData.GetSelectedFriends(m_SearchFriendsForm.SelectedFriendsName);

                if (selectedFriends.Count > 0)
                {
                    m_FriendsStatisticalDataDisplayForm =
                        new FriendsStatisticalDataDisplayForm(selectedFriends);
                    m_FriendsStatisticalDataDisplayForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        k_FriendsNotFoundMessage, k_ErrorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
