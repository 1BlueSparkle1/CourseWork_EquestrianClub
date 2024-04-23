using CourseWork.Components;
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

namespace CourseWork.Pages.CenterFrame
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            //установка контекста в виде вошедшего пользователя
            this.DataContext = App.ThisUser;
            //ограничение вводимого возраста
            DateOfBirthdayDp.DisplayDateEnd = DateTime.Now.AddYears(-14);
            //заполнение комбо бокса
            LevelTrainingCb.ItemsSource = App.db.LevelTraining.ToList();
            LevelTrainingCb.DisplayMemberPath = "Title";
            //заполнение текущего текста в комбо боксе
            if(App.ThisUser.PositionId == 1)
            {
                LevelTrainingCb.Text = App.db.LevelTrainingUsers.Where(x => x.UserId == App.ThisUser.Id).First().LevelTraining.Title;
            }
        }

        //кнопка изменить
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            //открывается редактирование полей профиля
            SurnameTb.IsEnabled = true;
            NameTb.IsEnabled = true;
            PatronymicTb.IsEnabled = true;
            GenderCb.IsEnabled = true;
            DateOfBirthdayDp.IsEnabled = true;
            PhoneTb.IsEnabled = true;
            LevelTrainingCb.IsEnabled = true;
            //отображаем кнопку сохранить
            SaveBtn.Visibility = Visibility.Visible;
            //скрываем кнопку изменить
            EditBtn.Visibility = Visibility.Collapsed;
        }

        //кнопка сохранить
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(App.ThisUser.PositionId == 1)
            {
                //записываются новые введенные данные пользователя
                App.ThisUser.Surname = SurnameTb.Text;
                App.ThisUser.FirstName = NameTb.Text;
                App.ThisUser.Patronymic = PatronymicTb.Text;
                if (GenderCb.SelectedIndex == 0)
                {
                    App.ThisUser.GenderId = 1;
                }
                else if (GenderCb.SelectedIndex == 1)
                {
                    App.ThisUser.GenderId = 3;
                }
                else if (GenderCb.SelectedIndex == 2)
                {
                    App.ThisUser.GenderId = 2;
                }
                App.ThisUser.DateOfBirthday = DateOfBirthdayDp.DisplayDate;
                if (LevelTrainingCb.SelectedIndex == 0)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 1;
                }
                else if (LevelTrainingCb.SelectedIndex == 1)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 2;
                }
                else if (LevelTrainingCb.SelectedIndex == 2)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 3;
                }
                else if (LevelTrainingCb.SelectedIndex == 3)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 4;
                }
                else if (LevelTrainingCb.SelectedIndex == 4)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 5;
                }
                else if (LevelTrainingCb.SelectedIndex == 5)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 6;
                }
                else if (LevelTrainingCb.SelectedIndex == 6)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 7;
                }
                else if (LevelTrainingCb.SelectedIndex == 7)
                {
                    App.ThisUser.LevelTrainingUsers.First().LevelTrainingId = 8;
                }
                App.ThisUser.Phone = PhoneTb.Text;
                //сохранения этих данных в базу
                App.db.SaveChanges();
            }
            //запрет редактирования полей
            SurnameTb.IsEnabled = false;
            NameTb.IsEnabled = false;
            PatronymicTb.IsEnabled = false;
            GenderCb.IsEnabled = false;
            DateOfBirthdayDp.IsEnabled = false;
            PhoneTb.IsEnabled = false;
            LevelTrainingCb.IsEnabled = false;
            //скрываем кнопку сохранить
            SaveBtn.Visibility = Visibility.Collapsed;
            //отображаем кнопку редактировать
            EditBtn.Visibility = Visibility.Visible;
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

        private void EditPassBtn_Click(object sender, RoutedEventArgs e)
        {
            //переход на страницу изменения пароля
            NavigationService.Navigate(new EditPasswordPage());
        }
    }
}
