using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguridad.Controls
{
    public partial class Alphalink : System.Web.UI.UserControl
    {
        string[] letters = { "Todos", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
					"L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
					"W", "X", "Y", "Z"};

        private string selectedLetter;
        private int selectedIndex;

        private void Page_Load()
        {
            if (ViewState["selectedLetter"] == null)
            {
                selectedLetter = "Todos";
                ViewState["selectedLetter"] = "Todos";
            }
        }

        public void Page_PreRender()
        {                        
            __theAlphalink.DataSource = letters;
            __theAlphalink.DataBind();
        }

        public string Letter
        {
            get
            {
                return ViewState["selectedLetter"].ToString();
            }
            set
            {                
                ViewState["selectedLetter"] = value;
            }
        }

        protected void Select(object sender, CommandEventArgs e)
        {
            selectedLetter = e.CommandArgument.ToString();
            ViewState["selectedLetter"] = e.CommandArgument.ToString();
        }

        protected void DisableSelectedLink(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lb = (LinkButton)e.Item.Controls[1];
            if (lb.Text == Letter)
                lb.Enabled = false;
        }
    }
}