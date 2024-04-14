using CourseWork.Components;
using CourseWork.Components.UserControls;
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
    /// Логика взаимодействия для MainInfoHorsePage.xaml
    /// </summary>
    public partial class MainInfoHorsePage : Page
    {
        public MainInfoHorsePage()
        {
            InitializeComponent();
            IEnumerable<Horses> horses = App.db.Horses.ToList();
            foreach (Horses horse in horses)
            {
                MainInfoWp.Children.Add(new HorseInfoUserControl(horse));
            }
        }
    }
}
