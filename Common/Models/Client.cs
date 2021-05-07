using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Common.Models
{
    public enum ClientStatus
    {
        NewClient,
        WaitingForReservation,
        ReservationSent,
        FirstPaymentDone,
        WaitingForDecision,
        Close
    }

    public class Client
    {
        public static Dictionary<ClientStatus, string> clientStatusEnums = new Dictionary<ClientStatus, string>()
        {
            { ClientStatus.NewClient, "לקוח חדש" },
            { ClientStatus.WaitingForReservation, "ממתין לטופס הזמנת עבודה" },
            { ClientStatus.ReservationSent, "קיבל טופס הזמנת עבודה" },
            { ClientStatus.FirstPaymentDone, "שילם מקדמה" },
            { ClientStatus.WaitingForDecision, "ממתין להחלטה" },
            { ClientStatus.Close, "סגור" },
        };

        public string StatusValue{ get; set; }
        public ContactFormPerson ContactForm { get; set; }
        public List<CheckListRow> CheckListRows { get; set; }
    }
}