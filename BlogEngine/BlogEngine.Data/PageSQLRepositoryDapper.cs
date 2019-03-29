using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace BlogEngine.Data
{
    public class PageSQLRepositoryDapper : IPageTestRepository
    {
        public List<Page> GetAllPages()
        {           
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                return cxn.Query<Page>("PageGetAll", commandType: CommandType.StoredProcedure).ToList();
            }            
        }

        public Page GetPage(int pageId)
        {            
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageID", pageId);

                return cxn.Query<Page>("PageGetByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();               
            }           
        }

        public void AddPage(Page page)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();

                if (page.Title != null)
                    parameters.Add("@Title", page.Title);
                parameters.Add("@PageContent", page.Content);

                cxn.Execute("PageInsert", parameters, commandType: CommandType.StoredProcedure);                
            }
        }

        public void RemovePage(int pageId)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageID", pageId);

                cxn.Execute("PageDelete", parameters, commandType: CommandType.StoredProcedure);               
            }
        }

        public void UpdatePage(Page page)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageID", page.PageId);
                parameters.Add("@Title", page.Title);
                parameters.Add("@PageContent", page.Content);

                cxn.Execute("PageUpdate", parameters, commandType: CommandType.StoredProcedure);                
            }
        }

    }
}

