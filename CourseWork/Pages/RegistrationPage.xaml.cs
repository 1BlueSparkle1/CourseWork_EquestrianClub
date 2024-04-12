using CourseWork.Components;
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
        //объявление вспомогательной переменной
        private static Users user = new Users();
        public RegistrationPage()
        {
            InitializeComponent();
            //значение по-умолчанию для пола
            GenderCb.Text = "Неопределенный";
            //ограничение вводимого возраста
            DateOfBirthTb.DisplayDateEnd = DateTime.Now.AddYears(-14);
            LevelTrainingCb.ItemsSource = App.db.LevelTraining.ToList();
            LevelTrainingCb.DisplayMemberPath = "Title";
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
            //перебор пользователей
            IEnumerable<Users> users = App.db.Users.ToList();
            //переменная для нахождения ошибки
            bool error = false;
            foreach (var User in users)
            {
                //если пользователь с таким телефоном уже есть
                if (User.Phone == PhoneTb.Text)
                {
                    //отмечается ошибка
                    error = true;
                }
            }
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
            //есть ли ошибка телефона
            else if (error)
            {
                MessageBox.Show("Пользователь с таким телефоном уже существует!");
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
                user.DateOfBirthday = DateOfBirthTb.DisplayDate;
                user.PositionId = 1;
                if (LevelTrainingCb.SelectedIndex == 0)
                {
                    user.LevelTrainingId = 1;
                }
                else if (LevelTrainingCb.SelectedIndex == 1)
                {
                    user.LevelTrainingId = 2;
                }
                else if (LevelTrainingCb.SelectedIndex == 2)
                {
                    user.LevelTrainingId = 3;
                }
                else if (LevelTrainingCb.SelectedIndex == 3)
                {
                    user.LevelTrainingId = 4;
                }
                else if (LevelTrainingCb.SelectedIndex == 4)
                {
                    user.LevelTrainingId = 5;
                }
                else if (LevelTrainingCb.SelectedIndex == 5)
                {
                    user.LevelTrainingId = 6;
                }
                else if (LevelTrainingCb.SelectedIndex == 6)
                {
                    user.LevelTrainingId = 7;
                }
                else if (LevelTrainingCb.SelectedIndex == 7)
                {
                    user.LevelTrainingId = 8;
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
                Navigations.NavigateVisibleFrame(true);
                //обозначение, что не гость
                App.Guest = false;
                //вход в систему
                Navigations.NavigateCenterWindow(new TestPage());
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
