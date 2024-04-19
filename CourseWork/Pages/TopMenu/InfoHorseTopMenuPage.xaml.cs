using CourseWork.Pages.CenterFrame;
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

namespace CourseWork.Pages.TopMenu
{
    /// <summary>
    /// Логика взаимодействия для InfoHorseTopMenuPage.xaml
    /// </summary>
    public partial class InfoHorseTopMenuPage : Page
    {
        public InfoHorseTopMenuPage()
        {
            InitializeComponent();
        }

        private void AllInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            //переход к странице информации о лошадях
            Navigations.NavigateCenterWindow(new MainInfoHorsePage());
        }

        private void LocationInStableBtn_Click(object sender, RoutedEventArgs e)
        {
            //переход к странице расположения лошадей в конюшне
            Navigations.NavigateCenterWindow(new LocationHorsesPage());
        }

        private void PrizeAndCompetiBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
