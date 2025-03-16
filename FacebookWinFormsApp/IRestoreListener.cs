using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public interface IRestoreListener
    {
        void RestoreFacebookObject(IRestorableFacebookObjectBase i_FacebookObject);
    }
}
