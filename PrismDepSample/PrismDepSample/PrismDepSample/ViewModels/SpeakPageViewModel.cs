using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Services;
using PrismDepSample.Interfaces;

namespace PrismDepSample.ViewModels
{
    public class SpeakPageViewModel : BindableBase
    {
        private readonly IDependencyService _dependencyService;
        private string _textToSay = "Hello Xamarin.Forms Prism";

        public string TextToSay
        {
            get => _textToSay;
            set => SetProperty(ref _textToSay, value);
        }
        public SpeakPageViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
        }

        private DelegateCommand _speakCommand;
        public DelegateCommand SpeakCommand => _speakCommand ?? (_speakCommand = new DelegateCommand(Speak));

        private void Speak()
        {
            _dependencyService.Get<ITextToSpeech>().Speak(TextToSay);
        }
    }
}
