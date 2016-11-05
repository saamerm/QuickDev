using System;
using AVFoundation;
using FirstHackDallas.iOS;

[assembly: Xamarin.Forms.Dependency (typeof (TextToSpeechIOS))]

namespace FirstHackDallas.iOS
{
	public class TextToSpeechIOS : ITextToSpeech
	{
		public TextToSpeechIOS ()
		{
		}


		public void Speak (string text)
		{
			var speechSynthesizer = new AVSpeechSynthesizer ();

			var speechUtterance = new AVSpeechUtterance (text) {
				Rate = AVSpeechUtterance.MaximumSpeechRate/2,
				Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
				Volume = 0.5f,
				PitchMultiplier = 1.0f
			};

			speechSynthesizer.SpeakUtterance (speechUtterance);
		}
	}
}

