using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Models;
using System.Data.SqlClient;
using System.Data;

namespace BlogEngine.Data
{
    public class PageSQLRepository : IPageTestRepository
    {
        public List<Page> GetAllPages()
        {
            List<Page> pages = new List<Page>();

            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "PageGetAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pages.Add(PopulatePageFromDataReader(dr));
                    }
                }
            }
            return pages;
        }

        public Page GetPage(int pageId)
        {
            Page page = new Page();

            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "PageGetByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageID", pageId);
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        page = PopulatePageFromDataReader(dr);
                    }
                }
            }
            return page;
        }

        public void AddPage(Page page)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "PageInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;

                if (page.Title != null)
                cmd.Parameters.AddWithValue("@Title", page.Title);
                cmd.Parameters.AddWithValue("@PageContent", page.Content);

                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();
            }
        }

        public void RemovePage(int pageId)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "PageDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                cmd.Parameters.AddWithValue("@PageID", pageId);

                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();
                //return (int)cmd.ExecuteScalar();
            }
        }

        public void UpdatePage(Page page)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "PageUpdate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                cmd.Parameters.AddWithValue("@PageID", page.PageId);
                cmd.Parameters.AddWithValue("@Title", page.Title);
                cmd.Parameters.AddWithValue("@PageContent", page.Content);

                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();
            }
        }

        private Page PopulatePageFromDataReader(SqlDataReader dr)
        {
            Page page = new Page();
            page.PageId = (int)dr["PageID"];
            page.Title = dr["Title"].ToString();
            
            if (dr["PageContent"] != DBNull.Value)
                page.Content = dr["PageContent"].ToString();

            return page;
        }

    }
}
