﻿<%@ Application Language="C#" %>

<script runat="server">

    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    void Application_Start(object sender, EventArgs e)
    {
        //JobScheduler.Start();
        log4net.Config.XmlConfigurator.Configure();
        log.Info("Starting the Application!!!!!!!");
    }

    void Application_End(object sender, EventArgs e)
    {
        //JobScheduler.Start();
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
