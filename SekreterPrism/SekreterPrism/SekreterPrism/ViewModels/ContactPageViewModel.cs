using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Services;
using SekreterPrism.Extensions;
using SekreterPrism.Interfaces;
using SekreterPrism.Models;
using Xamarin.Forms;

namespace SekreterPrism.ViewModels
{
    public class ContactPageViewModel : BindableBase
    {
        private readonly IDependencyService _dependencyService;
        private IList<Contact> _contacts;

        public IList<Contact> Contacts
        {
            get => _contacts;
            set => SetProperty(ref _contacts, value);
        }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }


        //Group

        private List<ObservableGroupCollection<string, Contact>> _groupData;
        public List<ObservableGroupCollection<string, Contact>> GroupData
        {
            get => _groupData;
            set => SetProperty(ref _groupData, value);
        }

        public IList<Contact> Items { get; private set; }

        //ctor
        public ContactPageViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
           Init();
           

        }


        //private ICommand _searchCommand;

        //public ICommand SearchCommand =>
        //    _searchCommand ?? (_searchCommand = new Command<string>(SearchActionAsync));

        //private async void SearchActionAsync(string obj)
        //{
        //    if (obj == null)
        //    {
        //        Init();
        //    }
        //    else
        //    {
        //        foreach (var item in GroupData)
        //        {
        //            foreach (var item2 in item.Gr)
        //            {
        //                Contacts = await _dependencyService.Get<IContactService>().GetContactListAsync();
        //                Thread.Sleep(500);
        //                GroupData.Add(item2.ToString());
        //            }
                    
        //        }
        //    }
        //}


         async Task Init()
        {
            Contacts = await _dependencyService.Get<IContactService>().GetContactListAsync();
            Items = Contacts.OrderBy(c => c.Name).ToList();
            
            Thread.Sleep(500);
            GroupData = Items.OrderBy(p => p.Name).GroupBy(p => p.Name[0].ToString().ToUpper())
                .Select(p => new ObservableGroupCollection<string, Contact>(p)).ToList();
        }

       
    }
}
