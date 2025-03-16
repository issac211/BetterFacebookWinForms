using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class RestorableFacebookObject : IRestorableFacebookObjectBase
    {
        public RestorableFacebookObject(IRestoreListener i_FormListener, FacebookObject i_FacebookObject)
        {
            FacebookObject = i_FacebookObject;
            FormListener = i_FormListener;
        }

        public FacebookObject FacebookObject { get; }

        public IRestoreListener FormListener { get; }

        public string PictureSmallURL
        {
            get
            {
                string pictureSmallUrl = null;

                if (FacebookObject is Group)
                {
                    pictureSmallUrl = (FacebookObject as Group).PictureSmallURL;
                }
                else if (FacebookObject is Page)
                {
                    pictureSmallUrl = (FacebookObject as Page).PictureSmallURL;
                }
                else if (FacebookObject is Album)
                {
                    pictureSmallUrl = (FacebookObject as Album).PictureSmallURL;
                }
                else if (FacebookObject is Event)
                {
                    pictureSmallUrl = (FacebookObject as Event).PictureSmallURL;
                }
                else if (FacebookObject is User)
                {
                    pictureSmallUrl = (FacebookObject as User).PictureSmallURL;
                }

                return pictureSmallUrl;
            }
        }

        public string Name
        {
            get
            {
                string name = null;

                if (FacebookObject is Group)
                {
                    name = (FacebookObject as Group).Name;
                }
                else if (FacebookObject is Page)
                {
                    name = (FacebookObject as Page).Name;
                }
                else if (FacebookObject is Album)
                {
                    name = (FacebookObject as Album).Name;
                }
                else if (FacebookObject is Event)
                {
                    name = (FacebookObject as Event).Name;
                }
                else if (FacebookObject is User)
                {
                    name = (FacebookObject as User).Name;
                }

                return name;
            }
        }
    }
}
