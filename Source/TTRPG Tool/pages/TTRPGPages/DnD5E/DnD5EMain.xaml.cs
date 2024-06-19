﻿using System;
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

namespace TTRPG_Tool.pages.TTRPGPages.DnD5E
{
    /// <summary>
    /// Логика взаимодействия для DnD5EMain.xaml
    /// </summary>
    public partial class DnD5EMain : Page
    {
        public DnD5EMain()
        {
            InitializeComponent();
        }
        private void ReturnHome(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("../pages/MenuPage.xaml", UriKind.Relative));
            Utilities.SetAncestorTabItemHeader(this, UILangStrings.UIMenuPage);
            Utilities.SetAncestorTabItemTollTip(this, UILangStrings.UIMenuPage);
        }
    }
}
