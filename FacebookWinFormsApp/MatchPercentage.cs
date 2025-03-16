using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    internal class MatchPercentage
    {
        private const string k_AnyText = "Any";
        private const string k_PercentMatchLabelDescription = "percent match";
        public Collection<User> SelectedFriends { get; } = new Collection<User>();
        public User User { get; set; } = null;
        public string PreferredGender { get; set; } = null;
        public string PreferredLocation { get; set; } = null;
        public int? PreferredAge { get; set; } = null;

        public void GetSelectedFriends()
        {
            foreach (User friend in User.Friends)
            {
                if (isPreferredCategory(friend.Gender.ToString(), PreferredGender))
                {
                    if (isPreferredCategory(friend.Location.Name, PreferredLocation))
                    {
                        DateTime friendBirthday;
                        DateTime.TryParse(friend.Birthday, out friendBirthday);

                        if (friendBirthday == null ||
                            DateTime.Now.Year - friendBirthday.Year == PreferredAge ||
                            PreferredAge == null)
                        {
                            SelectedFriends.Add(friend);
                        }
                    }
                }
            }
        }

        private bool isPreferredCategory(string i_Category, string i_PreferredCategory)
        {
            return (i_Category == null ||
                    i_Category == i_PreferredCategory ||
                    i_PreferredCategory == k_AnyText ||
                    i_PreferredCategory == null);
        }

        public void DisplayMatchPercentage(Panel i_DisplayPanel)
        {
            GeneratedDataDisplayer matchPercentageWithFriendsDisplayer = new GeneratedDataDisplayer(i_DisplayPanel);
            MatchPercentageCalculator matchPercentageCalculator = new MatchPercentageCalculator(User, SelectedFriends);
            Dictionary<User, float> matchPercentageWithFriends = matchPercentageCalculator.MatchPercentageWithFriends;

            matchPercentageWithFriendsDisplayer.DisplayUsersAndTheirLabels(matchPercentageWithFriends, k_PercentMatchLabelDescription);
        }
    }
}
