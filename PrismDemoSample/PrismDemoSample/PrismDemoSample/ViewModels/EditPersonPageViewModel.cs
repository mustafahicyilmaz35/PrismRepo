using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using PrismDemoSample.Models;

namespace PrismDemoSample.ViewModels
{
    public class EditPersonPageViewModel : BindableBase, INavigatedAware
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }
        public EditPersonPageViewModel()
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            SelectedPerson = parameters.GetValue<Person>("selectedPerson");
        }
    }
}
