﻿using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace Cdb.Tickets.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("FullName")]
    public class Person : BaseObject
    {
        public Person(Session session) : base(session)
        { }

        string firstName;
        string lastName;

        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        [NonPersistent]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }


        [Association("Person-TicketReporter")]
        public XPCollection<Ticket> TicketReporter
        {
            get
            {
                return GetCollection<Ticket>(nameof(TicketReporter));
            }
        }

        [Association("Person-TicketAssignee")]
        public XPCollection<Ticket> TicketAssignee
        {
            get
            {
                return GetCollection<Ticket>(nameof(TicketAssignee));
            }
        }

        [Association]
        public XPCollection<Ticket> TicketWatchers
        {
            get
            {
                return GetCollection<Ticket>(nameof(TicketWatchers));
            }
        }
    }
}