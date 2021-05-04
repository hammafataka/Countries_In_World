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
using Xamarin.Forms;

namespace Countries_In_World.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {

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
        public async Task LoadData()
        {

            Isbusy = true;
            CountryOptions.Clear();
            CountryOptions = await ApiService.GetCountries();
            SelectedGeoname.FlagUrl =$"https://raw.githubusercontent.com/hjnilsson/country-flags/master/png250px/{selectedGeoname.countryCode.ToLower()}.png";
            Isbusy = false;
        }
        public DetailViewModel()
        {
            CountryOptions = new List<Geoname>();
            SelectedGeoname = new Geoname();
            Task.Run(async () => await LoadData());
        }

    }

    
}
