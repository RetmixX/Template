using System.Windows;

namespace Template
{
    public partial class SourcePath : Window
    {
        public SourcePath()
        {
            InitializeComponent();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (PATH.Text!="" && PATH.Text!=" ")
            {
                new MainWindow(PATH.Text).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неккоректный путь!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
