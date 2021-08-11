using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sample_keycloak_webform
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // redirect page after authenticated
            string authenticatedPage = System.Configuration.ConfigurationManager.AppSettings["authenticatedUri"];

            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                // new AuthenticationProperties { RedirectUri = "/" },
                new AuthenticationProperties { RedirectUri = authenticatedPage },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
    }
}