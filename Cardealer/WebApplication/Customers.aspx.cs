using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using System.Collections.ObjectModel;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ObservableCollection<Private> people = Cardealer.Instance.PrivateCustomers;
         
            if (!IsPostBack)
            {
                repPeople.DataSource = people;
                repPeople.DataBind();
            }
        }
    }
}