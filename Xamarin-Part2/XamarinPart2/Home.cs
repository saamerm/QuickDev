using System;
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

            var x = AsyncFunction();
            var y = x.Result;
            var weather2 = new Weather();
            y.weather.Add(weather2);
            weatherText.Text = "Looks like there is a " + y.weather[0].description + " in " + y.name;
            //DependencyService.Get<ITextToSpeech>().Speak(weatherText.Text);

            //        weatherButton.Clicked+= async (sender, e) => 
        //  {
				//HttpClient client = new HttpClient();
				//Uri uri = new Uri("http://api.openweathermap.org/data/2.5/weather?q=chicago,usa&APPID=4573c189d467ca1814c1c10000060792");
				//string obstring = await client.GetStringAsync (uri);
				//RootObject weatherlist = JsonConvert.DeserializeObject<RootObject> (obstring);
                
    //            //weatherText.Text = "Here's the city" + weatherlist.name;
    //            //Commented above because complicating a little more

    //            //var weather1 = new Weather();
    //            //weatherlist.weather.Add(weather1);
    //            //weatherText.Text = "Looks like there is a " + weatherlist.weather[0].description+" in "+weatherlist.name  ;
    //            //DependencyService.Get<ITextToSpeech> ().Speak (weatherText.Text);


    //            var x = AsyncFunction();
    //            var y = x.Result;
    //            var weather2= new Weather();
    //            y.weather.Add(weather2);
    //            weatherText.Text = "Looks like there is a " + y.weather[0].description + " in " + y.name;
    //            DependencyService.Get<ITextToSpeech>().Speak(weatherText.Text);

    //        };
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
            Uri uri = new Uri("http://api.openweathermap.org/data/2.5/weather?q=chicago,usa&APPID=4573c189d467ca1814c1c10000060792");
            string obstring = await client.GetStringAsync(uri);
            RootObject weatherlist = JsonConvert.DeserializeObject<RootObject>(obstring);
            return weatherlist;
        }
    }
}


