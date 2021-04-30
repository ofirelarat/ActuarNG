using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public enum Owner
    {
        Daniel,
        Yosi,
        Avi,
        Sharon
    }

    public class ContactFormPerson
    {
        private Dictionary<Owner, string> ownerValues = new Dictionary<Owner, string>()
        {
            { Owner.Daniel, "דניאל" },
            { Owner.Yosi, "יוסי" },
            { Owner.Avi, "אבי" },
            { Owner.Sharon, "שרון" }
        };

        public Owner CaseOwnerEnum { get; set; }
        public string CaseOwnerValue { get { return ownerValues[CaseOwnerEnum]; } }
        public CaseDetails CaseInfo { get; set; }
        public Person Person_1 { get; set; }
        public Person Person_2 { get; set; }
        public DateTime PartnershipStartDate { get; set; }
        public DateTime PartnershipEndDate { get; set; }
        public string WorkEssence { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
