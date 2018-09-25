using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace Cdb.Tickets.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("Company")]
    public class Client : BaseObject, IPerson
    {
        public Client(Session session) : base(session)
        { }

        string company;
        public string Company
        {
            get => company;
            set => SetPropertyValue(nameof(Company), ref company, value);
        }
        public Person Person { get; set; }

        [Association("Client-Tickets")]
        public XPCollection<Ticket> Tickets
        {
            get
            {
                return GetCollection<Ticket>(nameof(Tickets));
            }
        }

    }
}
