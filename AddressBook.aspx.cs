using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class AddressBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindGrid();
    }
    private void BindGrid()
    {
        //make database connection
        String connectionString = ConfigurationManager.ConnectionStrings["nnernklang_dnConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand com = new SqlCommand("SELECT EmployeeID, Name, City, State, MobilePhone FROM dn_Employees", con);

        SqlDataReader reader;

        try
        {
            con.Open();
            reader = com.ExecuteReader();
            grid.DataSource = reader;
            //add the following line to work with DetailsView
            grid.DataKeyNames = new string[] { "EmployeeID" };
            grid.DataBind();
            reader.Close();
        }
        finally
        {
            con.Close();
        }
    }
    protected void grid_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDetails();
    }
    protected void BindDetails()
    {
        int selectedRowIndex = grid.SelectedIndex;
        int employeeID = (int)grid.DataKeys[selectedRowIndex].Value;

        //make connection
        String connectionString = ConfigurationManager.ConnectionStrings["nnernklang_dnConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT EmployeeID, Name, Address, City, State, Zip, HomePhone, Extension "+
                                        "FROM dn_Employees WHERE EmployeeID=@EmployeeID", con);     
        SqlDataReader reader;
        //set parameters
        cmd.Parameters.Add("EmployeeID", SqlDbType.Int);
        cmd.Parameters["EmployeeID"].Value = employeeID;

        //perform db operations
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            employeeDetails.DataSource = reader;
            employeeDetails.DataKeyNames = new string[] { "EmployeeID" };
            employeeDetails.DataBind();
            reader.Close();
        }
        finally
        {
            con.Close();
        }

    }

}