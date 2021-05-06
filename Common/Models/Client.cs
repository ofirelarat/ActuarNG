using System;
using System.Collections.Generic;
using System.Text;

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
        private Dictionary<ClientStatus, string> clientStatusEnums = new Dictionary<ClientStatus, string>()
        {
            { ClientStatus.NewClient, "לקוח חדש" },
            { ClientStatus.WaitingForReservation, "ממתין לטופס הזמנת עבודה" },
            { ClientStatus.ReservationSent, "קיבל טופס הזמנת עבודה" },
            { ClientStatus.FirstPaymentDone, "שילם מקדמה" },
            { ClientStatus.WaitingForDecision, "ממתין להחלטה" },
            { ClientStatus.Close, "סגור" },
        };

        public ClientStatus StatusEnum { get; set; }
        public string StatusValue{ get { return clientStatusEnums[StatusEnum]; } }
        public ContactFormPerson ContactForm { get; set; }
        public List<CheckListRow> CheckListRows { get; set; }
    }
}
