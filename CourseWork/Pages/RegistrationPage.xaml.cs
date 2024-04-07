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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            GenderCb.Text = "Неопределенный";
        }

        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if(SurnameTb.Text == "" || PhoneTb.Text == "" || PasswordPb.Password == "")
            {
                MessageBox.Show("Надо заполнить все основные поля!");
            }
            else
            {
                if (Regex.IsMatch(PhoneTb.Text, @"8\d{3}\d{3}\d{2}\d{2}"))
                {
                    MessageBox.Show("Вы зарегистрированы!");
                }
                else
                {
                    MessageBox.Show("Номер телефона введен неправильно!");
                }
            }
        }


        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[^0-9]"))
            {
                e.Handled = true;
            }
        }
    }
}
