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

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EntryGuestBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!App.Admin)
            {
                AdminBtn.Content = "Войти как Пользователь";
                RegistrationBtn.Visibility = Visibility.Collapsed;
                EntryGuestBtn.Visibility = Visibility.Collapsed;
                PhoneSp.Visibility = Visibility.Collapsed;
                LineTb.Visibility = Visibility.Collapsed;
                App.Admin = true;
            }
            else
            {
                AdminBtn.Content = "Войти от имени Администратора";
                RegistrationBtn.Visibility = Visibility.Visible;
                EntryGuestBtn.Visibility = Visibility.Visible;
                PhoneSp.Visibility = Visibility.Visible;
                LineTb.Visibility = Visibility.Visible;
                App.Admin = false;
            }
        }
    }
}
