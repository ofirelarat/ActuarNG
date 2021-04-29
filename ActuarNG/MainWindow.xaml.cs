using ClientsDAO;
using Common;
using Common.Models;
using PDFGeneratorLogic;
using SettingMgr;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (new_form_tab.IsSelected)
            {
                // TODO: on select tab
            }
            if (check_list_tab.IsSelected)
            {
                // TODO: on select tab
            }
            if (clients_status_tab.IsSelected)
            {
                IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());
                List<Client> clients = clientDAO.GetClients();

                clients_status_DataGrid.ItemsSource = clients;
            }
            if (settings_tab.IsSelected)
            {
                ConfigMgr configMgr = new ConfigMgr();
                destenation_folder.Text = configMgr.GetDestenationPath();
                clients_archive_file_path.Text = configMgr.GetClientArchivePathPath();
            }
        }

        private void NewPersonContactFromGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            new_client_progress_indicator.Visibility = Visibility.Visible;
            
            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr()) ;

            docxGenerator.GenerateNewPersonContactForm();
            if (IsSavingClientData.IsChecked.Value)
            {
                AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
            }

            new_client_progress_indicator.Visibility = Visibility.Hidden;
        }

        private void NewPersonEconomyFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            new_client_progress_indicator.Visibility = Visibility.Visible;

            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr());

            docxGenerator.GenerateNewPersonEconomyDetailsForm();

            if (IsSavingClientData.IsChecked.Value)
            {
                AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
            }

            new_client_progress_indicator.Visibility = Visibility.Hidden;
        }

        private void NewPersonEmpowerFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            new_client_progress_indicator.Visibility = Visibility.Visible;

            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr());

            docxGenerator.GenerateNewPersonEmpowerForm();

            if (IsSavingClientData.IsChecked.Value)
            {
                AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
            }

            new_client_progress_indicator.Visibility = Visibility.Hidden;
        }

        private void NewPersonFullFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            new_client_progress_indicator.Visibility = Visibility.Visible;

            ContactFormPerson contactFormDetails = CreateContactDetails();
            DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr());

            docxGenerator.GenerateNewPersonFullForm();

            if (IsSavingClientData.IsChecked.Value)
            {
                AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
            }

            new_client_progress_indicator.Visibility = Visibility.Hidden;
        }

        private Client checkListSearchedClient = null;
        private void check_list_search_btn_Click(object sender, RoutedEventArgs e)
        {
            check_list_progress_indicator.Visibility = Visibility.Visible;

            IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());
            Client client = clientDAO.GetClient(check_list_search.Text);
            if(client != null)
            {
                check_list_owner_name.Text = $"התיק בטיפולו של:{client.ContactForm.CaseOwner}";
                check_list_partner_1.Text = $"ת.ז: {client.ContactForm.Person_1.Id}, שם: {client.ContactForm.Person_1.FullName}";
                check_list_partner_2.Text = $"ת.ז: {client.ContactForm.Person_2.Id}, שם: {client.ContactForm.Person_2.FullName}";

                check_list_DataGrid.ItemsSource = client.CheckListRows;
                checkListSearchedClient = client;
            }
            else
            {
                check_list_not_found_placement.Text = "הלקוח לא נמצא";
            }

            check_list_progress_indicator.Visibility = Visibility.Hidden;
        }
        private void check_list_DataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            check_list_progress_indicator.Visibility = Visibility.Visible;

            IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());

            if (e.EditAction == DataGridEditAction.Commit && checkListSearchedClient != null)
            {

                ((List<CheckListRow>)check_list_DataGrid.ItemsSource)[e.Row.GetIndex()] = e.Row.DataContext as CheckListRow;
                checkListSearchedClient.CheckListRows[e.Row.GetIndex()] = e.Row.DataContext as CheckListRow;

                clientDAO.UpdateClient(checkListSearchedClient);
            }

            check_list_progress_indicator.Visibility = Visibility.Hidden;
        }

        private void SaveSettingsConfig_Click(object sender, RoutedEventArgs e)
        {
            SettingsConfig settingsConfig = new SettingsConfig()
            {
                DestenationPath = destenation_folder.Text,
                ClientsArchiveFilePath = clients_archive_file_path.Text
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

        private void AddNewClient(ContactFormPerson contactFormDetails, List<CheckListRow> checkListRows)
        {
            Client client = new Client()
            {
                ContactForm = contactFormDetails,
                CheckListRows = checkListRows
            };
            client.CheckListRows[0].Person_1_value = client.ContactForm.Person_1.FullName;
            client.CheckListRows[0].Person_2_value = client.ContactForm.Person_2.FullName;

            IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());
            clientDAO.AddNewClient(client);
        }
    }
}
