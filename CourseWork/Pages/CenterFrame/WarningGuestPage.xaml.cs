using CourseWork.Components;
using CourseWork.Сomponents;
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

namespace CourseWork.Pages.CenterFrame
{
    /// <summary>
    /// Логика взаимодействия для WarningGuestPage.xaml
    /// </summary>
    public partial class WarningGuestPage : Page
    {
        public WarningGuestPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            //сокрытие меню
            Navigations.NavigateVisibleFrame(false);
            //открытие страницы регистрации
            Navigations.NavigateAllWindow(new RegistrationPage());
            //очистка записанного пользователя
            App.ThisUser = new Users();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            //сокрытие меню
            Navigations.NavigateVisibleFrame(false);
            //открытие страницы авторизации
            Navigations.NavigateAllWindow(new AuthorizationPage());
            //очистка записанного пользователя
            App.ThisUser = new Users();
        }
    }
}
