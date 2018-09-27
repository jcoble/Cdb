using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cdb.Notifications.BusinessObjects;
using Cdb.Tickets.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.Entity.Model.Metadata;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Cdb.Notifications.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SaveTicketModificationController : ViewController
    {
        public SaveTicketModificationController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            View.ObjectSpace.Committed += ObjectSpace_Committed;
            View.ObjectSpace.Committing += ObjectSpace_Committing;
            // Perform various tasks depending on the target View.
        }

        private void ObjectSpace_Committing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IObjectSpace os = (IObjectSpace)sender;
            XPObjectSpace objectSpace = (XPObjectSpace)sender;

            foreach (var ticket in objectSpace.ModifiedObjects.OfType<Ticket>())
            {
                //Saving New
                if (objectSpace.IsNewObject(ticket))
                {
                    Console.WriteLine("New Object");
                }
                else if (ticket.IsDeleted) //Deleting
                {
                    Console.WriteLine("IsDeleting Object");
                }
                else  //Updating
                {
                    Console.WriteLine("IsModified Object");
                }
            }
        }

        private void ObjectSpace_Committed(object sender, EventArgs e)
        {
            string s = "";
            IObjectSpace os = (IObjectSpace)sender;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            
            base.OnDeactivated();
        }
    }
}
