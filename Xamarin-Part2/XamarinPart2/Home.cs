using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace XamarinPart2
{
	public class Home : ContentPage
	{
		public Home ()
		{
			Label title = new Label {
				Text = "Particle photon working",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof (Label))
			};

			Label subtitle = new Label {
				Text = "Click below to get what the response field is",
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
				Text = "Get Value",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof (Button))
			};
			jokeButton.Clicked+= async (sender, e) => {
				HttpClient client = new HttpClient();
				Uri uri = new Uri("https://thingspeak.com/channels/176089/field/1.json");
				string obstring = await client.GetStringAsync (uri);
				RootObject photonRead = JsonConvert.DeserializeObject<RootObject> (obstring);
                var readingList = new Feed();
                photonRead.feeds.Add(readingList);
				jokeText.Text = photonRead.channel.last_entry_id.ToString()+photonRead.feeds[photonRead.channel.last_entry_id-1].field1;
				DependencyService.Get<ITextToSpeech> ().Speak (jokeText.Text);
			};
            


			StackLayout stack = new StackLayout {
                Children = {title, subtitle, jokeButton, jokeText},
                Padding = 20
			};
			this.Padding = new Thickness(0,Device.OnPlatform (20,0,0),0,0);
			this.Content = stack;
		}
	}
}


