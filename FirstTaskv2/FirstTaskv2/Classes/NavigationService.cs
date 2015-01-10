using FirstTaskv2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FirstTaskv2.Classes
{
    public class NavigationService : INavigationService
    {
        private static Frame rootFrame;

        public void RegisterRootFrame(Frame frame)
        {
            rootFrame = frame;
        }

        public void Navigate(Type type)
        {
            rootFrame.Navigate(type);
        }
    }
}
