using FirstTaskv2.ProjectClasses;
using FirstTaskv2.PlaceInterfaces;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskv2.ProjectClasses
{
    public class PlaceService : IPlaceService
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
        "https://patronawp-agataborninska.azure-mobile.net/",
        "rbgfKYVLhsybfgDmXFICKxDBLsTRSa57"
        );

        private static List<Place> listPlaces = new List<Place>();

        public async void AddPlace(Place place)
        {
            listPlaces.Add(place);
            await MobileService.GetTable<Place>().InsertAsync(place);
        }

        public List<Place> GetPlaces()
        {
            return listPlaces;
        }
    }
}
