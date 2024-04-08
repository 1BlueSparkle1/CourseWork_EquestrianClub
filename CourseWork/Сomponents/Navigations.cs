using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork.Сomponents
{
    internal class Navigations
    {
        public static MainWindow mainWindow;

        public static void NavigateLeftMenu(Page page)
        {
            mainWindow.LeftMenuFrame.Navigate(page);
        }

        public static void NavigateTopMenu(Page page)
        {
            mainWindow.TopMenuFrame.Navigate(page);
        }

        public static void NavigateCenterWindow(Page page)
        {
            mainWindow.CenterWindowFrame.Navigate(page);
        }

        public static void NavigateAllWindow(Page page)
        {
            mainWindow.AllWindowFrame.Navigate(page);
        }

        public static void NavigateVisibleFrame(bool visible)
        {
            if (visible)
            {
                mainWindow.LeftMenuFrame.Visibility = Visibility.Visible;
                mainWindow.TopMenuFrame.Visibility = Visibility.Visible;
                mainWindow.AllWindowFrame.Visibility = Visibility.Collapsed;
            }
            else
            {
                mainWindow.LeftMenuFrame.Visibility = Visibility.Collapsed;
                mainWindow.TopMenuFrame.Visibility = Visibility.Collapsed;
                mainWindow.AllWindowFrame.Visibility = Visibility.Visible;
            }
        }
    }
}
