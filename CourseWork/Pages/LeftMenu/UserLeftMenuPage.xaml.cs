using CourseWork.Components;
using CourseWork.Pages.CenterFrame;
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

namespace CourseWork.Pages.LeftMenu
{
    /// <summary>
    /// Логика взаимодействия для UserLeftMenuPage.xaml
    /// </summary>
    public partial class UserLeftMenuPage : Page
    {
        public UserLeftMenuPage()
        {
            InitializeComponent();
            //проверка на гостя
            if (App.Guest)
            {
                //если гость кнопка профиля скрывается
                ProfileBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                //если нет отображается
                ProfileBtn.Visibility = Visibility.Visible;
            }
        }

        //кнопка выхода из аккаунта
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            //сокрытие меню
            Navigations.NavigateVisibleFrame(false);
            //открытие страницы авторизации
            Navigations.NavigateAllWindow(new AuthorizationPage());
            //очистка записанного пользователя
            App.ThisUser = new Users();
        }

        //кнопка профиля
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие профиля в центральной области
            Navigations.NavigateCenterWindow(new ProfilePage());
        }
    }
}
