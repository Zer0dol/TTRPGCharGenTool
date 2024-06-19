using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TTRPG_Tool.classes
{
    internal class Utilities
    {
        public static void SetAncestorTabItemHeader(Visual currentWindow, string newHeader)
        {
            var currentParent = VisualTreeHelper.GetParent(currentWindow);
            while (!(currentParent is TabControl))
            {
                try
                {
                    currentParent = VisualTreeHelper.GetParent(currentParent);
                    if (currentParent is TabControl)
                    {
                        var FinalTabControl = currentParent as TabControl;
                        var finalTabItem = FinalTabControl.SelectedItem as TabItem;
                        finalTabItem.Header = newHeader;
                    }
                }
                catch { }
            }
        }
        public static void SetAncestorTabItemTollTip(Visual currentWindow, string newTooltip)
        {
            var currentParent = VisualTreeHelper.GetParent(currentWindow);
            while (!(currentParent is TabControl))
            {
                try
                {
                    currentParent = VisualTreeHelper.GetParent(currentParent);
                    if (currentParent is TabControl)
                    {
                        var FinalTabControl = currentParent as TabControl;
                        var finalTabItem = FinalTabControl.SelectedItem as TabItem;
                        finalTabItem.ToolTip = newTooltip;
                    }
                }
                catch { }
            }
        }
    }
}
