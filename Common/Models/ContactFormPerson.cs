using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ContactFormPerson
    {
        public CaseDetails CaseInfo { get; set; }
        public Person Person_1 { get; set; }
        public Person Person_2 { get; set; }
        public DateTime PartnershipStartDate { get; set; }
        public DateTime PartnershipEndDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
