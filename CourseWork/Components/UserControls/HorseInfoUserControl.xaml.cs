using System;
using System.Collections.Generic;
using System.IO;
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

namespace CourseWork.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для HorseInfoUserControl.xaml
    /// </summary>
    public partial class HorseInfoUserControl : UserControl
    {
        public HorseInfoUserControl(Horses horses, string state)
        {
            InitializeComponent();

            //определяем, что контекст данных у элемента horses
            this.DataContext = horses;

            //заполнение блоков сложными данными(которые надо объединять или преобразовывать)
            MonikerTb.Text = "Кличка: " + horses.Moniker;
            GenderTb.Text = "Пол: " + horses.HorseGender.Title;
            BreedTb.Text = "Порода: " + horses.Breeds.Title;
            
            if(horses.DateOfBirthday != null)
            {
                DateTime birth = (DateTime)horses.DateOfBirthday;
                DateOfBirthdayTb.Text = birth.Date.ToString().Remove(birth.Date.ToString().Length - 8);
            }
            KategoriTb.Text = "Категория: " + horses.TypeHorses.Title;
            string train = "";
            foreach (var item in horses.LevelTrainingHorses.ToList())
            {
                train += item.LevelTraining.Title + ", ";
            }
            if (train == "")
            {
                LevelTrainingTb.Text = $"Уровни подготовки: Неизвестно";
            }
            else
            {
                LevelTrainingTb.Text = $"Уровни подготовки: {train.Remove(train.Length - 2)}.";
            }

            LogoHorseImg.Source = GetImageSource(horses.ImageSourseByte);
        }

        private BitmapImage GetImageSource(byte[] byteImage)
        {

            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                if (byteImage != null)
                {
                    MemoryStream byteStream = new MemoryStream(byteImage);
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = byteStream;
                    bitmapImage.EndInit();
                }
                else
                    bitmapImage = new BitmapImage(new Uri(@"\Resources\Bell.png", UriKind.Relative));

            }
            catch
            {
                MessageBox.Show("Error");
            }
            return bitmapImage;
        }
    }
}
