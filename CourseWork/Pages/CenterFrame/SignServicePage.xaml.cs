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
    /// Логика взаимодействия для SignServicePage.xaml
    /// </summary>
    public partial class SignServicePage : Page
    {
        public static SignServicePage servicePage;
        public static Services services;

        private static IEnumerable<Users> trainers = new List<Users>();
        public SignServicePage(Services _services)
        {
            InitializeComponent();
            SignServicePage.servicePage = this;
            services = _services;

            DescriptionTb.Text = services.Discription;
            TitleTb.Text = services.Title;
            LevelTrainingCb.ItemsSource = App.db.LevelTraining.ToList();
            LevelTrainingCb.DisplayMemberPath = "Title";

            TimeCb.ItemsSource = App.db.AvaliableTime.ToList();
            TimeCb.DisplayMemberPath = "Title";

            DateDp.DisplayDateStart = DateTime.Now.AddDays(1);

            HorseCb.IsEnabled = false;
            TrainerCb.IsEnabled = false;
        }

        private void WhoCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.WhoCb.SelectedIndex == 0)
            {
                SignSp.Visibility = Visibility.Visible;
                WarningKidsTb.Visibility = Visibility.Collapsed;
                NewPersonSp.Visibility = Visibility.Collapsed;
                LevelTrainingCb.Text = App.ThisUser.LevelTrainingUsers.First().LevelTraining.Title;
                LevelTrainingCb.IsEnabled = false;
                WarningTrainingTb.Visibility = Visibility.Visible;
                Refresh();
            }
            else if (this.WhoCb.SelectedIndex == 1)
            {
                SignSp.Visibility = Visibility.Visible;
                WarningKidsTb.Visibility = Visibility.Visible;
                NewPersonSp.Visibility = Visibility.Collapsed;
                LevelTrainingCb.IsEnabled = true;
                LevelTrainingCb.Text = "";
                WarningTrainingTb.Visibility = Visibility.Collapsed;
                Refresh();
            }
            else if (this.WhoCb.SelectedIndex == 2)
            {
                SignSp.Visibility = Visibility.Collapsed;
                WarningKidsTb.Visibility = Visibility.Collapsed;
                NewPersonSp.Visibility = Visibility.Visible;
            }

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

        private static void Refresh()
        {
            if (servicePage.LevelTrainingCb.SelectedIndex != -1 && servicePage.DateDp.SelectedDate != null && servicePage.TimeCb.SelectedIndex != -1)
            {
                trainers = App.db.Users.Where(x => x.PositionId == 2 && x.LevelTrainingUsers.Where(a => a.LevelTrainingId == 
                servicePage.LevelTrainingCb.SelectedIndex + 1).Count() != 0).ToList();

                servicePage.TrainerCb.ItemsSource = trainers.Where(x => x.SignTrainings1.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex+1 
                && a.DateTrain == servicePage.DateDp.SelectedDate).Count() == 0);

                servicePage.TrainerCb.DisplayMemberPath = "FullName";
                servicePage.TrainerCb.IsEnabled = true;


                servicePage.HorseCb.IsEnabled = true;

                servicePage.HorseCb.ItemsSource = App.db.Horses.Where(x => x.LevelTrainingHorses.Where(b => b.LevelTrainingId == 
                servicePage.LevelTrainingCb.SelectedIndex + 1).Count() != 0 && x.SignTrainings.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex + 1 
                && a.DateTrain == servicePage.DateDp.SelectedDate).Count() == 0 && x.TypeId == 1).ToList();

                servicePage.HorseCb.DisplayMemberPath = "Moniker";
            }
        }

        private void TimeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LevelTrainingCb.Text) || string.IsNullOrEmpty(TimeCb.Text) || string.IsNullOrEmpty(DateDp.Text))
            {
                MessageBox.Show("Уровень подготовки с датой и временем должны быть заполнены обязательно!");
            }
            else
            {
                SignTrainings sign = new SignTrainings();
                sign.ServiceId = services.Id;
                sign.DateTrain = DateDp.SelectedDate;
                sign.TimeTrainId = TimeCb.SelectedIndex+1;
                sign.UserId = App.ThisUser.Id;
                sign.LevelTrainingId = App.db.LevelTraining.Where(x => x.Title == LevelTrainingCb.Text).First().Id;
                sign.QuantityPeople = 1;
                if (string.IsNullOrEmpty(TrainerCb.Text) && string.IsNullOrEmpty(HorseCb.Text))
                {
                    trainers = App.db.Users.Where(x => x.PositionId == 2 && x.LevelTrainingUsers.Where(a => a.LevelTrainingId ==
                    servicePage.LevelTrainingCb.SelectedIndex + 1).Count() != 0).ToList();

                    sign.TrainerId = trainers.Where(x => x.SignTrainings1.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex + 1
                    && a.DateTrain == servicePage.DateDp.SelectedDate).Count() == 0).First().Id;

                    sign.HorseId = App.db.Horses.Where(x => x.LevelTrainingHorses.Where(b => b.LevelTrainingId ==
                    servicePage.LevelTrainingCb.SelectedIndex + 1).Count() != 0 && x.SignTrainings.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex + 1
                    && a.DateTrain == servicePage.DateDp.SelectedDate).Count() == 0 && x.TypeId == 1).First().Id;

                    App.db.SignTrainings.Add(sign);
                    App.db.SaveChanges();
                    MessageBox.Show("Спасибо за запись! Вы можете просмотреть все свои записи и их статус в профиле.");
                    Navigations.NavigateCenterWindow(new HomePage());
                }
                else if (!string.IsNullOrEmpty(TrainerCb.Text) && string.IsNullOrEmpty(HorseCb.Text))
                {
                    sign.TrainerId = App.db.Users.Where(x => x.Surname + " " + x.FirstName + " " + x.Patronymic == TrainerCb.Text).First().Id;

                    sign.HorseId = App.db.Horses.Where(x => x.LevelTrainingHorses.Where(b => b.LevelTrainingId ==
                    servicePage.LevelTrainingCb.SelectedIndex + 1).Count() != 0 && x.SignTrainings.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex + 1
                    && a.DateTrain == servicePage.DateDp.SelectedDate).Count() == 0 && x.TypeId == 1).First().Id;

                    App.db.SignTrainings.Add(sign);
                    App.db.SaveChanges();
                    MessageBox.Show("Спасибо за запись! Вы можете просмотреть все свои записи и их статус в профиле.");
                    Navigations.NavigateCenterWindow(new HomePage());
                }
                else if (string.IsNullOrEmpty(TrainerCb.Text) && !string.IsNullOrEmpty(HorseCb.Text))
                {
                    trainers = App.db.Users.Where(x => x.PositionId == 2 && x.LevelTrainingUsers.Where(a => a.LevelTrainingId ==
                    servicePage.LevelTrainingCb.SelectedIndex + 1).Count() != 0).ToList();

                    sign.TrainerId = trainers.Where(x => x.SignTrainings1.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex + 1
                    && a.DateTrain == servicePage.DateDp.SelectedDate).Count() == 0).First().Id;

                    sign.HorseId = App.db.Horses.Where(x => x.Moniker == HorseCb.Text).First().Id;

                    App.db.SignTrainings.Add(sign);
                    App.db.SaveChanges();
                    MessageBox.Show("Спасибо за запись! Вы можете просмотреть все свои записи и их статус в профиле.");
                    Navigations.NavigateCenterWindow(new HomePage());
                }
                else if (!string.IsNullOrEmpty(TrainerCb.Text) && !string.IsNullOrEmpty(HorseCb.Text))
                {
                    sign.TrainerId = App.db.Users.Where(x => x.Surname + " " + x.FirstName + " " + x.Patronymic == TrainerCb.Text).First().Id;
                    sign.HorseId = App.db.Horses.Where(x => x.Moniker == HorseCb.Text).First().Id;
                    App.db.SignTrainings.Add(sign);
                    App.db.SaveChanges();
                    MessageBox.Show("Спасибо за запись! Вы можете просмотреть все свои записи и их статус в профиле.");
                    Navigations.NavigateCenterWindow(new HomePage());
                }
            }
        }
    }
}
