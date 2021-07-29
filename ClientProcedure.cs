using System;
using System.Collections.Generic;
using System.Text;

namespace day4
{
    class ClientProcedure
    {
        static void Main()
        {
            DataAcessLayer dataAcessLayer = new DataAcessLayer();
            //dataAcessLayer.CallTenMostExpensiveProduct();
            Console.WriteLine("ENTER THE CUSTOMER ID");
            string cid= Console.ReadLine();
            
            dataAcessLayer.CallCustOrdersOrders(cid);
        }
    }
}
