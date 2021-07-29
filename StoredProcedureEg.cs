using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace day4
{
    class DataAcessLayer
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                    "Data Source = KIRTI; Initial Catalog = Northwind; Integrated Security = true");
            con.Open();
            return con;
        }

        //Procedure without parameters
        internal void CallTenMostExpensiveProduct()
        {
            try
            {
                GetConnection();
                cmd = new SqlCommand("Ten Most Expensive Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1]);
                }


            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }

        internal void CallCustOrdersOrders(string cid)
        {
            try
            {
                GetConnection();
                cmd = new SqlCommand("CustOrdersOrders @CustomerID", con);
                cmd.Parameters.AddWithValue("@CustomerID", cid);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Console.WriteLine(dr["OrderID"] + " " + dr["OrderDate"] + " " + dr["ShippedDate"]);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
