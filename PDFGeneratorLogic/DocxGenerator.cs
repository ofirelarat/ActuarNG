using Common.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using SettingMgr;
using System;

namespace PDFGeneratorLogic
{
    public class DocxGenerator
    {
        const string sourceFile = @"./resources/new_person_contact_form_template.docx";

        private string destFile;

        private ContactFormPerson contactFormPerson;
        private string targetPath = new ConfigMgr().GetDestenationPath();
        //private readonly string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public DocxGenerator(ContactFormPerson contactForm)
        {
            destFile = System.IO.Path.Combine(targetPath, $"טופס_הזמנת_עבודה_{contactForm.Person_1.Id}.docx");
            contactFormPerson = contactForm;
        }

        public void GenerateNewPersonWord()
        {
            WordprocessingDocument wordprocessingDocument;
      
            CopyTemplateFile();

            wordprocessingDocument = WordprocessingDocument.Open(destFile, true);
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

            var xml = body.OuterXml;
            string tokenziedXML = TokenizeDocs(xml);

            body.InnerXml = tokenziedXML;

            wordprocessingDocument.Close();
            wordprocessingDocument.Dispose();
        }

        private void CopyTemplateFile()
        {           
            // creates the dir if not exists
            System.IO.Directory.CreateDirectory(targetPath);

            System.IO.File.Copy(sourceFile, destFile, true);
        }

        private string TokenizeDocs(string xmlBody)
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
    }
}
