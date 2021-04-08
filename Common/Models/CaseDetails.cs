using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public enum CaseType
    {

    }

    public class CaseDetails
    {
        public DateTime OpenDate { get; set; }
        public CaseType CaseTypeValue { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime CaseReceivementDate { get; set; }
        public string PublishDays { get; set; }
        public string CourtName { get; set; }
        public int CaseNum { get; set; }
        public string JudgeName { get; set; }
    }
}
