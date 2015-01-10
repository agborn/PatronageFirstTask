using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.Windows.Input;

namespace FirstTaskv2.Classes
{
    public class Place : INotifyPropertyChanged
    {
        public string Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public async void Geolocation()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            Geoposition geoposition = await geolocator.GetGeopositionAsync(
             maximumAge: TimeSpan.FromMinutes(5),
             timeout: TimeSpan.FromSeconds(10)
            );

            Latitude = geoposition.Coordinate.Latitude;
            Longitude = geoposition.Coordinate.Longitude;
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
                if (value != this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
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
                if (value != this.address)
                {
                    this.address = value;
                    NotifyPropertyChanged("Address");
                }
            }
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (value != this.latitude)
                {
                    this.latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }

        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (value != this.longitude)
                {
                    this.longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
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
                if (value != this.hasWifi)
                {
                    this.hasWifi = value;
                    NotifyPropertyChanged("HasWifi");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Name, Address);
        }
    }
}
