using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginApplication
{
    public partial class Login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if(ReadCookie() == "Success")
            {
                Server.Transfer("Home.aspx");
            }
        }
        protected void login_Click(object sender, EventArgs e)
        {

            if(txtUser.Value != "" && PasswordLogin.Value != "")
            {
                Server.Transfer("Home.aspx");
                WriteCookie("Success");

            }
            else
            {
                Label1.Text = "Cannot Login";
             
            }
        }        

        private void WriteCookie(string loginStatus)
        {
            HttpCookie userCookie = new HttpCookie("UserSetting");   
            userCookie.Value = loginStatus;
            userCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(userCookie);

        }

        private string ReadCookie()
        {
            HttpCookie userCookie = Request.Cookies["UserSetting"];
            if(userCookie == null)
            {
                return "";
            }
            return userCookie.Value;
        }


    }
}