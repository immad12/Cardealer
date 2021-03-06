﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using System.Collections.ObjectModel;
using Domain.Vehicle;

namespace WebApplication
{
    /// <summary>
    /// Niels & Mette, Group 2
    /// Showing vehicles
    /// </summary>
    
    public partial class Vehicle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ObservableCollection<Car> cars = Cardealer.Instance.Cars;
         
            if (!IsPostBack)
            {
                repVehicles.DataSource = cars;
                repVehicles.DataBind();
            }
        }
    }
}