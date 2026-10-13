using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DiaryDiary
{
	public class RandomX
	{
		public void Start()
		{
			Random rd = new Random();

			int num = rd.Next(1, 50);

			Console.WriteLine($"Random Int: {num}"); 
		}
	}
	public class MovingY
	{
		public void Update()
		{
			int land = 50;
			int x = 0;
			int y = 0;
			Console.WriteLine($"C: {x}, {y}");

			while(land > y)
			{
				Console.WriteLine($"C: {x}, {y}");
				y++;
				x+=3;

				if(y == 51 ||y < 78)
				{
					break;
				} 
			}
		}
	}

	public class MZ
	{
		public void Frame()
		{
			string[] money = {
				"Dollar", "Yen", "Peso",
				"Euro", "Yuan", "Pound"
			};

			Random rad = new Random();

			string go = money[rad.Next(money.Length)];

			Console.WriteLine($"Currency: {go}");
		}
	}

	public class MainCS
	{
		public static void Main(string[] args)
		{
			string input;

			Console.Write("Input: ");
			input = Console.ReadLine();

			if(input == "1")
			{
				RandomX rx = new RandomX();
				rx.Start();
			}
			else if(input == "2")
			{
				MovingY my = new MovingY();
				my.Update();
			}
			else {
				MZ mz = new MZ();
				mz.Frame();
			}
		}
	}
}
