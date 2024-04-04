using CourseWork.Сomponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            IEnumerable<Users> users = App.db.Users.ToList();

            if (App.Admin)
            {
                foreach(var user in users)
                {
                    if (user.Surname == "Admin")
                    {
                        if (user.Password == PasswordPb.Password)
                        {
                            MessageBox.Show("Вы вошли!");
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден!");
                    }
                }
            }
            else
            {
                if (Regex.IsMatch(PhoneTb.Text, @"8\d{3}\d{3}\d{2}\d{2}"))
                {
                    foreach (var user in users)
                    {
                        if (user.Phone == PhoneTb.Text)
                        {
                            if (user.Password == PasswordPb.Password)
                            {
                                MessageBox.Show("Вы вошли!");
                            }
                            else
                            {
                                MessageBox.Show("Неверный пароль!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Номер телефона введен неправильно!");
                }
            }
        }

        private void EntryGuestBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вошли!");
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
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
                PasswordPb.Password = "";
                PhoneTb.Text = "8";
            }
            else
            {
                AdminBtn.Content = "Войти от имени Администратора";
                RegistrationBtn.Visibility = Visibility.Visible;
                EntryGuestBtn.Visibility = Visibility.Visible;
                PhoneSp.Visibility = Visibility.Visible;
                LineTb.Visibility = Visibility.Visible;
                App.Admin = false;
                PasswordPb.Password = "";
                PhoneTb.Text = "8";
            }
        }

        private void PhoneTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(PhoneTb.Text, @"[^0-9]"))
            {

            }
            else
            {
                PhoneTb.Text = PhoneTb.Text.Remove(PhoneTb.Text.Length - 1);
            }
        }
    }
}
