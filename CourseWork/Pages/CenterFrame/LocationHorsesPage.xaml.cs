using CourseWork.Components;
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
    /// Логика взаимодействия для LocationHorsesPage.xaml
    /// </summary>
    public partial class LocationHorsesPage : Page
    {
        public LocationHorsesPage()
        {
            InitializeComponent();
            IEnumerable<Horses> horses = App.db.Horses.ToList();
            foreach (Horses horse in horses)
            {
                if (horse.PositionStable.Side == "Left")
                {
                    if (horse.PositionStable.Number == 1)
                    {
                        LeftOneTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 2)
                    {
                        LeftTwoTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 3)
                    {
                        LeftThreeTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 4)
                    {
                        LeftFourTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 5)
                    {
                        LeftFiveTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 6)
                    {
                        LeftSixTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 7)
                    {
                        LeftSevenTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 8)
                    {
                        LeftEightTb.Text = horse.Moniker;
                    }

                }
                else if (horse.PositionStable.Side == "Right")
                {
                    if (horse.PositionStable.Number == 1)
                    {
                        RightOneTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 2)
                    {
                        RightTwoTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 3)
                    {
                        RightThreeTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 4)
                    {
                        RightFourTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 5)
                    {
                        RightFiveTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 6)
                    {
                        RightSixTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 7)
                    {
                        RightSevenTb.Text = horse.Moniker;
                    }
                    else if (horse.PositionStable.Number == 8)
                    {
                        RightEightTb.Text = horse.Moniker;
                    }

                }
            }
        }
    }
}
