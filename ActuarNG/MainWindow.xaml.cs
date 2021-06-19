using ClientsDAO;
using Common;
using Common.Models;
using PDFGeneratorLogic;
using SettingMgr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

namespace ActuarNG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isSourceFromOtherTab = false;

        public MainWindow()
        {
            InitializeComponent();

            error_snack_bar.IsActive = false;
            error_message_snack_bar.ActionClick += (object sender, RoutedEventArgs e) => error_snack_bar.IsActive = false;

            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(clients_status_DataGrid_MouseDoubleClick)));
            clients_status_DataGrid.RowStyle = rowStyle;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (new_form_tab.IsSelected && isSourceFromOtherTab)
                {
                    isSourceFromOtherTab = false;
                }
                else if (new_form_tab.IsSelected && e.Source.GetType() == typeof(TabControl))
                {
                    ClearNewClientFormTab();
                    case_owner.ItemsSource = ContactFormPerson.Owners;
                    case_type.ItemsSource = CaseDetails.CaseTypes;
                }
                else if (check_list_tab.IsSelected && e.Source.GetType() == typeof(TabControl))
                {
                    // TODO: on select tab
                }
                else if (clients_status_tab.IsSelected && e.Source.GetType() == typeof(TabControl))
                {
                    IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());
                    List<Client> clients = clientDAO.GetClients();

                    clients_status_DataGrid.ItemsSource = clients;
                    clients_status_cell.ItemsSource = Client.Statuses;
                }
                else if (settings_tab.IsSelected && e.Source.GetType() == typeof(TabControl))
                {
                    ConfigMgr configMgr = new ConfigMgr();
                    destenation_folder.Text = configMgr.GetDestenationPath();
                    clients_archive_file_path.Text = configMgr.GetClientArchivePathPath();
                }
            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "הקובץ לקוחות לא נמצא, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }


        private void NewPersonContactFromGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContactFormPerson contactFormDetails = CreateContactDetails();
                DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr());

                docxGenerator.GenerateNewPersonContactForm();
                if (IsSavingClientData.IsChecked.Value)
                {
                    AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
                }
            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "התקיית קבצים לא קיימת, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }

        private void NewPersonEconomyFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContactFormPerson contactFormDetails = CreateContactDetails();
                DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr());

                docxGenerator.GenerateNewPersonEconomyDetailsForm();

                if (IsSavingClientData.IsChecked.Value)
                {
                    AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
                }
            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "התקיית קבצים לא קיימת, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }

        private void NewPersonEmpowerFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContactFormPerson contactFormDetails = CreateContactDetails();
                DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr());

                docxGenerator.GenerateNewPersonEmpowerForm();

                if (IsSavingClientData.IsChecked.Value)
                {
                    AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
                }
            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "התקיית קבצים לא קיימת, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }

        private void NewPersonFullFormGenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContactFormPerson contactFormDetails = CreateContactDetails();
                DocxGenerator docxGenerator = new DocxGenerator(contactFormDetails, new ConfigMgr());

                docxGenerator.GenerateNewPersonFullForm();

                if (IsSavingClientData.IsChecked.Value)
                {
                    AddNewClient(contactFormDetails, Defaults.CheckListDefaultCollection);
                }

            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "התקיית קבצים לא קיימת, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }

        private Client checkListSearchedClient = null;
        private void check_list_search_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());
                Client client = clientDAO.GetClient(check_list_search.Text);
                if (client != null)
                {
                    check_list_owner_name.Text = $"התיק בטיפולו של:{client.ContactForm.CaseOwnerValue}";
                    check_list_partner_1.Text = $"ת.ז: {client.ContactForm.Person_1.Id}, שם: {client.ContactForm.Person_1.FullName}";
                    check_list_partner_2.Text = $"ת.ז: {client.ContactForm.Person_2.Id}, שם: {client.ContactForm.Person_2.FullName}";

                    check_list_DataGrid.ItemsSource = client.CheckListRows;
                    checkListSearchedClient = client;
                }
                else
                {
                    check_list_not_found_placement.Text = "הלקוח לא נמצא";
                }
            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "הקובץ לקוחות לא נמצא, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }
        private void check_list_DataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            try
            {
                IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());

                if (e.EditAction == DataGridEditAction.Commit && checkListSearchedClient != null)
                {
                    checkListSearchedClient.CheckListRows[e.Row.GetIndex()] = e.Row.DataContext as CheckListRow;
                    
                    Type checkListRowType = typeof(CheckListRow);
                    checkListRowType.GetProperty(e.Column.SortMemberPath).SetValue(checkListSearchedClient.CheckListRows[e.Row.GetIndex()], ((TextBox)e.EditingElement).Text);

                    clientDAO.UpdateClient(checkListSearchedClient);
                }

            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "הקובץ לקוחות לא נמצא, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }

        private void status_DataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            try
            {
                IClientDAO clientDAO = new ClientFileDAO(new ConfigMgr());

                if (e.EditAction == DataGridEditAction.Commit)
                {
                    Client client = e.Row.DataContext as Client;
                    var comboBox = e.EditingElement as ComboBox;
                    client.StatusValue = comboBox.SelectedValue.ToString();
                    if (!Client.ClientStatusEnums.Any(x => x.Value == client.StatusValue))
                    {
                        throw new ArgumentException("not valid status");
                    }

                    clientDAO.UpdateClient(client);
                }
            }
            catch (FileNotFoundException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "הקובץ לקוחות לא נמצא, בדוק בהגדרות מערכת את ההגדרות שלך";
            }
            catch (ArgumentException)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "סטטוס לא קיים במערכת, השינוי לא נשמר אנא נסה סטטוס אחר";
            }
            catch (Exception)
            {
                error_snack_bar.IsActive = true;
                error_message_snack_bar.Content = "שגיאה כללית במערכת, אנא נסה שוב";
            }
        }

        private void clients_status_DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Client client = row.DataContext as Client;
            GenerateFormsForExistClient(client);

            Dispatcher.BeginInvoke((Action)(() =>
            {
                isSourceFromOtherTab = true;
                tabs_control.SelectedIndex = 0;
            }));
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
                CaseOwnerEnum = ContactFormPerson.GetOwnerKey(case_owner.SelectedValue.ToString()),
                CaseInfo = new CaseDetails()
                {
                    CaseTypeEnum = CaseDetails.GetCaseTypeKey(case_type.SelectedValue.ToString()),
                    OpenDate = DateTime.Now,
                    DecisionDate = case_decision_date.SelectedDate ?? new DateTime(),
                    CaseReceivementDate = receiving_case_date.SelectedDate ?? new DateTime(),
                    PublishDays = publish_days.Text,
                    CourtName = court_name.Text,
                    CaseNum = case_num.Text,
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

        private void ClearNewClientFormTab()
        {
            case_owner.SelectedIndex = -1;

            case_type.SelectedIndex = -1;
            case_decision_date.SelectedDate = null;
            receiving_case_date.SelectedDate = null;
            publish_days.Clear();
            court_name.Clear();
            case_num.Clear();
            judge_name.Clear();

            fullName_1.Clear();
            id_1.Clear();
            birth_date_1.SelectedDate = null;

            fullName_2.Clear();
            id_2.Clear();
            birth_date_2.SelectedDate = null;

            partnership_end.SelectedDate = null;
            partnership_start.SelectedDate = null;
            work_essence.Text = "ביצוע דוח איזון המשאבים שצברו הצדדים בתקופת החיים המשותפים כפי שיועברו על ידי הצדדים.";
        }

        private void GenerateFormsForExistClient(Client client)
        {
            case_owner.SelectedIndex = (int)client.ContactForm.CaseOwnerEnum;

            case_type.SelectedIndex = (int)client.ContactForm.CaseInfo.CaseTypeEnum;
            case_decision_date.SelectedDate = client.ContactForm.CaseInfo.DecisionDate;
            receiving_case_date.SelectedDate = client.ContactForm.CaseInfo.CaseReceivementDate;
            publish_days.Text = client.ContactForm.CaseInfo.PublishDays;
            court_name.Text = client.ContactForm.CaseInfo.CourtName;
            case_num.Text = client.ContactForm.CaseInfo.CaseNum;
            judge_name.Text = client.ContactForm.CaseInfo.JudgeName;

            fullName_1.Text = client.ContactForm.Person_1.FullName;
            id_1.Text = client.ContactForm.Person_1.Id;
            birth_date_1.SelectedDate = client.ContactForm.Person_1.BirthDate;

            fullName_2.Text = client.ContactForm.Person_2.FullName;
            id_2.Text = client.ContactForm.Person_2.Id;
            birth_date_2.SelectedDate = client.ContactForm.Person_2.BirthDate;

            partnership_end.SelectedDate = client.ContactForm.PartnershipEndDate;
            partnership_start.SelectedDate = client.ContactForm.PartnershipStartDate;
            work_essence.Text = client.ContactForm.WorkEssence;
        }

        private void AddNewClient(ContactFormPerson contactFormDetails, List<CheckListRow> checkListRows)
        {
            Client client = new Client()
            {
                StatusValue = Client.ClientStatusEnums[ClientStatus.YetToBegin],
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
