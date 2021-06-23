using Common.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using SettingMgr;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PDFGeneratorLogic
{
    public enum FormsType
    {
        ContactForm,
        EconomyDetails,
        EmpowerForm,
        FullForm
    }

    public class DocxGenerator
    {
        private ContactFormPerson contactFormPerson;
        private string targetPath;
        //private readonly string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public DocxGenerator(ContactFormPerson contactForm, ConfigMgr configMgr)
        {
            contactFormPerson = contactForm;
            targetPath = configMgr.GetDestenationPath();
        }

        public void GenerateNewForm(FormsType fileType)
        {
            string sourceFile = GetSourceFileName(fileType);
            string destFile = GetDestFileName(fileType);

            WordprocessingDocument wordprocessingDocument;

            CopyTemplateFile(sourceFile, destFile);

            wordprocessingDocument = WordprocessingDocument.Open(destFile, true);
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

            var xml = body.OuterXml;
            string tokenziedXML = TokenizeNewFormDoc(xml);

            body.InnerXml = tokenziedXML;

            wordprocessingDocument.Close();
            wordprocessingDocument.Dispose();
        }

        public void OpenDocumentFile(FormsType fileType)
        {
            string destFile = GetDestFileName(fileType);

            Task.Run(() =>
            {
                Process wordProcess = new Process();
                wordProcess.StartInfo.FileName = destFile;
                wordProcess.StartInfo.UseShellExecute = true;
                wordProcess.Start();
            });
        }

        private void CopyTemplateFile(string sourceFilePath, string destFilePath)
        {           
            // creates the dir if not exists
            System.IO.Directory.CreateDirectory(targetPath);

            System.IO.File.Copy(sourceFilePath, destFilePath, true);
        }

        private string TokenizeNewFormDoc(string xmlBody)
        {
            string generatedHTML = xmlBody
                                            .Replace($"document_creation_date", contactFormPerson.CreationDate.ToShortDateString())
                                            .Replace($"full_name", contactFormPerson.Person_1.FullName)
                                            .Replace($"id_1", contactFormPerson.Person_1.Id)
                                            .Replace($"id_2", contactFormPerson.Person_2.Id)
                                            .Replace($"name_1", contactFormPerson.Person_1.FullName)
                                            .Replace($"name_2", contactFormPerson.Person_2.FullName)
                                            .Replace($"birth_date_1", contactFormPerson.Person_1.BirthDate.ToShortDateString())
                                            .Replace($"birth_date_2", contactFormPerson.Person_2.BirthDate.ToShortDateString())
                                            .Replace($"partnership_start", contactFormPerson.PartnershipStartDate.ToShortDateString())
                                            .Replace($"partnership_end", contactFormPerson.PartnershipEndDate.ToShortDateString())
                                            .Replace($"work_essence", contactFormPerson.WorkEssence);

            return generatedHTML;
        }

        private string GetSourceFileName(FormsType fileType)
        {
            switch (fileType)
            {
                case FormsType.ContactForm:
                    return @"./resources/new_person_contact_form_template.docx";
                case FormsType.EconomyDetails:
                    return @"./resources/new_person_economy_details_form_template.docx";
                case FormsType.EmpowerForm:
                    return @"./resources/new_person_empower_form_template.docx";
                case FormsType.FullForm:
                    return @"./resources/new_person_full_form_template.docx";
                default:
                    throw new FileNotFoundException($"file type {fileType} not exist");
            }
        }

        private string GetDestFileName(FormsType fileType)
        {
            switch (fileType)
            {
                case FormsType.ContactForm:
                    return Path.Combine(targetPath, $"טופס_הזמנת_עבודה_{contactFormPerson.Person_1.Id}.docx");
                case FormsType.EconomyDetails:
                    return Path.Combine(targetPath, $"טופס_הזנת_נתונים_{contactFormPerson.Person_1.Id}.docx");
                case FormsType.EmpowerForm:
                    return Path.Combine(targetPath, $"טופס_יפוי_כוח_{contactFormPerson.Person_1.Id}.docx");
                case FormsType.FullForm:
                    return Path.Combine(targetPath, $"טופס_לקוח_חדש_{ contactFormPerson.Person_1.Id}.docx");
                default:
                    throw new FileNotFoundException($"file type {fileType} not exist");
            }
        }
    }
}
