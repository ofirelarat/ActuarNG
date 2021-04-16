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

        private void NewPersonContactFromGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails);

            docxGenerator.GenerateNewPersonContactForm();
        }

        private void NewPersonEconomyFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails);

            docxGenerator.GenerateNewPersonEconomyDetailsForm();
        }

        private void NewPersonEmpowerFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails);

            docxGenerator.GenerateNewPersonEmpowerForm();
        }

        private void NewPersonFullFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails);

            docxGenerator.GenerateNewPersonFullForm();
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

        private ContactFormPerson CreateContactDetails()
        {
            ContactFormPerson contactFormDetails = new ContactFormPerson()
            {
                CaseOwner = (Owner)case_owner.SelectedIndex,
                CaseInfo = new CaseDetails()
                {
                    CaseTypeValue = (CaseType)case_type.SelectedIndex,
                    OpenDate = DateTime.Now,
                    DecisionDate = case_decision_date.SelectedDate ?? new DateTime(),
                    CaseReceivementDate = receiving_case_date.SelectedDate ?? new DateTime(),
                    PublishDays = publish_days.Text,
                    CourtName = court_name.Text,
                    CaseNum = int.Parse(case_num.Text),
                    JudgeName = judge_name.Text
                },
                Person_1 = new Person()
                {
                    FullName = fullName_1.Text,
                    Id = id_1.Text,
                    BirthDate = birth_date_1.SelectedDate ?? new DateTime()
                },
                Person_2 = new Person()
                {
                    FullName = fullName_2.Text,
                    Id = id_2.Text,
                    BirthDate = birth_date_2.SelectedDate ?? new DateTime()
                },
                PartnershipEndDate = partnership_end.SelectedDate ?? new DateTime(),
                PartnershipStartDate = partnership_start.SelectedDate ?? new DateTime(),
                WorkEssence = work_essence.Text,
                CreationDate = DateTime.Now

            };

            return contactFormDetails;
        }
    }
}
