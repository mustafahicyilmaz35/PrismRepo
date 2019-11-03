using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using PrismDemoSample.Models;

namespace PrismDemoSample.ViewModels
{
    public class ViewAViewModel : BindableBase,INavigatedAware
    {
        private string _title;
        private List<Person> _people;

        public List<Person> People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public ViewAViewModel()
        {
            Title = "View A";
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            People = parameters.GetValue<List<Person>>("people");
        }
    }
}
