using CourseWork.Pages;
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

        //навигация левого меню
        public static void NavigateLeftMenu(Page page)
        {
            //назначение на фрейм страницу
            mainWindow.LeftMenuFrame.Navigate(page);
        }

        //навигация верхнего меню
        public static void NavigateTopMenu(Page page)
        {
            //назначение на фрейм страницу
            mainWindow.TopMenuFrame.Navigate(page);
        }

        //навигация сентральной области
        public static void NavigateCenterWindow(Page page)
        {
            //назначение на фрейм страницу
            mainWindow.CenterWindowFrame.Navigate(page);
        }

        //навигация общего фрейма
        public static void NavigateAllWindow(Page page)
        {
            //назначение на фрейм страницу
            mainWindow.AllWindowFrame.Navigate(page);
        }

        //отображение элементов
        public static void NavigateVisibleFrame(bool visible)
        {
            //если их надо отобразить
            if (visible)
            {
                //отображаются верхнее и левое меню
                mainWindow.LeftMenuFrame.Visibility = Visibility.Visible;
                mainWindow.TopMenuFrame.Visibility = Visibility.Visible;
                //скрывается общий фрейм
                mainWindow.AllWindowFrame.Visibility = Visibility.Collapsed;
                //центральная область принимает пустую страничку
                NavigateCenterWindow(new TestPage());
            }
            //если надо скрыть
            else
            {
                //скрывается верхнее и левое меню
                mainWindow.LeftMenuFrame.Visibility = Visibility.Collapsed;
                mainWindow.TopMenuFrame.Visibility = Visibility.Collapsed;
                //отображается общий фрейм
                mainWindow.AllWindowFrame.Visibility = Visibility.Visible;
                //центральная область принимает пустую страничку
                NavigateCenterWindow(new TestPage());
            }
        }
    }
}
