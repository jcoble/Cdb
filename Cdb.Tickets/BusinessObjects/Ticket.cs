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
        Comment comment;
        PermissionPolicyUser userReporter;
        DateTime sourceDate;
        DateTime reportDate;
        DateTime errorDate;
        DateTime ticketDate;
        Priority priority;
        TicketState ticketState;
        Client client;
        TicketType ticketType;
        //Person assignee;

        public Ticket(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            ReportDate = DateTime.Now;
            //userReporter = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUser);
            userReporter = Session.FindObject<PermissionPolicyUser>(new BinaryOperator("UserName", SecuritySystem.CurrentUserName));
        }

        
        public PermissionPolicyUser UserReporter
        {
            get => userReporter;
            set => SetPropertyValue(nameof(UserReporter), ref userReporter, value);
        }
        //[Association("Person-TicketReporter")]
        //public Person Reporter
        //{
        //    get => reporter;
        //    set => SetPropertyValue(nameof(Reporter), ref reporter, value);
        //}

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

        //[Association("Person-TicketAssignee")]
        //public Person Assignee
        //{
        //    get => assignee;
        //    set => SetPropertyValue(nameof(Assignee), ref assignee, value);
        //}

        //[Association]
        //public XPCollection<Person> Watchers
        //{
        //    get
        //    {
        //        return GetCollection<Person>(nameof(Watchers));
        //    }
        //}

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
    //public interface ITicketType
    //{
    //    TicketType Type { get; set; }
    //}

    ////[DomainComponent]
    //public interface IPriority 
    //{
    //    Priority PriorityName { get; set; }
    //}



}
