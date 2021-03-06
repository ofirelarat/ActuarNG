using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Models
{
    public enum CaseType
    {
        Court,
        RabbinicalCourt,
        MediationPurpose,
        ForHusbandPurposeOnly,
        ForWifePurposeOnly,
        Other
    }

    public class CaseDetails
    {
        private static Dictionary<CaseType, string> caseTypeValue = new Dictionary<CaseType, string>()
        {
            { CaseType.Court, "בית משפט" },
            { CaseType.RabbinicalCourt, "בית משפט רבני" },
            { CaseType.MediationPurpose, "בהסכמה למטרת גישור" },
            { CaseType.ForHusbandPurposeOnly, "למטרת הבעל בלבד" },
            { CaseType.ForWifePurposeOnly, "למטרת האישה בלבד" },
        };

        public static string[] CaseTypes = caseTypeValue.Select(x => x.Value).ToArray();
        public static Func<string, CaseType> GetCaseTypeKey = (string value) => caseTypeValue.FirstOrDefault(x => x.Value == value).Key;

        public DateTime OpenDate { get; set; }
        public CaseType CaseTypeEnum { get; set; }
        public string CaseTypeValue { get { return caseTypeValue[CaseTypeEnum]; } }
        public DateTime DecisionDate { get; set; }
        public DateTime CaseReceivementDate { get; set; }
        public string PublishDays { get; set; }
        public string CourtName { get; set; }
        public string CaseNum { get; set; }
        public string JudgeName { get; set; }
    }
}
