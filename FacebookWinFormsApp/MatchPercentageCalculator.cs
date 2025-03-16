using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class MatchPercentageCalculator
    {
        private const int k_NumberOfItemsForCalculation = 3;
        private readonly User r_User;
        private readonly Collection<User> r_Friends;
        private Dictionary<User, float> m_MatchPercentageWithFriends;
        private Dictionary<User, Collection<Page>> m_FriendsAndTheirLikedPages;
        private Dictionary<User, Collection<Group>> m_FriendsAndTheirGroups;
        private Dictionary<User, Collection<Event>> m_FriendsAndTheirEvents;

        public MatchPercentageCalculator(User i_User, Collection<User> i_Friends)
        {
            r_User = i_User;
            r_Friends = i_Friends;
            initializeMatchPercentageWithFriends();
            initializeFriendsAndTheirLikedPages();
            initializeFriendsAndTheirGroups();
            initializeFriendsAndTheirEvents();
            calculateBySamePagesLiked();
            calculateBySameGroupsMembers();
            calculateBySameEvents();
            foreach (User friend in m_MatchPercentageWithFriends.Keys.ToArray())
            {
                m_MatchPercentageWithFriends[friend] /= k_NumberOfItemsForCalculation;
            }
        }

        private void initializeMatchPercentageWithFriends()
        {
            m_MatchPercentageWithFriends = new Dictionary<User, float>();

            foreach (User friend in r_Friends)
            {
                m_MatchPercentageWithFriends.Add(friend, 0);
            }
        }

        private void initializeFriendsAndTheirLikedPages()
        {
            m_FriendsAndTheirLikedPages = new Dictionary<User, Collection<Page>>();

            foreach (User friend in r_Friends)
            {
                m_FriendsAndTheirLikedPages.Add(friend, friend.LikedPages);
            }
        }

        private void initializeFriendsAndTheirGroups()
        {
            m_FriendsAndTheirGroups = new Dictionary<User, Collection<Group>>();

            foreach (User friend in r_Friends)
            {
                m_FriendsAndTheirGroups.Add(friend, friend.Groups);
            }
        }

        private void initializeFriendsAndTheirEvents()
        {
            m_FriendsAndTheirEvents = new Dictionary<User, Collection<Event>>();

            foreach (User friend in r_Friends)
            {
                m_FriendsAndTheirEvents.Add(friend, friend.Events);
            }
        }

        public Dictionary<User, float> MatchPercentageWithFriends
        {
            get => m_MatchPercentageWithFriends;
        }

        private void calculateAndSaveMatchPercentage<T>(Collection<T> i_UserItems, Dictionary<User, Collection<T>> i_FriendsAndTheirItems)
        {
            int numberOfTotalItemsUserLiked = i_UserItems.Count;

            foreach (User friend in i_FriendsAndTheirItems.Keys.ToArray())
            {
                Collection<T> friendItems = i_FriendsAndTheirItems[friend];
                int itemsCount = 0;

                foreach (T item in i_UserItems)
                {
                    if (friendItems.Contains(item))
                    {
                        itemsCount++;
                    }
                }

                if (numberOfTotalItemsUserLiked != 0)
                {
                    float matchPercentage = itemsCount * 100 / numberOfTotalItemsUserLiked;

                    matchPercentage += m_MatchPercentageWithFriends[friend];
                    m_MatchPercentageWithFriends[friend] = matchPercentage;
                }
            }
        }

        private void calculateBySamePagesLiked()
        {
            calculateAndSaveMatchPercentage<Page>(r_User.LikedPages, m_FriendsAndTheirLikedPages);
        }

        private void calculateBySameGroupsMembers()
        {
            calculateAndSaveMatchPercentage<Group>(r_User.Groups, m_FriendsAndTheirGroups);
        }

        private void calculateBySameEvents()
        {
            calculateAndSaveMatchPercentage<Event>(r_User.Events, m_FriendsAndTheirEvents);
        }
    }
}