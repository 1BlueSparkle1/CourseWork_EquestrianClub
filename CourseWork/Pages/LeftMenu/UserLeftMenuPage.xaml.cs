using CourseWork.Components;
using CourseWork.Pages.CenterFrame;
using CourseWork.Pages.TopMenu;
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
    /// Логика взаимодействия для UserLeftMenuPage.xaml
    /// </summary>
    public partial class UserLeftMenuPage : Page
    {
        public UserLeftMenuPage()
        {
            InitializeComponent();
            //проверка на гостя
            if (App.Guest)
            {
                //если гость кнопка профиля скрывается
                ProfileBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                //если нет отображается
                ProfileBtn.Visibility = Visibility.Visible;
            }
        }

        //кнопка выхода из аккаунта
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            //сокрытие меню
            Navigations.NavigateVisibleFrame(false);
            //открытие страницы авторизации
            Navigations.NavigateAllWindow(new AuthorizationPage());
            //очистка записанного пользователя
            App.ThisUser = new Users();
        }

        //кнопка профиля
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие профиля в центральной области
            Navigations.NavigateCenterWindow(new ProfilePage());
        }

        //кнопка раздела тренировки
        private void TrainingBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие меню раздела тренировки
            Navigations.NavigateTopMenu(new TrainingTopMenuPage());
        }

        //кнопка раздела прогулки
        private void StrollsBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие меню раздела прогулки
            Navigations.NavigateTopMenu(new StrollsTopMenuPage());
        }

        //кнопка раздела другое
        private void OtherBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие меню раздела другое
            Navigations.NavigateTopMenu(new OtherTopMenuPage());
        }

        //кнопка главной страницы
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            //возвращение к главной странице
            Navigations.NavigateTopMenu(new TestPage());
            Navigations.NavigateCenterWindow(new HomePage());
        }

        //кнопка раздела информации о лошадях
        private void InfoHorseBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие меню раздела информации о лошадях
            Navigations.NavigateTopMenu(new InfoHorseTopMenuPage());
        }

        //кнопка раздела экскурсии
        private void ExcursionBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна экскурсий
            Navigations.NavigateTopMenu(new TestPage());
            Navigations.NavigateCenterWindow(new TestPage());
        }

        //кнопка раздела информации о зонах отдыха
        private void InfoRecreationBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна зон отдыха
            Navigations.NavigateTopMenu(new DopInfoTopMenuPage());
        }

        //кнопка раздела предложений услуг
        private void OfferServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна заявки на услугу
            Navigations.NavigateTopMenu(new TestPage());
            Navigations.NavigateCenterWindow(new TestPage());
        }

        //кнопка раздела тех поддержки
        private void TechnicalSupportBtn_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна тех поддержки
            Navigations.NavigateTopMenu(new TestPage());
            Navigations.NavigateCenterWindow(new TestPage());
        }
    }
}
