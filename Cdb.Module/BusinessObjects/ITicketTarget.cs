using Cdb.Tickets.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdb.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class ITicketDefault : ITicket
    {
        public Ticket Ticket { get; set; }
    }

}
