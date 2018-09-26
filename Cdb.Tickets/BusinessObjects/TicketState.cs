using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace Cdb.Tickets.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("State")]
    public class TicketState : XPObject
    {
        public TicketState(Session session) : base(session)
        { }

        string state;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string State
        {
            get => state;
            set => SetPropertyValue(nameof(State), ref state, value);
        }

        [Association("TicketState-Tickets")]
        public XPCollection<Ticket> Tickets
        {
            get
            {
                return GetCollection<Ticket>(nameof(Tickets));
            }
        }
    }
}
