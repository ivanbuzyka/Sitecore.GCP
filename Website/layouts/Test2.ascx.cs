namespace Website.layouts
{
    using System;

    public partial class Test2 : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var datasource = Attributes["sc_datasource"];

            TextCtrl.DataSource = TitleCtrl.DataSource = Sitecore.Context.Item.ID.ToString();

            if (!string.IsNullOrEmpty(datasource))
            {
                TextCtrl.DataSource = TitleCtrl.DataSource = datasource;
            }
        }
    }
}