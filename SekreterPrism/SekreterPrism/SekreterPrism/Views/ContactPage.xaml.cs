using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SekreterPrism.Interfaces;
using SekreterPrism.Models;
using SekreterPrism.ViewModels;
using Xamarin.Forms;

namespace SekreterPrism.Views
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
           

        }

        


        private  void SearchBarContact_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                Device.BeginInvokeOnMainThread(() =>
                    {
                        ListViewContact.ItemsSource = (BindingContext as ContactPageViewModel).GroupData;
                    });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ListViewContact.ItemsSource =
                       (BindingContext as ContactPageViewModel).GroupData.Where(p =>
                           p.Any(a => a.Name.ToUpper().StartsWith(e.NewTextValue.ToUpper())));




                    





                    //ListViewContact.ItemsSource =
                    //    (BindingContext as ContactPageViewModel).Contacts.Where(p =>
                    //        p.Name.ToLower().Contains(e.NewTextValue.ToLower()));



                });
            }
        }
    }
}
