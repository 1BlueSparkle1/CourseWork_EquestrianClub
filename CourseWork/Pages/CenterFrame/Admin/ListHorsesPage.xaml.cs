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

namespace CourseWork.Pages.CenterFrame.Admin
{
    /// <summary>
    /// Логика взаимодействия для ListHorsesPage.xaml
    /// </summary>
    public partial class ListHorsesPage : Page
    {
        public ListHorsesPage(string state)
        {
            InitializeComponent();
            IEnumerable<Horses> horses = App.db.Horses.ToList();
            foreach (Horses horse in horses)
            {
                ListHorseWp.Children.Add(new HorseInfoUserControl(horse, state));
            }
        }
    }
}
