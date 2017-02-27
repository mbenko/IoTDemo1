
using IoTDemoClient.Services;
using Xamarin.Forms;

namespace IoTDemoClient
{
    public partial class App : Application
	{
        public string mobileURL = "";
        public static iotCloudService MobileSvc { get; set; }

        public App ()
		{
            MobileSvc = new iotCloudService("https://iotbenko2.azurewebsites.net");

            InitializeComponent();

			MainPage = new IoTDemoClient.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
