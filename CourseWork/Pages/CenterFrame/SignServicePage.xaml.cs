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

        private static IEnumerable<Users> trainers = new List<Users>();
        public SignServicePage(Services services)
        {
            InitializeComponent();
            SignServicePage.servicePage = this;

            DescriptionTb.Text = services.Discription;
            TitleTb.Text = services.Title;
            LevelTrainingCb.ItemsSource = App.db.LevelTraining.ToList();
            LevelTrainingCb.DisplayMemberPath = "Title";

            TimeCb.ItemsSource = App.db.AvaliableTime.ToList();
            TimeCb.DisplayMemberPath = "Title";

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
                LevelTrainingCb.Text = App.ThisUser.LevelTraining.Title;
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
                trainers = App.db.Users.Where(x => x.PositionId == 2 && x.LevelTraining.Title == servicePage.LevelTrainingCb.Text).ToList();
                servicePage.TrainerCb.ItemsSource = trainers.Where(x => x.SignTrainings1.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex+1 
                && a.DateTrain == servicePage.DateDp.SelectedDate).Count() == 0);
                servicePage.TrainerCb.DisplayMemberPath = "Surname";
                servicePage.TrainerCb.IsEnabled = true;

                servicePage.HorseCb.IsEnabled = true;
                servicePage.HorseCb.ItemsSource = App.db.Horses.Where(x => x.LevelTraining.Title == servicePage.LevelTrainingCb.Text && 
                x.SignTrainings.Where(a => a.TimeTrainId == servicePage.TimeCb.SelectedIndex + 1 && a.DateTrain == 
                servicePage.DateDp.SelectedDate).Count() == 0).ToList();
                servicePage.HorseCb.DisplayMemberPath = "Moniker";
            }
        }

        private void TimeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
