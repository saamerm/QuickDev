using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace FirstHackDallas
{
	public class Home : ContentPage
	{
		public Home ()
		{
			Label title = new Label {
				Text = "Part 2",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof (Label))
			};

			Label subtitle = new Label {
				Text = "Click below to get a hilarious joke",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Label))
			};
			
			Label jokeText = new Label {
				Text = "",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Label))
			};

			Button jokeButton = new Button {
				Text = "Get Joke",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Button))
			};
			jokeButton.Clicked+= async (sender, e) => {
				HttpClient client = new HttpClient();
				Uri uri = new Uri("http://api.icndb.com/jokes/random?limitTo=[nerdy]");
				string obstring = await client.GetStringAsync (uri);
				Model joke = JsonConvert.DeserializeObject<Model> (obstring);
				jokeText.Text = joke.value.joke;
				DependencyService.Get<ITextToSpeech> ().Speak (joke.value.joke);
			};
            
			StackLayout stack = new StackLayout {
                //Children = {title, subtitle, entryText, firstNameEntry,
                //    lastNameEntry, jokeButton, customJokeButton, jokeText},
                Children = {title, subtitle, jokeButton, jokeText},
                Padding = 20
			};
			this.Padding = new Thickness(0,Device.OnPlatform (20,0,0),0,0);
			this.Content = stack;
		}
	}
}


