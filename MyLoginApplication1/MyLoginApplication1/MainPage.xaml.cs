using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyLoginApplication1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var loginService = new LoginService();
            var usernameEntry = this.FindByName<Entry>("UsernameEntry");
            var passwordEntry = this.FindByName<Entry>("PasswordEntry");

            var loginButton = this.FindByName<Button>("LoginButton");
            loginButton.IsEnabled = false;
            try {
                var result = await loginService.login(usernameEntry.Text, passwordEntry.Text);
                if (result)
                {
                    await DisplayAlert("Login Successfull", "You have been logged in", "Close");
                }
                else
                {
                    await DisplayAlert("Login Failed", "Login failed", "Close");
                }
            } finally {
                loginButton.IsEnabled = true;
            }
        }
    }
}
