using Common.Models;
using PDFGeneratorLogic;
using SettingMgr;
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

namespace ActuarNG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            ConfigMgr configMgr = new ConfigMgr();
            destenation_folder.Text = configMgr.GetDestenationPath();
        }

        private void NewPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactFormPerson contactForm = new ContactFormPerson()
            {
                FullName = fullName.Text,
                Id = id.Text,
                EmailAddress = email.Text,
                PhoneNumber = phoneNum.Text
            };

            DocxGenerator docxGenerator = new DocxGenerator(contactForm);

            docxGenerator.GenerateNewPersonWord();
        }

        private void SaveSettingsConfig_Click(object sender, RoutedEventArgs e)
        {
            SettingsConfig settingsConfig = new SettingsConfig()
            {
                DestenationPath = destenation_folder.Text
            };

            ConfigMgr configMgr = new ConfigMgr();
            configMgr.SetSettings(settingsConfig);
        }
    }
}
