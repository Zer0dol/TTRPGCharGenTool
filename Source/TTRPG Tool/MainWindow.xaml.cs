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
using TTRPG_Tool.dialogs;

namespace TTRPG_Tool
{
    public partial class MainWindow : Window
    {
        private static List<TabItem> _tabItems;
        int tabCounter = 1;
        public MainWindow()
        {
            LanguageFilesParser.SetCurrentSettings();
            InitializeComponent();
            _tabItems = new List<TabItem>();
            TabItem tabAdd = new TabItem();
            tabAdd.Style = (Style)FindResource("AddTab");
            tabAdd.Name = "Add";
            tabAdd.ToolTip = UILangStrings.UINewTab;
            _tabItems.Add(tabAdd);
            this.AddTabItem();
            MainTabs.DataContext = _tabItems;
            MainTabs.SelectedIndex = 0;
        }
        #region WindowChrome  Navigation
        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ResizeWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                ShrinkTabs();
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                UnShrinkTabs();
            }
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
        #region ManagingTabs
        public void ShrinkTabs()
        {
            double availableSpace = TTRPGWindow.ActualWidth - 260;
            int actualTabsCount = _tabItems.Count - 1;
            double scaleFactor = 1.0;
            double tabMaxWidth = 202;
            foreach (TabItem tab in _tabItems)
            {
                if (tab.Name != "Add")
                {
                    if (tab.ActualWidth * actualTabsCount > availableSpace)
                    {
                        scaleFactor = availableSpace / (tab.ActualWidth * actualTabsCount);
                        tab.Width = Math.Min(tab.ActualWidth * scaleFactor, tabMaxWidth);
                        //tab.Width = tab.ActualWidth * scaleFactor;
                    }
                }
            }
        }
        public void UnShrinkTabs()
        {
            double availableSpace = TTRPGWindow.ActualWidth - 260;
            int actualTabsCount = _tabItems.Count - 1;
            double scaleFactor = 1.0;
            double tabMaxWidth = 202;
            foreach (TabItem tab in _tabItems)
            {
                if (tab.Name != "Add")
                {
                    if (tab.ActualWidth * actualTabsCount < availableSpace)
                    {
                        scaleFactor = availableSpace / (tab.ActualWidth * actualTabsCount);
                        if (tab.ActualWidth < tabMaxWidth)
                        {
                            tab.Width = Math.Min(tab.ActualWidth * scaleFactor, tabMaxWidth);
                        }
                    }
                }
            }
        }
        private TabItem AddTabItem()
        {
            int tabCount = _tabItems.Count;
            TabItem tab = new TabItem();
            
            tab.Style = (Style)FindResource("ControlTabItem");
            tab.Header = UILangStrings.UIMenuPage;
            tab.ToolTip = tab.Header;
            tab.Name = string.Format("tab{0}", tabCounter);
            tab.HeaderTemplate = MainTabs.FindResource("TabHeader") as DataTemplate;
            
            Frame frame = new Frame();
            frame.Name = "TabFrame";
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frame.Source = new Uri("../pages/MenuPage.xaml", UriKind.Relative);
            tab.Content = frame;

            _tabItems.Insert(tabCount - 1, tab);
            tabCounter++;
            return tab;
        }
        private void AddTabPress(object sender, SelectionChangedEventArgs e)
        {
            double availableSpace = TTRPGWindow.ActualWidth - 190;
            int actualTabsCount = _tabItems.Count - 1;
            TabItem tab = MainTabs.SelectedItem as TabItem;
            if (tab != null && tab.Name != null)
            {
                if (tab.Name.Equals("Add"))
                {
                    MainTabs.DataContext = null;
                    TabItem newTab = this.AddTabItem();
                    MainTabs.DataContext = _tabItems;
                    MainTabs.SelectedItem = newTab;
                    ShrinkTabs();
                }
            }
        }
        private void CloseTab(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();
            var item = MainTabs.Items.Cast<TabItem>().Where
                (i => i.Name.Equals(tabName)).SingleOrDefault();
            TabItem tab = item as TabItem;
            if (tab != null)
            {
                if (_tabItems.Count < 3)
                {
                    ConfirmCloseDialog confirmClose = new ConfirmCloseDialog();
                    confirmClose.Topmost = true;
                    confirmClose.ShowDialog();
                }
                else
                {
                    TabItem selectedTab = MainTabs.SelectedItem as TabItem;
                    MainTabs.DataContext = null;
                    _tabItems.Remove(tab);
                    MainTabs.DataContext = _tabItems;
                    UnShrinkTabs();
                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = _tabItems[0];
                    }
                    MainTabs.SelectedItem = selectedTab;
                }
            }
        }
        #endregion

        private void ShowSettingsWindow(object sender, RoutedEventArgs e)
        {
            SettingsDialog settings = new SettingsDialog();
            settings.Topmost = true;
            settings.Closed += (_, args) =>
            {
                LanguageFilesParser.SetCurrentSettings();
            };
            settings.ShowDialog();
        }
    }
}
