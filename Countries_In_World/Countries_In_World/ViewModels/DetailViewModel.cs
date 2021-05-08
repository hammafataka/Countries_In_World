using Countries_In_World.Models;
using Countries_In_World.Services;
using Countries_In_World.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Countries_In_World.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {

        private int score;

        public int Score
        {
            get { return score; }
            set { SetProperty(ref score, value); }
        }


        private List<Geoname> countryoptions;

        public List<Geoname> CountryOptions
        {
            get { return countryoptions; }
            set {SetProperty(ref countryoptions , value); }
        }
        private Geoname selectedGeoname;
        
        public Geoname SelectedGeoname
        {
            
            get { return selectedGeoname; }
            set { SetProperty(ref selectedGeoname, value); }
        }
        public ICommand LoadDataCommand { private set; get; }
        public ICommand selectionChangedCommand { private set; get; }
        public ICommand TouchedCommand { private set; get; }
        public ICommand LabelTouchedCommand { private set; get; }


        public async Task labeltouched()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = SelectedGeoname.countryName+"\n"+selectedGeoname.currencyCode+"\n"+SelectedGeoname.continent,
                Title = SelectedGeoname.countryName+" Details"
            });
        }
        public async Task touched()
        {
            if (SelectedGeoname != null)
            {
                string answer = await App.Current.MainPage.DisplayPromptAsync("Guess","Guess the country capital..");
                if (SelectedGeoname.capital.ToLower() == answer)
                {
                    score += 5;
                }
            }
            
        }
        public async Task LoadData()
        {

            Isbusy = true;
            CountryOptions.Clear();
            CountryOptions = await ApiService.GetCountries();
            Isbusy = false;
        }
        public DetailViewModel()
        {
            Score = new int();
            CountryOptions = new List<Geoname>();
            SelectedGeoname = new Geoname();
            Task.Run(async () => await LoadData());
            TouchedCommand = new Command(async () => await touched());
            LabelTouchedCommand = new Command(async () => await labeltouched());
        }

    }

    
}
