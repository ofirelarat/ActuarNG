using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Models
{
    public enum Owner
    {
        Omer,
        Natali,
        Tomer,
        Avi,
        Leonid,
        Yuval,
        Ela,
        Chen,
        Lior,
        Oz,
        Orel,
        Ofir
    }

    public class ContactFormPerson
    {
        private static Dictionary<Owner, string> ownerValues = new Dictionary<Owner, string>()
        {
            { Owner.Omer, "עומר" },
            { Owner.Natali, "נטלי" },
            { Owner.Tomer, "תומר" },
            { Owner.Avi, "אבי" },
            { Owner.Leonid, "לאוניד" },
            { Owner.Yuval, "יובל" },
            { Owner.Ela, "אלה" },
            { Owner.Chen, "חן" },
            { Owner.Lior, "ליאור" },
            { Owner.Oz, "עוז" },
            { Owner.Orel, "אוראל" },
            { Owner.Ofir, "אופיר" }
        };

        public static string[] Owners = ownerValues.Select(x => x.Value).ToArray();

        public static Func<string, Owner> GetOwnerKey = (string value) => ownerValues.FirstOrDefault(x => x.Value == value).Key;

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
