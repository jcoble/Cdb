using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace Cdb.Tickets.BusinessObjects
{

    public interface ITicket
    {
        Ticket Ticket { get; set; }
    }

    [DefaultClassOptions]
    [DefaultProperty("Client")]
    public class Ticket : XPObject
    {
        User assignee;
        User reporter;
        DateTime sourceDate;
        DateTime reportDate;
        DateTime errorDate;
        DateTime ticketDate;
        Priority priority;
        TicketState ticketState;
        Client client;
        TicketType ticketType;

        public Ticket(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            ReportDate = DateTime.Now;
            //userReporter = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUser);
            reporter = Session.FindObject<User>(new BinaryOperator("UserName", SecuritySystem.CurrentUserName));
        }


        public User Reporter
        {
            get => reporter;
            set => SetPropertyValue(nameof(Reporter), ref reporter, value);
        }

        [Association("TicketType-Tickets")]
        public TicketType TicketType
        {
            get => ticketType;
            set => SetPropertyValue(nameof(TicketType), ref ticketType, value);
        }

        [Association("TicketState-Tickets")]
        public TicketState TicketState
        {
            get => ticketState;
            set => SetPropertyValue(nameof(TicketState), ref ticketState, value);
        }

        public DateTime TicketDate
        {
            get => ticketDate;
            set => SetPropertyValue(nameof(TicketDate), ref ticketDate, value);
        }

        public DateTime ErrorDate
        {
            get => errorDate;
            set => SetPropertyValue(nameof(ErrorDate), ref errorDate, value);
        }

        [Association("Client-Tickets")]
        public Client Client
        {
            get => client;
            set => SetPropertyValue(nameof(Client), ref client, value);
        }

        [Association("Priority-Tickets")]
        public Priority Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        public DateTime ReportDate
        {
            get => reportDate;
            set => SetPropertyValue(nameof(ReportDate), ref reportDate, value);
        }

        public DateTime SourceDate
        {
            get => sourceDate;
            set => SetPropertyValue(nameof(SourceDate), ref sourceDate, value);
        }


        public User Assignee
        {
            get => assignee;
            set => SetPropertyValue(nameof(Assignee), ref assignee, value);
        }


        [Association("TicketWatchers-Watchers")]
        public XPCollection<User> Watchers
        {
            get
            {
                return GetCollection<User>(nameof(Watchers));
            }
        }

        [Association("Ticket-Comments"), DevExpress.Xpo.Aggregated]
        public XPCollection<Comment> Comments
        {
            get
            {
                return GetCollection<Comment>(nameof(Comments));
            }
        }
    }
    public interface IPerson
    {
        Person Person { get; set; }
    }
}
