﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.GIS.Logs
{
    public class ElementLogger
    {
        public static void Info(string message)
        {
            Console.WriteLine(message);
        }

        public static void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
}
