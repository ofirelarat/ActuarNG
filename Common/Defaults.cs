using Common.Models;
using System.Collections.Generic;

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
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "הלוואות מהקופות"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "דוחות שנתיים-בשנה של מועד הקרע"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "דוחות יתרות-סמוך למועד הקרע"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "האם קיימת פנסיה תקציבית?"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "אם קיימת פנסיה תקציבית-דוח תקופות שירות"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "אם קיימת פנסיה תקציבית-דוח יתרות מענקי פרישה ממעסיק"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "האם קיימת פנסיה ותיקה?"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "אם קיימת פנסיה ותיקה-דוח הפקדות מהקרן"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "אם קיימת פנסיה ותיקה-דוח שנתי קודם למועד הקרע"
                    }
                    ,new CheckListRow()
                    {
                        Type = "קופות קרנות/ פוליסות",
                        Name = "(אם קיימת פנסיה ותיקה-דוח זכויות מהקרן(שכר קובע + גובה פנסיה"
                    }
                    ,new CheckListRow()
                    {
                        Type = "חשבון בנק",
                        Name = "מספר חשבון בנק"
                    }
                    ,new CheckListRow()
                    {
                        Type = "חשבון בנק",
                        Name = "תדפיס תנועות חשבון בנק לחודש הקרע",
                    }
                    ,new CheckListRow()
                    {
                        Type = "חשבון בנק",
                        Name = "דוח יתרות כולל סמוך למועד הקרע",
                    }
                };
            }
        }
    }
}
