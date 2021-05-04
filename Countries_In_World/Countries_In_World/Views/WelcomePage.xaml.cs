using Countries_In_World.Models;
using Countries_In_World.Services;
using Countries_In_World.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countries_In_World.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        DetailViewModel vm;
        public  WelcomePage()
        {
            InitializeComponent();
            vm = new DetailViewModel(CountryPicker);
            BindingContext = vm;


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (IsPhoneNumber(userEmailOrPhoneEntry.Text))
            {
                string phoneNum = userEmailOrPhoneEntry.Text;
                await App.Current.MainPage.DisplayAlert("Saved", "The phone number was saved", "OK");
            }
            else
            {
                
                await App.Current.MainPage.DisplayAlert("Failed", "Make sure the entered number is correct", "OK");
            }
            
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"([0-9]{9})$").Success;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }

        private async void CountryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Run(() => vm.selectedindex.Execute(null));
        }
      
    }
}