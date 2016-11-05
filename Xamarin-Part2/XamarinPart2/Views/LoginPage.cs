using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinPart2.Views
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello Page" }
				}
			};
		}
	}
}
