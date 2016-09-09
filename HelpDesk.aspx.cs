using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class HelpDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //establish a Sql Server connection, set SQL commands
        String connectionString = WebConfigurationManager.ConnectionStrings["nnernklang_dnConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand categoryCmd = new SqlCommand("SELECT CategoryID, Category FROM dn_HelpDeskCategories", con);
        SqlCommand subjectCmd = new SqlCommand("SELECT SubjectID, Subject FROM dn_HelpDeskSubjects", con);

        SqlDataReader reader;

       //Perform data read and control processing and db error check
        try
        {
            con.Open();
            reader = categoryCmd.ExecuteReader();
            ddlCategory.DataSource = reader;
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataTextField = "Category";
            ddlCategory.DataBind();
            reader.Close();

            reader = subjectCmd.ExecuteReader();
            ddlSubject.DataSource = reader;
            ddlSubject.DataValueField = "SubjectID";
            ddlSubject.DataTextField = "Subject";
            ddlSubject.DataBind();
            reader.Close();
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data error, " + err.Message);
        }
        finally
        {
            con.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //establish a Sql Server connection, set SQL commands
        String connectionString = WebConfigurationManager.ConnectionStrings["nnernklang_dnConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand com = new SqlCommand("INSERT INTO dn_HelpDesk (EmployeeID, StationNumber, CategoryID, SubjectID, Description, StatusID)" +
                                        "VALUES (@EmployeeID, @StationNumber, @CategoryID, @SubjectID, @Description, @StatusID)", con);
        
        //Create parameter list, set their values and add them to the parameter collection
        com.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
        com.Parameters["@EmployeeID"].Value = 5;
        com.Parameters.Add("@StationNumber", System.Data.SqlDbType.Int);
        com.Parameters["@StationNumber"].Value = txtStation.Text;
        com.Parameters.Add("@CategoryID", System.Data.SqlDbType.Int);
        com.Parameters["@CategoryID"].Value = ddlCategory.SelectedItem.Value;
        com.Parameters.Add("@SubjectID", System.Data.SqlDbType.Int);
        com.Parameters["@SubjectID"].Value = ddlSubject.SelectedItem.Value;
        com.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 50);
        com.Parameters["@Description"].Value = txtDescription.Text;
        com.Parameters.Add("@StatusID", System.Data.SqlDbType.Int);
        com.Parameters["@StatusID"].Value = 1;

        //Required operations, including db connection validation
        try
        {
            con.Open();
            com.ExecuteNonQuery();
            Response.Redirect("ResponseHelpDesk.aspx");
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data error");
        }
        finally
        {
            con.Close();
        }
    }
}