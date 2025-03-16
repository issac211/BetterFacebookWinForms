using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Collections.ObjectModel;
using System.Threading;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private const string k_NoLikedPagesMessage = "No Liked Pages";
        private const string k_NoFriendsMessage = "No friends";
        private const string k_NoEventsMessage = "No events";
        private const string k_NoGroupsMessage = "No groups";
        private const string k_NoAlbumsMessage = "No albums";
        private const string k_NoPostsMessage = "No Posts to retrieve :(";
        private const string k_MessageText = "Message";
        private const string k_LoginFailedMessage = "Login Failed";
        private const string k_LoginText = "Login";
        private const string k_LoggedInAsText = "Logged in as";
        private const string k_LabelBirthdayTitle = "Birthday: ";
        private const string k_LabelFriendsNumberTitle = "Number of friends: ";
        private const string k_LabelGenderTitle = "Gender: ";
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private AppSettings m_AppSettings;
        private AlbumsForm m_AlbumsForm;
        private GroupsForm m_GroupsForm;
        private EventsForm m_EventsForm;
        private FriendsForm m_FriendsForm;
        private LikedPagesForm m_LikedPagesForm;
        private bool m_IsConnected = false;
        private MatchPercentage m_MatchPercentage;
        private FriendsStatistical m_FriendsStatistical;
        public event Action LogoutClicked;

        public FormMain()
        {
            InitializeComponent();
            initializeMatchPrecentage();
            initializeFriendsStatisticalData();
            FacebookService.s_CollectionLimit = 25;
            m_AppSettings = AppSettings.LoadFromFile();
        }

        private LoginResult LoginResult
        {
            get { return m_LoginResult; }
            set 
            {
                if (value == null)
                {
                    IsConnected = false;
                }
                else if (string.IsNullOrEmpty(value.ErrorMessage)
                            && !string.IsNullOrEmpty(value.AccessToken))
                {
                    IsConnected = true;
                }

                m_LoginResult = value; 
            }
        }

        private bool IsConnected
        {
            get { return m_IsConnected; }
            set { m_IsConnected = value; }
        }

        private readonly string[] r_Permissions =
        {   "email",
            "public_profile",
            "user_age_range",
            "user_birthday",
            "user_events",
            "user_friends",
            "user_gender",
            "user_hometown",
            "user_likes",
            "user_link",
            "user_location",
            "user_photos",
            "user_posts",
            "user_videos"
        };
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            connectLastUser();

            if (!IsConnected)
            {
                login();
            }

            if (IsConnected)
            {
                fetchLoggedInUser();
                saveAppSettingsData();
            }
            else
            {
                MessageBox.Show(LoginResult.ErrorMessage, k_LoginFailedMessage);
            }
        }

        private void login()
        {
            LoginResult = FacebookService.Login(
                textBoxAppID.Text,
                /// requested permissions:
                r_Permissions
                );
        }

        private void connectLastUser()
        {
            bool okToConnect = true;

            if (string.IsNullOrEmpty(m_AppSettings.LastAccessToken)
                || !m_AppSettings.RememberUser)
            {
                okToConnect = false;
            }
            else
            {
                foreach (string permission in r_Permissions)
                {
                    if (!m_AppSettings.Permissions.Contains(permission))
                    {
                        okToConnect = false;
                        break;
                    }
                }
            }

            if (okToConnect)
            {
                LoginResult = FacebookService.Connect(m_AppSettings.LastAccessToken);
            }
        }

        private void saveAppSettingsData()
        {
            if (LoginResult != null)
            {
                m_AppSettings.LastAccessToken = LoginResult.AccessToken;
                m_AppSettings.Permissions = r_Permissions;
                m_AppSettings.RememberUser = checkBoxRememberMe.Checked;
                m_AppSettings.SaveToFile();
            }
        }

        private void fetchLoggedInUser()
        {
            m_LoggedInUser = LoginResult.LoggedInUser;
            new Thread(fetchUserProfile).Start();
            checkBoxRememberMe.Checked = m_AppSettings.RememberUser;
            changeButtonsToLoginState();
            new Thread(fetchPosts).Start();
        }

        private void clearLoggedInUser()
        {
            labelGender.Text = k_LabelGenderTitle;
            labelNumberOfFriends.Text = k_LabelFriendsNumberTitle;
            labelBirthday.Text = k_LabelBirthdayTitle;
            pictureBoxUserPicture.Image = null;
            LoginResult = null;
            m_LoggedInUser = null;
            changeButtonsToLogoutState();
            postBindingSource.Clear();
            panelMatchPrecentage.Controls.Clear();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            saveAppSettingsData();
            clearLoggedInUser();
            OnLogoutClicked();
        }

        protected virtual void OnLogoutClicked()
        {
            if (LogoutClicked != null)
            {
                LogoutClicked.Invoke();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            saveAppSettingsData();
            base.OnClosed(e);
        }

        private void fetchUserProfile()
        {
            new Thread(fetchUserName).Start();
            new Thread(fetchUserGender).Start();
            new Thread(fetchUserFriendsNumber).Start();
            new Thread(fetchUserBirthday).Start();
            new Thread(fetchUserPicture).Start();
        }

        private void changeButtonsToLoginState()
        {
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
        }

        private void changeButtonsToLogoutState()
        {
            buttonLogin.Text = k_LoginText;
            buttonLogin.BackColor = buttonLogout.BackColor;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void fetchUserName()
        {
            if (!buttonLogin.InvokeRequired)
            {
                buttonLogin.Text = $"{k_LoggedInAsText} {m_LoggedInUser.Name}";
            }
            else
            {
                buttonLogin.Invoke(
                    new Action(() => buttonLogin.Text = $"{k_LoggedInAsText} {m_LoggedInUser.Name}"));
            }
        }

        private void fetchUserGender()
        {
            if (!labelGender.InvokeRequired)
            {
                labelGender.Text = k_LabelGenderTitle + m_LoggedInUser.Gender.ToString();
            }
            else
            {
                labelGender.Invoke(
                    new Action(() => labelGender.Text = k_LabelGenderTitle + m_LoggedInUser.Gender.ToString()));
            }
        }

        private void fetchUserFriendsNumber()
        {
            if (!labelNumberOfFriends.InvokeRequired)
            {
                labelNumberOfFriends.Text = k_LabelFriendsNumberTitle + m_LoggedInUser.Friends.Count().ToString();
            }
            else
            {
                labelNumberOfFriends.Invoke(
                    new Action(() => labelNumberOfFriends.Text = k_LabelFriendsNumberTitle + m_LoggedInUser.Friends.Count().ToString()));
            }
        }

        private void fetchUserBirthday()
        {
            if (!labelBirthday.InvokeRequired)
            {
                labelBirthday.Text = k_LabelBirthdayTitle + m_LoggedInUser.Birthday.ToString();
            }
            else
            {
                labelBirthday.Invoke(
                    new Action(() => labelBirthday.Text = k_LabelBirthdayTitle + m_LoggedInUser.Birthday.ToString()));
            }
        }

        private void fetchUserPicture()
        {
            if (!pictureBoxUserPicture.InvokeRequired)
            {
                pictureBoxUserPicture.ImageLocation = m_LoggedInUser.PictureNormalURL;
            }
            else
            {
                pictureBoxUserPicture.Invoke(
                    new Action(() => pictureBoxUserPicture.ImageLocation = m_LoggedInUser.PictureNormalURL));
            }
        }

        private void fetchPosts()
        {
            Collection<Post> allPosts = m_LoggedInUser.Posts;

            if (!listBoxPosts.InvokeRequired)
            {
                postBindingSource.DataSource = allPosts;
            }
            else
            {
                listBoxPosts.Invoke(new Action(() => postBindingSource.DataSource = allPosts));
            }
        }
        
        private void albumsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsConnected)
            {
                try
                {
                    if (m_LoggedInUser.Albums.Count > 0)
                    {
                        m_AlbumsForm = new AlbumsForm(m_LoggedInUser);
                        m_AlbumsForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(k_NoAlbumsMessage);
                    }
                }
                catch(Facebook.FacebookOAuthException facebookOAuthException)
                {
                    MessageBox.Show(k_NoAlbumsMessage);
                }
            }
        }

        private void groupsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsConnected)
            {
                if (m_LoggedInUser.Groups.Count > 0)
                {
                    m_GroupsForm = new GroupsForm(m_LoggedInUser);
                    m_GroupsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(k_NoGroupsMessage);
                }
            }
        }

        private void eventsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           if (IsConnected)
            {
                if (m_LoggedInUser.Events.Count > 0)
                {
                    m_EventsForm = new EventsForm(m_LoggedInUser);
                    m_EventsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(k_NoEventsMessage);
                }
            }
        }

        private void friendsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsConnected)
            {
                if (m_LoggedInUser.Friends.Count > 0)
                {
                    m_FriendsForm = new FriendsForm(m_LoggedInUser);
                    m_FriendsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(k_NoFriendsMessage);
                }
            }
        }

        private void likedPagesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsConnected)
            {
                if (m_LoggedInUser.LikedPages.Count > 0)
                {
                    m_LikedPagesForm = new LikedPagesForm(m_LoggedInUser);
                    m_LikedPagesForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(k_NoLikedPagesMessage);
                }
            }
        }

        private void initializeMatchPrecentage()
        {
            initializeComboBoxAge();
            m_MatchPercentage = new MatchPercentage();
        }

        private void initializeFriendsStatisticalData()
        {
            m_FriendsStatistical = new FriendsStatistical();
        }

        private void initializeComboBoxAge()
        {
            for (int i = 0; i <= 81; i++)
            {
                comboBoxAge.Items.Insert(i, i + 18);
            }
        }

        private void buttonShowMatchPercentage_Click(object sender, EventArgs e)
        {
            if(IsConnected)
            {
                m_MatchPercentage.User = m_LoggedInUser;
                m_MatchPercentage.GetSelectedFriends();
                m_MatchPercentage.DisplayMatchPercentage(panelMatchPrecentage);
                m_MatchPercentage.SelectedFriends.Clear();
            }
        }

        private void comboBoxAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_MatchPercentage.PreferredAge = (int)(sender as ComboBox).SelectedItem;
        }

        private void comboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_MatchPercentage.PreferredLocation = (sender as ComboBox).SelectedItem.ToString();
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_MatchPercentage.PreferredGender = (sender as ComboBox).SelectedItem.ToString();
        }

        private void buttonWhoGaveMostLikes_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                m_FriendsStatistical.User = m_LoggedInUser;
                m_FriendsStatistical.ShowMostLikesDialog();
            }
        }

        private void buttonWhoGaveLeastLikes_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                m_FriendsStatistical.User = m_LoggedInUser;
                m_FriendsStatistical.ShowLeastLikesDialog();
            }
        }

        private void buttonFriendsAndTheirNumberOfLikes_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                m_FriendsStatistical.User = m_LoggedInUser;
                m_FriendsStatistical.ShowFriendsAndNumberOfLikesDialog();
            }
        }

        private void buttonFriendsSortedByNumberOfLikes_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                m_FriendsStatistical.User = m_LoggedInUser;
                m_FriendsStatistical.ShowFriendsSortedByNumberOfLikesDialog();
            }
        }

        private void buttonFriendsByChoosingNumberOfLikes_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                m_FriendsStatistical.User = m_LoggedInUser;
                m_FriendsStatistical.ChoosingNumberOfLikes();
            }
        }

        private void buttonSearchFriends_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                m_FriendsStatistical.User = m_LoggedInUser;
                m_FriendsStatistical.SearchFriends();
            }
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxPosts.Image = null;
        }

        private void pictureURLLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBoxPosts.LoadAsync(pictureURLLinkLabel.Text);
        }

        private void linkLabelRecycleBin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsConnected)
            {
                RecycleBinForm.Instance.ShowDialog();
            }
        }
    }
}
