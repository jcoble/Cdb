using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Cdb.Tickets.BusinessObjects
{
    public class User : PermissionPolicyUser
    {
        public User(Session session) : base(session)
        { }

        [Association("TicketWatchers-Watchers")]
        public XPCollection<Ticket> TicketWatchers
        {
            get
            {
                return GetCollection<Ticket>(nameof(TicketWatchers));
            }
        }
    }
}
