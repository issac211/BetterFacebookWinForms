using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public interface IRestorableFacebookObjectBase
    {
        FacebookObject FacebookObject { get; }

        IRestoreListener FormListener { get; }

        string PictureSmallURL { get; }

        string Name { get; }
    }
}
