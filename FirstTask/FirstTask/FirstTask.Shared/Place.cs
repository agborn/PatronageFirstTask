using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace FirstTask
{
    public class Place : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public async void geolocation()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            Geoposition geoposition = await geolocator.GetGeopositionAsync(
            maximumAge: TimeSpan.FromMinutes(5),
            timeout: TimeSpan.FromSeconds(10));

            latitude = geoposition.Coordinate.Latitude;
            longitude = geoposition.Coordinate.Longitude;
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                geolocation();
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }

        private double longitude;
        public double Longitude
        {
            get
            {
                geolocation();
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        private bool hasWifi;
        public bool HasWifi
        {
            get
            {
                return hasWifi;
            }
            set
            {
                hasWifi = value;
            }
        }

        public override string ToString()
        {
            return "{" + Name + "}, {" + Address + "}";
        }

    }
}
