using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; //Install this package

namespace day4
{
    class Shippers
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public void GetShipper()
        {
            Console.WriteLine("Enter the Company Name");
            CompanyName = Console.ReadLine();
            Console.WriteLine("Enter the Phone number");
            Phone = Console.ReadLine();
        }

        public void LooseShipper()
        {
            Console.WriteLine("Enter the Company Name");
            CompanyName = Console.ReadLine();

        }

        public void EditShipper()
        {
            Console.WriteLine("Enter the Shipper ID");
            ShipperID = Convert.ToInt32(Console.ReadLine());
            GetShipper();
        }
    }
    class ConnectionArchitectureEg
    {
        
        static void Main()
        {
            //2. create sqlconnection object
            SqlConnection con = null;

            //create command object
            SqlCommand cmd = null;

            try
            {
                //3.Windows Authentication
                con = new SqlConnection(
                    "Data Source = KIRTI; Initial Catalog = Northwind; Integrated Security = true");

                //4.open con
                con.Open();

                //Creating object for Shippers Class
                Shippers shippers = new Shippers();

                //Insertion
                //calling GetShipper method

                /*
                shippers.GetShipper();
                cmd = new SqlCommand("insert into Shippers(CompanyName, Phone) values(@cname,@phone)", con);
                cmd.Parameters.AddWithValue("@cname",shippers.CompanyName);
                cmd.Parameters.AddWithValue("@phone", shippers.Phone);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of Rows Inserted: {0}", i);
                */


                /*
                //Deletion
                //Calling LooseShipper method

                shippers.LooseShipper();
                cmd = new SqlCommand("delete from Shippers where CompanyName=@cname", con);
                cmd.Parameters.AddWithValue("@cname", shippers.CompanyName);
                int j = cmd.ExecuteNonQuery();
                Console.WriteLine("No of Rows Deleted : {0}", j);
                */

                /*
                //select
                SqlDataReader dr;
                cmd = new SqlCommand("select * from Shippers", con);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Console.WriteLine(dr["CompanyName"] + " " + dr["Phone"]);
                    // Console.WriteLine(dr[0]+ " " +dr[1]+ " " +dr[2]);

                }

                */
                /*
                //update
                shippers.EditShipper();
                cmd = new SqlCommand("Update Shippers set CompanyName=@cname Phone=@phone where ShipperID=@id", con);
                cmd.Parameters.AddWithValue("@id", shippers.ShipperID);
                cmd.Parameters.AddWithValue("@cname", shippers.CompanyName);
                cmd.Parameters.AddWithValue("@phone", shippers.Phone);

                int a = cmd.ExecuteNonQuery();
                Console.WriteLine("No of rows updated :{0}", a);
                */

                //scalar value
                /*
                cmd = new SqlCommand("select count(ShipperID) from Shippers", con);
                Console.WriteLine("Total Shipper :{0}", Convert.ToInt32(cmd.ExecuteScalar()));
                */
                
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
