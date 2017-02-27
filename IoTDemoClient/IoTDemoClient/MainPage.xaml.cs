using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IoTDemoClient
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void btnRegister(object sender, EventArgs e)
        {
            var name = "";// txtName.Text;
            var rc = await App.MobileSvc.Register(name);

        }

        private void btnSend(object sender, EventArgs e)
        {

        }
    }
}
