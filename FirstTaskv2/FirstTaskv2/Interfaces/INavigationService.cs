using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FirstTaskv2.Interfaces
{
    interface INavigationService
    {
        void RegisterRootFrame(Frame frame);
        void Navigate(Type type);
    }
}
