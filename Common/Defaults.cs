using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Defaults
    {
        public static List<CheckListRow> CheckListDefaultCollection
        {
            get
            {
                return new List<CheckListRow>() {
                    new CheckListRow()
                    {
                        Type = "כללי",
                        Name = "שם"
                    },
                    new CheckListRow()
                    {
                        Type = "כללי",
                        Name = "טופס התקשרות מלא, חתום וקריא",
                        Person_1_value = "לא",
                        Person_2_value = "לא"
                    },
                    new CheckListRow()
                    {
                        Type = "כללי",
                        Name = "תשלום ומקדמה ?",
                        Person_1_value = "לא",
                        Person_2_value = "לא"
                    }
                    ,new CheckListRow()
                    {
                        Type = "כללי",
                        Name = "צילום ת.זהות",
                        Person_1_value = "לא",
                        Person_2_value = "לא"
                    }
                    ,new CheckListRow()
                    {
                        Type = "כללי",
                        Name = "טופס מסלקה מלא חתום וקריא"
                    }
                    ,new CheckListRow()
                    {
                        Type = "כללי",
                        Name = "נתוני מסלקה"
                    }
                    ,new CheckListRow()
                    {
                        Type = "כללי",
                        Name = "ייפוי כוח - ב 2"
                    }
                    ,new CheckListRow()
                    {
                        Type = "זכויות ממקום עבודה",
                        Name = "תלושי שכר - 3 חודישם לפני מועד הקרע"
                    }
                    ,new CheckListRow()
                    {
                        Type = "זכויות ממקום עבודה",
                        Name = "יתרת ימי חופשה"
                    }
                    ,new CheckListRow()
                    {
                        Type = "זכויות ממקום עבודה",
                        Name = "יתרת ימי מחלה-לעובד במגזר הציבורי בלבד"
                    }
                    ,new CheckListRow()
                    {
                        Type = "זכויות ממקום עבודה",
                        Name = "הלוואות בתלוש שכר"
                    }
                };
            }
        }
    }
}
