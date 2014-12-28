using FirstTaskv2.ProjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskv2.PlaceInterfaces
{
    interface IPlaceService
    {
        void AddPlace(Place place);
        List<Place> GetPlaces();
    }
}
