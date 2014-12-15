using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FirstTask
{
    public class Place : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
