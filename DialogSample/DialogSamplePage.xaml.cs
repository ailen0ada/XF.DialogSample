using Xamarin.Forms;

namespace DialogSample
{
    public partial class DialogSamplePage : ContentPage
    {
        public DialogSamplePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            MessagingCenter.Send(this, "show_message", new Payload("Hello, newbie!", "May the Forms be with you..."));
        }
    }
}
