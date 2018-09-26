using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace Cdb.Tickets.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("PriorityName")]
    public class Priority : XPObject
    {
        public Priority(Session session) : base(session) { }
        string priorityName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PriorityName
        {
            get => priorityName;
            set => SetPropertyValue(nameof(PriorityName), ref priorityName, value);
        }

        [Association("Priority-Tickets")]
        public XPCollection<Ticket> Tickets
        {
            get
            {
                return GetCollection<Ticket>(nameof(Tickets));
            }
        }
    }
}
