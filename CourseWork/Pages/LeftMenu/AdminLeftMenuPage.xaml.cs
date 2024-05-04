using CourseWork.Pages.TopMenu.Admin;
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
    /// Логика взаимодействия для AdminLeftMenuPage.xaml
    /// </summary>
    public partial class AdminLeftMenuPage : Page
    {
        public AdminLeftMenuPage()
        {
            InitializeComponent();
        }

        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateTopMenu(new UsersTopMenuPage("user"));
        }

        private void TrainersBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateTopMenu(new UsersTopMenuPage("train"));
        }

        private void StablemanBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateTopMenu(new UsersTopMenuPage("stable"));
        }

        private void HorsesBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateTopMenu(new UsersTopMenuPage("horse"));
        }

        private void ChillRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateTopMenu(new UsersTopMenuPage("room"));
        }

        private void SignsBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateTopMenu(new UsersTopMenuPage("sign"));
        }

        private void QuestionsBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateTopMenu(new TestPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            //сокрытие меню
            Navigations.NavigateVisibleFrame(false);
            //снятие админа с пользователя
            App.Admin = false;
            //открытие страницы авторизации
            Navigations.NavigateAllWindow(new AuthorizationPage());
        }
    }
}
