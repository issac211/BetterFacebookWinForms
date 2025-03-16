using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class FriendsStatisticalData
    {
        private readonly Dictionary<User, int> r_AllFriendsAndTheirNumberOfLikes = new Dictionary<User, int>();
        private User m_User;

        public User User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
                initializeFriendsAndTheirNumberOfLikes();
                calculateAndSaveFriendsAndTheirNumberOfLikes();
            }
        }

        public Dictionary<User, int> AllFriendsAndTheirNumberOfLikes
        {
            get => r_AllFriendsAndTheirNumberOfLikes;
        }

        public Dictionary<User, int> FriendsWhoGaveTheMostLikes
        {
            get
            {
                Dictionary<User, int> friendsWhoGaveTheMostLikes = new Dictionary<User, int>();

                foreach (User friend in r_AllFriendsAndTheirNumberOfLikes.Keys.ToArray())
                {
                    if (r_AllFriendsAndTheirNumberOfLikes[friend] == r_AllFriendsAndTheirNumberOfLikes.Values.Max())
                    {
                        friendsWhoGaveTheMostLikes.Add(friend, r_AllFriendsAndTheirNumberOfLikes[friend]);
                    }
                }

                return friendsWhoGaveTheMostLikes;
            }
        }

        public Dictionary<User, int> FriendsWhoGaveTheLeastLikes
        {
            get
            {
                Dictionary<User, int> friendsWhoGaveTheLeastLikes = new Dictionary<User, int>();

                foreach (User friend in r_AllFriendsAndTheirNumberOfLikes.Keys.ToArray())
                {
                    if (r_AllFriendsAndTheirNumberOfLikes[friend] == r_AllFriendsAndTheirNumberOfLikes.Values.Min())
                    {
                        friendsWhoGaveTheLeastLikes.Add(friend, r_AllFriendsAndTheirNumberOfLikes[friend]);
                    }
                }

                return friendsWhoGaveTheLeastLikes;
            }
        }

        public Dictionary<User, int> AllFriendsSortedByNumberOfLikes
        {
            get
            {
                Dictionary<User, int> allFriendsAndTheirNumberOfLikesCopy = new Dictionary<User, int>(r_AllFriendsAndTheirNumberOfLikes);
                Dictionary<User, int> allFriendsSortedByNumberOfLikes = new Dictionary<User, int>();

                for (int i = 0; i < r_AllFriendsAndTheirNumberOfLikes.Count; i++)
                {
                    User currentFriendWithMaxLikes = allFriendsAndTheirNumberOfLikesCopy.FirstOrDefault(x => x.Value == allFriendsAndTheirNumberOfLikesCopy.Values.Max()).Key;

                    allFriendsSortedByNumberOfLikes.Add(currentFriendWithMaxLikes, allFriendsAndTheirNumberOfLikesCopy[currentFriendWithMaxLikes]);
                    allFriendsAndTheirNumberOfLikesCopy.Remove(currentFriendWithMaxLikes);
                }

                return allFriendsSortedByNumberOfLikes;
            }
        }

        private void initializeFriendsAndTheirNumberOfLikes()
        {
            if (m_User != null)
            {
                foreach (User friend in User.Friends)
                {
                    if (r_AllFriendsAndTheirNumberOfLikes.ContainsKey(friend))
                    {
                        r_AllFriendsAndTheirNumberOfLikes.Remove(friend);
                    }

                    r_AllFriendsAndTheirNumberOfLikes.Add(friend, 0);
                }
            }
        }

        private void calculateAndSaveFriendsAndTheirNumberOfLikes()
        {
            try
            {
                if (m_User != null)
                {
                    foreach (Album album in User.Albums)
                    {
                        foreach (Photo photo in album.Photos)
                        {
                            Collection<User> likedBy = photo.LikedBy;

                            foreach (User friend in likedBy)
                            {
                                r_AllFriendsAndTheirNumberOfLikes[friend]++;
                            }
                        }
                    }
                }
            }
            catch (Facebook.FacebookOAuthException facebookOAuthException) { }
        }

        public Dictionary<User, int> GetFriendsWithGreaterOrEqualNumOfLikesToUserChoice(int? i_SelectedNumberOfLikes)
        {
            Dictionary<User, int> friendsWithGreaterOrEqualNumOfLikesToUserChoice = new Dictionary<User, int>();

            foreach (User friend in r_AllFriendsAndTheirNumberOfLikes.Keys.ToArray())
            {
                if (r_AllFriendsAndTheirNumberOfLikes[friend] >= i_SelectedNumberOfLikes)
                {
                    friendsWithGreaterOrEqualNumOfLikesToUserChoice.Add(friend, r_AllFriendsAndTheirNumberOfLikes[friend]);
                }
            }

            return friendsWithGreaterOrEqualNumOfLikesToUserChoice;
        }

        public Dictionary<User, int> GetSelectedFriends(string i_FriendsName)
        {
            Dictionary<User, int> selectedFriends = new Dictionary<User, int>();

            foreach (User friend in r_AllFriendsAndTheirNumberOfLikes.Keys.ToArray())
            {
                if (friend.Name == i_FriendsName)
                {
                    selectedFriends.Add(friend, r_AllFriendsAndTheirNumberOfLikes[friend]);
                }
            }

            return selectedFriends;
        }
    }
}