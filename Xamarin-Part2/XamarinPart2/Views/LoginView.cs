using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstHackDallas
{
	public class LoginView : ContentPage
	{
		public LoginView ()
		{
            var username = new Entry { Text = "" };
            var password = new Entry { Text = "" };
            //Content = new Label { Text = "Hello View" };
            var button = new Button { Text="Login", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
            button.Clicked += (sender, e) =>
            {
                if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
                {
                    DisplayAlert("Validation Error" , "Username and Password are required", "Re-try");
                }
                else
                {
                    // REMEMBER LOGIN STATUS!
                    App.Current.Properties["IsLoggedIn"] = true;
                    //ilm.ShowMainPage();
                }

                
            };
            Content = new StackLayout
            {
                Padding = new Thickness(10, 40, 10, 10),
                Children = {
                        new Label { Text = "Login", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
                        new Label { Text = "Username" },
                        username,
                        new Label { Text = "Password" },
                        password,
                        button                }
            };
		}
	}
}
