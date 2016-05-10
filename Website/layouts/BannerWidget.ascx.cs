namespace Website.layouts
{
    using System;

    public partial class BannerWidget : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var datasource = Attributes["sc_datasource"];

            if (!string.IsNullOrEmpty(datasource))
            {
                BannerCtrl.DataSource = datasource;
            }
        }
    }
}