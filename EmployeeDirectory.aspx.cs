using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration; 

public partial class EmployeeDirectory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       //connect to the database
        string connectionString = WebConfigurationManager.ConnectionStrings["nnernklang_dnConnectionString"].ConnectionString;

        //set SQL commands
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT EmployeeID, Name, Username FROM dn_Employees", con);

        //create reader
        SqlDataReader reader;
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            rdrEmployeesRepeater.DataSource = reader;
            rdrEmployeesRepeater.DataBind();
            reader.Close();
        }

        catch (SqlException err)
        {
            throw new ApplicationException("Data Error." + err.Message);
        }

        finally
        {
            con.Close();
        }
    }
}