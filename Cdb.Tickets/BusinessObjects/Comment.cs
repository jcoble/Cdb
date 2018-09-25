using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace Cdb.Tickets.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("UserComment")]
    public class Comment : BaseObject
    {
        public Comment(Session session) : base(session)
        { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            DateCreated = DateTime.Now;
        }

        Ticket ticket;
        DateTime dateCreated;
        string userComment;
        [Size(2048)]
        public string UserComment
        {
            get => userComment;
            set => SetPropertyValue(nameof(UserComment), ref userComment, value);
        }


        public DateTime DateCreated
        {
            get => dateCreated;
            set => SetPropertyValue(nameof(DateCreated), ref dateCreated, value);
        }

        
        [Association("Ticket-Comments")]
        public Ticket Ticket
        {
            get => ticket;
            set => SetPropertyValue(nameof(Ticket), ref ticket, value);
        }
    }
}
