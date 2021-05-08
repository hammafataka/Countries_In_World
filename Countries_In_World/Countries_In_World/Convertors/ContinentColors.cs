using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Countries_In_World.Convertors
{
    public class ContinentColors : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string continentName="hamma";
            try
            {
                 continentName = value.ToString();

            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            if (continentName.ToLower() == "europe")
                return Color.Blue;
            if (continentName.ToLower() == "africa")
                return Color.Orange;
            if (continentName.ToLower() == "asia")
                return Color.FromHex("#FCF4A3");
            if (continentName.ToLower() == "north america"|| continentName.ToLower() == "south america")
                return Color.Green;
            if (continentName.ToLower() == "oceania")
                return Color.Red;

            return Color.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
