using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.WebApp.DataHelper
{
    public class BaseDataHelper<T>
    {
        public IEnumerable<T> GetItems(string SPName, string ConnectionString)
        {
            List<T> items = new List<T>();
            IDbConnection con = null;
            try
            {
                using (con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    items = con.Query<T>(SPName).ToList();
                }
            }
            catch (Exception ex)
            {
                //Error log here
            }
            finally
            {
                con.Close();
            }
            return items;
        }


        public T GetItemByID(DynamicParameters parameters, string SPName, string ConnectionString)
        {
            T contactitem = default(T); 

            IDbConnection con = null;
            try
            {
                using (con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    contactitem = con.Query<T>(SPName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                return contactitem;
            }
            catch (Exception ex)
            {
                //Error log here;
            }

            return contactitem;
        }


        public int AddUpdatedItem(DynamicParameters parameters, string SPName, string ConnectionString)
        {
            IDbConnection con = null;
            int result = 0;
            try
            {
                using (con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    result = con.Execute(SPName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                //Error log here return default(item);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public int DeleteItem(DynamicParameters parameters, string SPName, string ConnectionString)
        {
            IDbConnection con = null;
            int result = 0;
            try
            {
                using (con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    result = con.Execute(SPName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                //Error log here
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }
}
