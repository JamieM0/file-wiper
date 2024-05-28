using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace file_wiper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> files = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFunction_Click(object sender, RoutedEventArgs e)
        {
            foreach(string file in files)
            {
                Wiper.WipeFile(file, 3);
            }
            MessageBox.Show("Deleted " + files.Count() + " files.", "Files Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            files.Clear();
            btnFunction.IsEnabled = false;
            btnFunction.Content = "Delete Files";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Open file dialog to select multiple files
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                //Get the selected file names
                string[] filenames = dlg.FileNames;
                //Display the selected file names in a listbox
                foreach (string filename in filenames)
                {
                    files.Add(filename);
                }
            }

            btnFunction.Content = "Delete " + files.Count + " files";
            btnFunction.IsEnabled = true;
        }
    }
}