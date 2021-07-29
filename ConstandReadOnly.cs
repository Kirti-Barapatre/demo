using System;
using System.Collections.Generic;
using System.Text;

namespace day4
{
    class Sample
    {
        int box = 20;
        const int square = 10;
        const int a = square + 20;
        readonly float pi = 3.14f;

        internal Sample()
        {
            pi = 3.00f; //read-only are run time constant
            //square = 90; //const are compile time constant
        }

        internal void Analyse()
        {
            box = 30;
            //square=60; //const variables cant be changed
            // a= square + square; //error
        }

        //Named parameter and optional parameter
                                        //optional parameter
        public static int Calculation(int a, int b=78)
        {
            return a + b;
        }
    }
    class ConstandReadOnly
    {

        static void Main()
        {
            Sample.Calculation(3);
        }
    }
}
