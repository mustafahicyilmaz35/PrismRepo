using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;
using PrismDepSample.Droid.Service;
using PrismDepSample.Interfaces;
using Xamarin.Forms;
using Debug = System.Diagnostics.Debug;


[assembly:Dependency(typeof(TextToSpeech_Android))]
namespace PrismDepSample.Droid.Service
{
    public class TextToSpeech_Android: Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private string toSpeak;


        public void Speak(string text)
        {
            var c = Forms.Context;
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(c, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
                Debug.WriteLine("spoke " + toSpeak);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
            else
            {
                Debug.WriteLine("was quiet");
            }
        }
    }
}