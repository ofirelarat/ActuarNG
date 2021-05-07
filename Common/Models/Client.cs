﻿using System;
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
        public static List<string> ClientStatuses { get { return clientStatusEnums.Select(x => x.Value).ToList(); } }

        private static Dictionary<ClientStatus, string> clientStatusEnums = new Dictionary<ClientStatus, string>()
        {
            { ClientStatus.NewClient, "לקוח חדש" },
            { ClientStatus.WaitingForReservation, "ממתין לטופס הזמנת עבודה" },
            { ClientStatus.ReservationSent, "קיבל טופס הזמנת עבודה" },
            { ClientStatus.FirstPaymentDone, "שילם מקדמה" },
            { ClientStatus.WaitingForDecision, "ממתין להחלטה" },
            { ClientStatus.Close, "סגור" },
        };

        public ClientStatus StatusEnum { get; set; }
        public string StatusValue{ get { return clientStatusEnums[StatusEnum]; } set { StatusEnum = clientStatusEnums.First(x => x.Value == value).Key; } }
        public ContactFormPerson ContactForm { get; set; }
        public List<CheckListRow> CheckListRows { get; set; }
    }
}
