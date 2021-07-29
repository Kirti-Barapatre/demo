using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace day4
{
    class DAL
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

        public void DisplayRegion()
        {
            con = GetConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            
            da = new SqlDataAdapter("select * from Region", con);
            //DataSet ds = new DataSet();  // collection of tables
            //putting the table inside dataset
            da.Fill(ds, "NWREGION");

            //reading the table info from dataset
            DataTable dt;
            dt = ds.Tables["NWREGION"];
            foreach(DataRow row in dt.Rows)
            {
                foreach(DataColumn column in dt.Columns)
                {
                    Console.Write(row[column]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
            
            /*
            //adding one more table to database shippers
            Console.WriteLine("----------");
            Console.WriteLine("-----------Shipper Table----------");
            da = new SqlDataAdapter("Select * from Shippers", con);
            da.Fill(ds, "NWSHIPPER");
            DataTable  dt1 = ds.Tables["NWSHIPPER"];
            foreach (DataRow row in dt1.Rows)
            {
                foreach (DataColumn column in dt1.Columns)
                {
                    Console.Write(row[column]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }

            */

            //Inserting new row in region table in database
            //Insert , update, delete operation--> sqlcommandbuilder
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Fill(ds);


            //Inserting or adding a new row
            //creating a new row in NWREGION in dataset
            DataRow row1 = ds.Tables["NWREGION"].NewRow();
            row1["RegionID"] = 14;
            row1["RegionDescription"] = "AAAAAAAAA";
            //adding row to database in dataset
            ds.Tables["NWREGION"].Rows.Add(row1);
            da.Update(ds, "NWREGION");
            Console.WriteLine("----------");

            dt = ds.Tables["NWREGION"];
            foreach(DataRow dataRow in dt.Rows)
            {
                foreach(DataColumn dataColumn in dt.Columns)
                {
                    Console.Write(dataRow[dataColumn]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }




        }
    }
    class DisconnectedArchitectureEg
    {
        static void Main()
        {
            DAL obj = new DAL();
            obj.DisplayRegion();
        }
    }
}
