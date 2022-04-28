using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Template
{
    public partial class MainWindow : Window
    {
        private string path;

        struct DataInputBox
        {
            public string WANTED;
            public string NUMBERCASE;
            public string NAMESUS;
            public string age;
            public string heigh;
            public string weigh;
            public string build;
            public string hair;
            public string occup;
            public string scars;
            public string eyes;
            public string compli;
            public string race;
            public string nation;
            public string classif;
            public string arrestProc;
        }

        public MainWindow(string _path)
        {
            InitializeComponent();

            path = _path;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image(*.jpg *.png)|*.jpg;*.png";
            saveFile.ShowDialog();
            string savePath = saveFile.FileName;
            try
            {
                Image image = Image.FromFile(path + "\\test.jpg");
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                DataInputBox data = new DataInputBox();

                var PeopleAndFingers = SettingPath();

                if (CheckOfEmpty(savePath))
                {
                    DrawOnPicture(image, PeopleAndFingers.Item1, PeopleAndFingers.Item2, bitmap, savePath, ref data);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Путь к ресурсам не найден! Выберите другой путь!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                new SourcePath().Show();
                this.Close();
            }
        }

        private void ChangePhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image(*.jpg;*.png)|*.jpg;*.png";
            ofd.ShowDialog();

            PathPhotoPeople.Text = ofd.FileName;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            if (CheckOfEmpty(ofd.FileName))
            {
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.DecodePixelHeight = 468;
                bitmapImage.DecodePixelWidth = 450;
                bitmapImage.EndInit();
                PhotoSus.Source = bitmapImage;
            }
        }

        private void ChangePhotoFingers(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image(*.jpg;*.png)|*.jpg;*.png";
            ofd.ShowDialog();

            PathPhotoFingers.Text = ofd.FileName;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            if (CheckOfEmpty(ofd.FileName))
            {
                bitmapImage.UriSource = new Uri(ofd.FileName);
                bitmapImage.DecodePixelHeight = 172;
                bitmapImage.DecodePixelWidth = 432;
                bitmapImage.EndInit();
                FINGERS.Source = bitmapImage;
            }
        }

        private void DrawOnPicture(Image _image, Image _people, Image _fingers, Bitmap _bitmap, string _savePath, ref DataInputBox data )
        {
            ChangeDataInStruct(ref data);

            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.DrawImage(_image, 0, 0, _image.Width, _image.Height);
                g.DrawString(data.WANTED, new Font("Tahoma", 36, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(496, 358, 1050, 60));
                g.DrawString(data.NUMBERCASE, new Font("Tahoma", 22, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(1660, 364, 500, 60));
                g.DrawString(data.NAMESUS, new Font("Tahoma", 36, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, new RectangleF(310, 419, 690, 60));

                g.DrawString(data.age, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 560, 700, 60));
                g.DrawString(data.heigh, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 605, 700, 60));
                g.DrawString(data.weigh, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 645, 700, 60));
                g.DrawString(data.build, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 685, 700, 60));
                g.DrawString(data.hair, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 725, 700, 60));
                g.DrawString(data.occup, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 765, 700, 60));
                g.DrawString(data.scars, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 805, 700, 60));
                g.DrawString(data.eyes, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 845, 700, 60));
                g.DrawString(data.compli, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 885, 700, 60));
                g.DrawString(data.race, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 925, 700, 60));
                g.DrawString(data.nation, new Font("Tahoma", 23, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(945, 965, 700, 60));

                g.DrawString(data.classif, new Font("Tahoma", 20, System.Drawing.FontStyle.Bold), Brushes.Black, new RectangleF(1380, 900, 700, 75));
                g.DrawString(data.arrestProc, new Font("Tahoma", 20, System.Drawing.FontStyle.Bold), Brushes.White, new RectangleF(160, 1080, 1700, 135));

                g.DrawImage(_people, new RectangleF(145, 527, 450, 468));
                g.DrawImage(_fingers, new RectangleF(1385, 650, 432, 172));

                _bitmap.Save(_savePath);
            }
        }

        private void ChangeDataInStruct(ref DataInputBox data)
        {
            data.WANTED = WANTEDFOR.Text;
            data.NUMBERCASE = NUMBER.Text;
            data.NAMESUS = NAMESUSPECT.Text;
            data.age = AGE.Text;
            data.heigh = HEIGH.Text;
            data.weigh = WEIGH.Text;
            data.build = BUILD.Text;
            data.hair = HAIR.Text;
            data.occup = OCCUPATION.Text;
            data.scars = SCAR.Text;
            data.eyes = EYES.Text;
            data.compli = COMPLEX.Text;
            data.race = RACE.Text;
            data.nation = NATION.Text;
            data.classif = CLASSIF.Text;
            data.arrestProc = ARRESTPROC.Text;
        }

        private (Image, Image) SettingPath()
        {
            Image _people;
            Image _fingers;
            if (PathPhotoPeople.Text != "")
            {
                _people = Image.FromFile(PathPhotoPeople.Text);
            }
            else
            {
                _people = Image.FromFile(path + "\\photochela.jpg");
            }

            if (PathPhotoFingers.Text != "")
            {

                _fingers = Image.FromFile(PathPhotoFingers.Text);
            }
            else
            {
                _fingers = Image.FromFile(path + "\\Fingers2.jpg");
            }

            return (_people, _fingers);
        }

        private bool CheckOfEmpty(string _str)
        {
            bool result = false;

            if (_str != "")
            {
                result = true;
            }
            return result;
        }
    }
}
