using System;
using System.IO;
using System.Linq;
using System.Web;
using BookWidget;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Samples.Common;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Data.OA;

namespace SitefinityWebApp
{
    public class Global : HttpApplication
    {
        private const string SamplesThemeName = "SamplesTheme";
        private const string SamplesThemePath = "~/App_Data/Sitefinity/WebsiteTemplates/Samples/App_Themes/Samples";

        private const string SamplesTemplateId = "03b770d0-c143-4aa5-a3c0-2891bfb31f13";
        private const string SamplesTemplateName = "SamplesMasterPage";
        private const string SamplesTemplatePath = "~/App_Data/Sitefinity/WebsiteTemplates/Samples/App_Master/Samples.master";

        private const string BookWidgetPageId = "39EE9DEA-7C48-483C-ADD5-ED8F1BD5E1BB";
        private const string BookWidgetPageName = "Book Sample";

        protected void Application_Start(object sender, EventArgs e)
        {
            Telerik.Sitefinity.Abstractions.Bootstrapper.Initializing += new EventHandler<Telerik.Sitefinity.Data.ExecutingEventArgs>(Bootstrapper_Initializing);
            Telerik.Sitefinity.Abstractions.Bootstrapper.Initialized += new EventHandler<Telerik.Sitefinity.Data.ExecutedEventArgs>(Bootstrapper_Initialized);
        }

        protected void Bootstrapper_Initializing(object sender, Telerik.Sitefinity.Data.ExecutingEventArgs args)
        {
            if (args.CommandName == "RegisterRoutes")
            {

            }
        }

        protected void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs args)
        {
            if (args.CommandName == "Bootstrapped")
            {
                SystemManager.RunWithElevatedPrivilegeDelegate worker = new SystemManager.RunWithElevatedPrivilegeDelegate(CreateSample);
                SystemManager.RunWithElevatedPrivilege(worker);
            }
        }

        private void CreateSample(object[] args)
        {            
            SampleUtilities.CreateUsersAndRoles();

            SampleUtilities.RegisterToolboxWidget("BookWidget", typeof(Book), "Samples");
            SampleUtilities.RegisterTheme(SamplesThemeName, SamplesThemePath);
            SampleUtilities.RegisterTemplate(new Guid(SamplesTemplateId), SamplesTemplateName, SamplesTemplateName, SamplesTemplatePath, SamplesThemeName);

            SampleUtilities.UploadImages(HttpRuntime.AppDomainAppPath + "Images", "BookImages");

            var result = SampleUtilities.CreatePage(new Guid(BookWidgetPageId), BookWidgetPageName, true);

            if (result)
            {
                SampleUtilities.SetTemplateToPage(new Guid(BookWidgetPageId), new Guid(SamplesTemplateId));

                Book myWidget = new Book();
                myWidget.AlbumTitle = "BookImages";

                SampleUtilities.AddControlToPage(new Guid(BookWidgetPageId), myWidget, "Content", "BookWidget");
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}