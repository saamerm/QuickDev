﻿using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinPart2
{
	public class Home : ContentPage
	{
		public Home ()
		{
			Label title = new Label {
				Text = "Weather in Chicago",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof (Label))
			};

			Label subtitle = new Label {
				Text = "Click below to get the weather in Chicago",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Label))
			};
            #region Commented Custome Joke Entries
            //Label entryText = new Label {
            //	Text = "Enter your name to get a custom Joke",
            //	HorizontalOptions = LayoutOptions.Center,
            //	VerticalOptions = LayoutOptions.StartAndExpand,
            //	FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Label))
            //};

            //Entry firstNameEntry = new Entry {
            //	Text = "First Name",
            //	HorizontalOptions = LayoutOptions.CenterAndExpand,
            //	VerticalOptions = LayoutOptions.StartAndExpand,

            //};

            //Entry lastNameEntry = new Entry {
            //	Text = "Last Name",
            //	HorizontalOptions = LayoutOptions.CenterAndExpand,
            //	VerticalOptions = LayoutOptions.StartAndExpand,
            //};
            #endregion
            Label weatherText = new Label {
				Text = "",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Label))
			};

			Button weatherButton = new Button {
				Text = "Get Weather",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Button))
			};
			weatherButton.Clicked+= async (sender, e) => {
				HttpClient client = new HttpClient();
				//Uri uri = new Uri("http://api.openweathermap.org/data/2.5/weather?q=chicago,usa&APPID=4573c189d467ca1814c1c10000060792");
				client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "1714e4b600734175a106030a2ea3ff4f");
				var uri = "https://dsapi-stage.directscale.com/v1/customers/availabilitycheck/booboo";
				//Uri uri = new Uri("https://dsapi-stage.directscale.com/v1/customers/availabilitycheck/booboo");
				string obstring = await client.GetStringAsync (uri);
				int a = 5;
				RootObject weatherlist = JsonConvert.DeserializeObject<RootObject> (obstring);
                //weatherText.Text = "Here's the city" + weatherlist.name;
                //Complicating a little more
                var weather1 = new Weather();
                weatherlist.weather.Add(weather1);
                weatherText.Text = "Looks like there is a " + weatherlist.weather[0].description+" in "+weatherlist.name  ;
                DependencyService.Get<ITextToSpeech> ().Speak (weatherText.Text);


                //var x = AsyncFunction();
                //var y = x.Result;
                //y.weather.Add(weather1);
			};
            #region Commented customJokeButton
            //Button customJokeButton = new Button {
            //	Text = "Get Custom Joke",
            //	HorizontalOptions = LayoutOptions.Center,
            //	VerticalOptions = LayoutOptions.StartAndExpand,
            //	FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Button))
            //};
            //customJokeButton.Clicked+= async (sender, e) => {
            //	HttpClient client = new HttpClient();
            //	Uri uri = new Uri("http://api.icndb.com/jokes/random?limitTo=[nerdy]&firstName="
            //		+ firstNameEntry.Text+"&lastName="+ lastNameEntry.Text);
            //	string obstring = await client.GetStringAsync (uri);
            //	Joke joke = JsonConvert.DeserializeObject<Joke> (obstring);
            //	jokeText.Text = joke.value.joke;
            //	DependencyService.Get<ITextToSpeech> ().Speak (joke.value.joke);
            //};
            #endregion
            
            
            StackLayout stack = new StackLayout {
                //Children = {title, subtitle, entryText, firstNameEntry, lastNameEntry, jokeButton, customJokeButton, jokeText},
                Children = {title, subtitle, weatherButton, weatherText},
                Padding = 20
			};
			this.Padding = new Thickness(0,Device.OnPlatform (20,0,0),0,0);
			this.Content = stack;
		}
        public async Task<RootObject> AsyncFunction()
        {
            HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "1714e4b600734175a106030a2ea3ff4f");
			var uri = "https://dsapi-stage.directscale.com/v1/customers/availabilitycheck/booboo";
			//Uri uri = new Uri("http://api.openweathermap.org/data/2.5/weather?q=chicago,usa&APPID=4573c189d467ca1814c1c10000060792");
            string obstring = await client.GetStringAsync(uri);
            RootObject weatherlist = JsonConvert.DeserializeObject<RootObject>(obstring);
            return weatherlist;
        }
    }
}


