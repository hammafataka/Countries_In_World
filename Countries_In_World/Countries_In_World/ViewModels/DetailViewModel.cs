using Countries_In_World.Models;
using Countries_In_World.Services;
using Countries_In_World.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Countries_In_World.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        public List<string> countries { get; set; }

        public ObservableCollection<Geoname> CountryOptions { get; }
        private Geoname selectedGeoname;
        
        public Geoname SelectedGeoname
        {
            
            get { return selectedGeoname; }
            set { SetProperty(ref selectedGeoname, value); }
        }
        public ICommand LoadDataCommand { private set; get; }
        public ICommand selectedindex { private set; get; }
        public async Task LoadData()
        {
            countries = new List<string>();
            Isbusy = true;
            CountryOptions.Clear();
            List<Geoname> localsList = await ApiService.GetCountries();
           foreach ( Geoname g in localsList)
            {
                countries.Add(g.countryName);
               CountryOptions.Add(g);
                

            }

            Isbusy = false;
        }
        public DetailViewModel()
        {
            SelectedGeoname = new Geoname();
            CountryOptions = new ObservableCollection<Geoname>();
            LoadDataCommand = new Command(async () => await LoadData());
        }

    }

    
}
