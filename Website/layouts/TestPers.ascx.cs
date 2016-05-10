namespace Website.layouts
{
    using System;

    public partial class TestPers : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var datasource = Attributes["sc_datasource"];

            TextCtrl.DataSource = TitleCtrl.DataSource = Sitecore.Context.Item.ID.ToString();

            if (!string.IsNullOrEmpty(datasource))
            {
                TextCtrl.DataSource = TitleCtrl.DataSource = datasource;
            }
            // Put user code to initialize the page here
        }
    }
}