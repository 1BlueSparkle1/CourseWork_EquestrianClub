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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        //переменная для использования элементов MainWindow
        public static MainWindow mainWindow;
        //объявление вспомогательной переменной
        private static Users user = new Users();
        public RegistrationPage()
        {
            InitializeComponent();
            //значение по-умолчанию для пола
            GenderCb.Text = "Неопределенный";
            //ограничение вводимого возраста
            DateOfBirthTb.DisplayDateEnd = DateTime.Now.AddYears(-14);
        }

        //кнопка перехода на страницу входа
        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            //переход на страницу входа
            NavigationService.Navigate(new AuthorizationPage());
        }

        //кнопка регистрации
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            //поверка на ввод основных данных
            if(SurnameTb.Text == "" || PhoneTb.Text == "" || PasswordPb.Password == "")
            {
                //если они не заполнены
                MessageBox.Show("Надо заполнить все основные поля!");
            }
            //проверка на правильный ввод телефона
            else if (!Regex.IsMatch(PhoneTb.Text, @"8\d{3}\d{3}\d{2}\d{2}"))
            {
                //если введен неправильно
                MessageBox.Show("Номер телефона введен неправильно!");
            }
            //если все проверки пройдены
            else 
            {
                //заполняем вспомогательную переменную данными с формы
                user.Surname = SurnameTb.Text;
                user.FirstName = FirstnameTb.Text;
                user.Patronymic = PatronymicTb.Text;
                if (GenderCb.SelectedIndex == 0)
                {
                    user.GenderId = 1;
                }
                else if (GenderCb.SelectedIndex == 1)
                {
                    user.GenderId = 2;
                }
                else if (GenderCb.SelectedIndex == 2)
                {
                    user.GenderId = 3;
                }
                user.Phone = PhoneTb.Text;
                user.Password = PasswordPb.Password;
                //записываем данные с переменной в бд
                App.db.Users.Add(user);
                //сохраняем
                App.db.SaveChanges();
                //оповещаем пользователя о регистрации
                MessageBox.Show("Вы зарегистрированы!");
                //отображение и сокрытие фреймов
                mainWindow.LeftMenuFrame.Visibility = Visibility.Visible;
                mainWindow.TopMenuFrame.Visibility = Visibility.Visible;
                mainWindow.AllWindowFrame.Visibility = Visibility.Collapsed;
                //вход в систему
                NavigationService.Navigate(new TestPage());
            }
        }

        //при вводе символов в строку телефона
        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //соответствует ли символ цифре
            if (Regex.IsMatch(e.Text, @"[^0-9]"))
            {
                //если нет символ не вводится
                e.Handled = true;
            }
        }
    }
}
