using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrismDemoSample.Models;

namespace PrismDemoSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _title;
        private readonly INavigationService _navigationService;
        private List<Person> _people;
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                SetProperty(ref _selectedPerson, value);
                HandleSelectedPerson();
            }
        }

        private async void HandleSelectedPerson()
        {
            var param = new NavigationParameters();
            param.Add("selectedPerson",SelectedPerson);
            await _navigationService.NavigateAsync("EditPersonPage", param);

        }

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
        public MainPageViewModel(INavigationService navigationService)
        {

            Title = "Main Page";
            People = new List<Person>();
            People.Add(new Person
            {
                Name="Mustafa"
            });
            People.Add(new Person
            {
                Name ="Hasan"
            });
            _navigationService = navigationService;
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(NavigateActionAsync));

        private async void NavigateActionAsync()
        {
            var param = new NavigationParameters();
            param.Add("people",People);
            await _navigationService.NavigateAsync("ViewA",param);
        }
    }
}
