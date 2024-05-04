using CourseWork.Components;
using CourseWork.Pages.CenterFrame;
using CourseWork.Pages.LeftMenu;
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
        //объявление вспомогательных переменных
        private static Users User = new Users();
        private static bool error = true;
        public static MainWindow mainWindow;

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        //Кнопка войти
        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            //Объявление перебора всех юзеров
            IEnumerable<Users> users = App.db.Users.ToList();

            //Проверка на админа
            if (App.Admin)
            {
                //перебор юзеров
                foreach(var user in users)
                {
                    //находим юзера админа
                    if (user.Surname == "Admin" && user.PositionId == 4)
                    {
                        //если найден указываем, что нет ошибок
                        error = false;
                        //и записываем этого пользователя в переменную
                        User = user;
                    }
                }
                //если ошибок нет
                if (!error)
                {
                    //проверяем правильность пароля админа
                    if (User.Password == Md5Class.hashPassword(PasswordPb.Password))
                    {

                        //отображение и сокрытие фреймов при правильном пароле
                        Navigations.NavigateVisibleFrame(true);
                        //обозначение, что не гость
                        App.Guest = false;
                        mainWindow.NotificationsBtn.Visibility = Visibility.Visible;
                        //назначаем пользователя админом
                        App.Admin = true;
                        // вход в систему
                        Navigations.NavigateCenterWindow(new TestPage());
                        Navigations.NavigateLeftMenu(new AdminLeftMenuPage());
                        //обнуление ошибок
                        error = true;
                    }
                    else
                    {
                        //вывод сообщения о неправильном пароле
                        MessageBox.Show("Неверный пароль!");
                    }
                }
            }
            else // если не админ
            {
                //проверка правильности введения телефона
                if (Regex.IsMatch(PhoneTb.Text, @"8\d{3}\d{3}\d{2}\d{2}"))
                {
                    //перебор пользователей
                    foreach (var user in users)
                    {
                        //поиск пользователя с таким телефоном
                        if (user.Phone == PhoneTb.Text)
                        {
                            //если найден указываем, что нет ошибок
                            error = false;
                            //и записываем этого пользователя в переменную
                            User = user;
                        }
                    }
                    //если ошибок с нахождением по телефону нет
                    if (!error)
                    {
                        //обнуляем ошибки
                        error = true;
                        //если у выбраного пользователя совпадает пароль
                        if (User.Password == Md5Class.hashPassword(PasswordPb.Password))
                        {
                            //проверка на должность входящего пользователя
                            if(User.PositionId == 1)
                            {
                                //отображение и сокрытие фреймов
                                Navigations.NavigateVisibleFrame(true);
                                //обозначение, что не гость
                                App.Guest = false;
                                mainWindow.NotificationsBtn.Visibility = Visibility.Visible;
                                //записываем какой ползователь входит
                                App.ThisUser = User;
                                //вход в систему как посетитель
                                Navigations.NavigateLeftMenu(new UserLeftMenuPage());
                                Navigations.NavigateCenterWindow(new HomePage());
                                //обнуление ошибок
                                error = true;
                            }
                            else if (User.PositionId == 2)
                            {
                                //отображение и сокрытие фреймов
                                Navigations.NavigateVisibleFrame(true);
                                //обозначение, что не гость
                                App.Guest = false;
                                mainWindow.NotificationsBtn.Visibility = Visibility.Visible;
                                //записываем какой ползователь входит
                                App.ThisUser = User;
                                //вход в систему как тренер
                                Navigations.NavigateLeftMenu(new UserLeftMenuPage());
                                //обнуление ошибок
                                error = true;
                            }
                            else if (User.PositionId == 3)
                            {
                                //отображение и сокрытие фреймов
                                Navigations.NavigateVisibleFrame(true);
                                //обозначение, что не гость
                                App.Guest = false;
                                mainWindow.NotificationsBtn.Visibility = Visibility.Visible;
                                //записываем какой ползователь входит
                                App.ThisUser = User;
                                //вход в систему как конюх
                                Navigations.NavigateLeftMenu(new UserLeftMenuPage());
                                //обнуление ошибок
                                error = true;
                            }
                            else
                            {
                                //если должность по какой-то причине не опознана
                                MessageBox.Show("Произошла какая-то ошибка, пожалуйста, попробуйте еще раз.");
                            }
                        }
                        //если у выбраного пользователя не совпадает пароль
                        else
                        {
                            MessageBox.Show("Пароль введен неправильно!");
                        }
                    }
                    //если ошибоки с нахождением по телефону есть
                    else
                    {
                        MessageBox.Show("Пользователь с таким телефоном не найден!");
                    }
                }
                //если телефон введен неправильно
                else
                {
                    MessageBox.Show("Номер телефона введен неправильно!");
                }
            }
        }

        //кнопка входа как гость
        private void EntryGuestBtn_Click(object sender, RoutedEventArgs e)
        {
            //отображение и сокрытие фреймов
            Navigations.NavigateVisibleFrame(true);
            //объявление, что гость
            App.Guest = true;
            App.ThisUser = new Users();
            mainWindow.NotificationsBtn.Visibility = Visibility.Collapsed;
            //вход в систему
            Navigations.NavigateCenterWindow(new HomePage());
            Navigations.NavigateLeftMenu(new UserLeftMenuPage());
        }

        //кнопка перехода к регистрации
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            //переход на страницу регистрации
            NavigationService.Navigate(new RegistrationPage());
        }

        //кнопка входа для админа или пользователя
        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            //проверка на админа
            if (!App.Admin)
            {
                //измеяем текст кнопки
                AdminBtn.Content = "Войти как Пользователь";
                //скрываем ненужные элементы
                RegistrationBtn.Visibility = Visibility.Collapsed;
                EntryGuestBtn.Visibility = Visibility.Collapsed;
                PhoneSp.Visibility = Visibility.Collapsed;
                LineTb.Visibility = Visibility.Collapsed;
                //назначаем пользователя админом
                App.Admin = true;
                //обнуляем пароль и телефон
                PasswordPb.Password = "";
                PhoneTb.Text = "8";
            }
            //если админ
            else
            {
                //измеяем текст кнопки
                AdminBtn.Content = "Войти от имени Администратора";
                //показываем скрытые элементы
                RegistrationBtn.Visibility = Visibility.Visible;
                EntryGuestBtn.Visibility = Visibility.Visible;
                PhoneSp.Visibility = Visibility.Visible;
                LineTb.Visibility = Visibility.Visible;
                //снимаем звание админа
                App.Admin = false;
                //обнуляем пароль и телефон
                PasswordPb.Password = "";
                PhoneTb.Text = "8";
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
