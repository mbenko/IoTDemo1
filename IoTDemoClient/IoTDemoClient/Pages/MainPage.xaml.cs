using IoTDemoClient.PageModels;
using IoTDemoClient.Pages;
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
        MainPageModel model = new MainPageModel();
		public MainPage()
		{
			InitializeComponent();
            rootLayout.BindingContext = model;
		}

        private async void btnRegister(object sender, EventArgs e)
        {
            var name = model.Name; // "";// txtName.Text;
            var rc = await App.MobileSvc.Register(model.Name);

            await Navigation.PushModalAsync(new DevicesPage());

        }

        private void btnSend(object sender, EventArgs e)
        {

        }
    }
}
