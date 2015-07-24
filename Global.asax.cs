using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AdminPanel;
using System.Collections;

namespace AdminPanel
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //AuthConfig.RegisterOpenAuth();
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Inbox", "Inbox", "~/Page_Inbox.aspx");
            routes.MapPageRoute("Outbox", "Outbox", "~/Page_Outbox.aspx");
            routes.MapPageRoute("ExceptionLogging", "ExceptionLogging", "~/Page_ExceptionLogging.aspx");
            routes.MapPageRoute("CleanOldData", "CleanOldData", "~/Page_CleanData.aspx");
            routes.MapPageRoute("NotOpenEnvelope", "NotOpenEnvelope", "~/Page_CanNotOpenEnvelope.aspx");
            routes.MapPageRoute("NotAnswered", "NotAnswered", "~/Page_NotAnsweredEnvelope.aspx");
            routes.MapPageRoute("FaultEnvelopes", "FaultEnvelopes", "~/Page_FaultEnvelope.aspx");
            routes.MapPageRoute("TaskManager", "TaskManager", "~/Page_InvoiceServerFunctions.aspx");
            routes.MapPageRoute("ApplicationResponse", "ApplicationResponse", "~/Page_ApplicationResponseRequest.aspx");
            routes.MapPageRoute("UserRoles", "UserRoles", "~/Page_UserRights.aspx");
            routes.MapPageRoute("CreateDocument", "CreateDocument", "~/Page_Documentation.aspx");
            routes.MapPageRoute("CreateInvoiceCustomer", "CreateInvoiceCustomer", "~/Page_SaveEInvoiceCustomer.aspx");
            routes.MapPageRoute("CreateLedgerCustomer", "CreateLedgerCustomer", "~/Page_SaveELedgerCustomer.aspx");
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            Session.Abandon();
            Session.Clear();

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        public void Session_End(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();

        }

        public static void ProcessRequest(HttpContext context)
        {
            foreach (DictionaryEntry item in context.Cache)
                context.Cache.Remove(item.Key as string);
            context.Response.ContentType = "text/html";
            context.Response.Write("Cache cleared.");
        }
    }
}
