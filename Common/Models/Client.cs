using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Client
    {
        public ContactFormPerson ContactForm { get; set; }
        public List<CheckListRow> CheckListRows { get; set; }
    }
}
