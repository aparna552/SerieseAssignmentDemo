
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
namespace SerieseAssignmentDemo
{
    public partial class Addseriese : System.Web.UI.Page
    {

        string connqu = ConfigurationManager.ConnectionStrings["cons"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                view();
                bindseriesetype();
                bindmatchtype();
                bindGender();
            }


        }

        public void view()
        {
            SqlConnection con = new SqlConnection(connqu);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("prcTblSeriesView", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        public void bindseriesetype()
        {
            SqlConnection con = new SqlConnection(connqu);
            con.Open();
            string query = "SELECT DISTINCT SeriesType FROM tbl_Series";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);


            ddlSeriesType.DataSource = dt;

            ddlSeriesType.DataBind();


            ddlSeriesType.Items.Insert(0, new ListItem("Select", ""));




        }

        public void bindmatchtype()
        {
            SqlConnection con = new SqlConnection(connqu);
            con.Open();
            string query = "SELECT DISTINCT MatchType FROM tbl_Series";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);


            ddlMatchType.DataSource = dt;

            ddlMatchType.DataBind();


            ddlMatchType.Items.Insert(0, new ListItem("Select", ""));




        }


        public void bindGender()
        {
            SqlConnection con = new SqlConnection(connqu);
            con.Open();
            string query = "SELECT DISTINCT Gender FROM tbl_Series";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);


            ddlGender.DataSource = dt;

            ddlGender.DataBind();


            ddlGender.Items.Insert(0, new ListItem("Select", ""));




        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connqu);
            con.Open();
            SqlCommand cmd = new SqlCommand("prcTblSeriesInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SeriesName", txtSeriesName.Text);
            cmd.Parameters.AddWithValue("@SeriesType", ddlSeriesType.SelectedValue);
            cmd.Parameters.AddWithValue("@MatchType", ddlMatchType.SelectedValue);
            cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(txtYear.Text));
            cmd.Parameters.AddWithValue("@TrophyType", txtTrophyType.Text);
            cmd.Parameters.AddWithValue("@SeriesStartDate", txtStartDate.Text);
            cmd.Parameters.AddWithValue("@SeriesEndDate", txtEndDate.Text);
            cmd.ExecuteNonQuery();
            msg.Text = "Data Saved Successfully";
            view();

          }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            view();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string seriesName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string seriesType = ((TextBox)row.Cells[2].Controls[0]).Text;
            string matchType = ((TextBox)row.Cells[3].Controls[0]).Text;
            string gender = ((TextBox)row.Cells[4].Controls[0]).Text;
            int year = Convert.ToInt32(((TextBox)row.Cells[5].Controls[0]).Text);
            string trophyType = ((TextBox)row.Cells[6].Controls[0]).Text;
            DateTime startDate = Convert.ToDateTime(((TextBox)row.Cells[7].Controls[0]).Text);
            DateTime endDate = Convert.ToDateTime(((TextBox)row.Cells[8].Controls[0]).Text);


            SqlConnection con = new SqlConnection(connqu);
            
                con.Open();
                SqlCommand cmd = new SqlCommand("prcTblSeriesUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SeriesEID", id);
                cmd.Parameters.AddWithValue("@SeriesName", seriesName);
                cmd.Parameters.AddWithValue("@SeriesType", seriesType);
                cmd.Parameters.AddWithValue("@MatchType", matchType);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@TrophyType", trophyType);
                cmd.Parameters.AddWithValue("@SeriesStartDate", startDate);
                cmd.Parameters.AddWithValue("@SeriesEndDate", endDate);

                cmd.ExecuteNonQuery(); 
                con.Close();
            
        }


            protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            SqlConnection con = new SqlConnection(connqu);
            
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Series WHERE SeriesEID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                con.Close();
            

            view();
        }



        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; 
            view();

        }
    }
}
