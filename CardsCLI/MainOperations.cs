﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsCLI
{
    internal class MainOperations
    {
        public static void MainCommand(string firstName, string lastName)
        {
            Console.WriteLine($"Hello {firstName} {lastName}");
        }
    }
}
