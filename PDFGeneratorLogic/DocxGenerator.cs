using Common.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using SettingMgr;
using System;

namespace PDFGeneratorLogic
{
    public class DocxGenerator
    {
        const string fileName = "test.docx";
        const string sourceFile = @"./resources/new_person_contact_form_template.docx";

        private string destFile;

        private ContactFormPerson contactFormPerson;
        private string targetPath = new ConfigMgr().GetDestenationPath();
        //private readonly string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public DocxGenerator(ContactFormPerson contactForm)
        {
            destFile = System.IO.Path.Combine(targetPath, fileName);
            contactFormPerson = contactForm;
        }

        public void GenerateNewPersonWord()
        {
            WordprocessingDocument wordprocessingDocument;
      
            CopyTemplateFile();

            wordprocessingDocument = WordprocessingDocument.Open(destFile, true);
            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

            var xml = body.OuterXml;
            string tokenziedXML = tokenizeDocs(xml);

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

        private string tokenizeDocs(string xmlBody)
        {
            string generatedHTML = xmlBody.Replace($"full_name", contactFormPerson.FullName)
                                            //.Replace($"id", contactFormPerson.Id)
                                            .Replace($"phone_number", contactFormPerson.PhoneNumber)
                                            .Replace($"email_address", contactFormPerson.EmailAddress)
                                            .Replace($"document_date", DateTime.Now.ToShortDateString());

            return generatedHTML;
        }
    }
}
