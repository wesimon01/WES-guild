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
            var pages = new List<Page>();
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PageGetAll", cxn))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cxn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            pages.Add(PopulatePageFromDataReader(dr));
                        }
                    }
                }               
            }
            return pages;
        }

        public Page GetPage(int pageId)
        {
            var page = new Page();
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PageGetByID", cxn))
                {                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageID", pageId);                    
                    cxn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            page = PopulatePageFromDataReader(dr);
                        }
                    }
                }               
            }
            return page;
        }

        public void AddPage(Page page)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PageInsert", cxn))
                {                                      
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (page.Title != null)
                        cmd.Parameters.AddWithValue("@Title", page.Title);
                    cmd.Parameters.AddWithValue("@PageContent", page.Content);

                    cxn.Open();
                    cmd.ExecuteNonQuery();                    
                }               
            }
        }

        public void RemovePage(int pageId)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PageDelete", cxn))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;                   
                    cmd.Parameters.AddWithValue("@PageID", pageId);

                    cxn.Open();
                    cmd.ExecuteNonQuery();                    
                    //return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdatePage(Page page)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PageUpdate", cxn))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@PageID", page.PageId);
                    cmd.Parameters.AddWithValue("@Title", page.Title);
                    cmd.Parameters.AddWithValue("@PageContent", page.Content);

                    cxn.Open();
                    cmd.ExecuteNonQuery();                   
                }                
            }
        }

        private Page PopulatePageFromDataReader(SqlDataReader dr)
        {
            var page = new Page();
            page.PageId = (int)dr["PageID"];
            page.Title = dr["Title"].ToString();
            
            if (dr["PageContent"] != DBNull.Value)
                page.Content = dr["PageContent"].ToString();

            return page;
        }

    }
}
