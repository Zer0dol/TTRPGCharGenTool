using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TTRPG_Tool.classes;

namespace TTRPG_Tool.pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Shadowrun5EButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("../pages/TTRPGPages/Shadowrun5E/Shadowrun5EMain.xaml", UriKind.Relative));
            Utilities.SetAncestorTabItemHeader(this, "Shadowrun 5th Edition");
            Utilities.SetAncestorTabItemTollTip(this, "Shadowrun 5th Edition");
        }
        private void DnD5EButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("../pages/TTRPGPages/DnD5E/DnD5EMain.xaml", UriKind.Relative));
            Utilities.SetAncestorTabItemHeader(this, "Dungeons&Dragons 5th Edition");
            Utilities.SetAncestorTabItemTollTip(this, "Dungeons&Dragons 5th Edition");
        }
        private void Cyberpunk2020ButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("../pages/TTRPGPages/Cyberpunk2020/Cyberpunk2020Main.xaml", UriKind.Relative));
            Utilities.SetAncestorTabItemHeader(this, "Cuberpunk 2020");
            Utilities.SetAncestorTabItemTollTip(this, "Cuberpunk 2020");
        }
        private void WoDButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("../pages/TTRPGPages/WoD/WoDMain.xaml", UriKind.Relative));
            Utilities.SetAncestorTabItemHeader(this, "World of Darkness");
            Utilities.SetAncestorTabItemTollTip(this, "World of Darkness");
        }
    }
}
