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

namespace TTRPG_Tool.pages.TTRPGPages.Shadowrun5E
{
    /// <summary>
    /// Логика взаимодействия для ShadowrunMain.xaml
    /// </summary>
    public partial class Shadowrun5EMain : Page
    {
        public Shadowrun5EMain()
        {
            InitializeComponent();
        }

        private void ReturnHome(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("../pages/MenuPage.xaml", UriKind.Relative));
            Utilities.SetAncestorTabItemHeader(this, "Начальная страница");
            Utilities.SetAncestorTabItemTollTip(this, "Начальная страница");
        }
    }
}
