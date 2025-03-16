using System.Windows.Forms;
using System.Collections.ObjectModel;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class FacebookObjectButton : Button
    {
        public FacebookObjectButton()
        {
            Buttons = new Collection<Button>();
        }

        public Collection<Button> Buttons { get; }

        public FacebookObject FacebookObject { get; set; }

        public LinkLabel FacebookObjectNameLinkLabel { get; set; }

        public PictureBox FacebookObjectPicture { get; set; }
    }
}