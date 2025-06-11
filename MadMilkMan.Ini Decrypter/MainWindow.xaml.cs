using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MadMilkMan.Ini_Decrypter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String iniPath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inputFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Multiselect = false;
            ofd.Filter = "Ini file (*.ini)|*.ini";
            ofd.FilterIndex = ofd.Filter.Length;
            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                try
                {
                    convertFileButton.IsEnabled = false;

                    //We reset the value in order to know if the user has selected a file or not
                    iniPath.Remove(0, iniPath.Length);

                    iniPath = ofd.FileName;

                    if (iniPath != string.Empty && encryptionPasswordTextBox.Text != string.Empty)
                    {
                        convertFileButton.IsEnabled = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void encryptionPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (encryptionPasswordTextBox.Text != string.Empty && iniPath != string.Empty)
            {
                convertFileButton.IsEnabled = true;
            }
            else
            {
                convertFileButton.IsEnabled = false;
            }
        }

        private void convertFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Ini file (*.ini)|*.ini";
            Nullable<bool> result = sfd.ShowDialog();

            if (result == true)
            {
                try
                {
                    StreamReader iniStream = new StreamReader(iniPath);
                    Ini iniFile = new Ini(encryptionPasswordTextBox.Text);
                    var decryptedIniFile = iniFile.Load(iniStream);
                    iniStream.Close();

                    //Check if the generated file has been decrypted correctly or not
                    if (decryptedIniFile.Sections.Contains("MADMILKMAN_INI_FILE_GLOBAL_SECTION"))
                    {
                        MessageBox.Show($"Incorrect encryption password entered.", "Process failed.", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        decryptedIniFile.Save(sfd.FileName);
                        MessageBox.Show($"Process completed successfully.", "Conversion completed.", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    convertFileButton.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}