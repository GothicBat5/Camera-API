using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading; // main namespace 
using System.Text.RegularExpressions;

namespace CSCollection
{
	public class Threading
	{
		public static void Main(string[] args)
		{
			Thread mt = Thread.CurrentThread;
			mt.Name = "Nexux";

            Thread t1 = new Thread(CD);
            Thread t2 = new Thread(CU);
            t1.Start(); t2.Start();

			Console.WriteLine($"{mt.Name} is complete!");
		}

		public static void CD()
		{
			for(int i = 10; i >= 0; i--)
			{
				Console.WriteLine($"Nexux Timer {i} seconds");
				Thread.Sleep(1000);
			}
			Console.WriteLine("\nIt's done bruh");
		}

		public static void CU()
		{
			for(int i = 0; i <= 10; i++)
			{
				Console.WriteLine($"Timer num 2: {i} seconds");
				Thread.Sleep(1000);
			}
			Console.WriteLine("\nIt's done bruh");
		}		
	}
}
