using System.Collections.Generic;

namespace Common.Models
{
    public enum ClientStatus
    {
        Canceled,
        YetToBegin,
        DocumentsNotYetCompleted,
        DraftPreparedAndNotYetSentToParties,
        DraftPreparedAndSentToParties,
        ClarificationAfterDraft,
        FinalOpinion,
        ClarificationAfterFinalOpinion,
        Close
    }

    public class Client
    {
        public static Dictionary<ClientStatus, string> clientStatusEnums = new Dictionary<ClientStatus, string>()
        {
            { ClientStatus.Canceled, "בוטל" },
            { ClientStatus.YetToBegin, "טרם החל" },
            { ClientStatus.DocumentsNotYetCompleted, "טרם הושלמו מסמכים" },
            { ClientStatus.DraftPreparedAndNotYetSentToParties, "הווכנה טיוטה וטרם נשלחה לצדדים" },
            { ClientStatus.DraftPreparedAndSentToParties, "הוכנה טיוטה - נשלחה לצדדים" },
            { ClientStatus.ClarificationAfterDraft, "שאלות הבהרה לאחר טיוטה" },
            { ClientStatus.FinalOpinion, "חוות דעת סופית" },
            { ClientStatus.ClarificationAfterFinalOpinion, "שאלות הבהרה לאחר חוות דעת סופית" },
            { ClientStatus.Close, "סגור" },
        };

        public string StatusValue{ get; set; }
        public ContactFormPerson ContactForm { get; set; }
        public List<CheckListRow> CheckListRows { get; set; }
    }
}