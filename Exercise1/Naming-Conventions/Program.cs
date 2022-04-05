using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mini4ki
{
	public class Mines
	{
		public class Points
		{
			string name;
			int points;

			public string thisName
			{
				get { return name; }
				set { name = value; }
			}

			public int thisPoints
			{
				get { return points; }
				set { points = value; }
			}

			public Points() { }

			public Points(string name, int points)
			{
				this.name = name;
				this.points = points;
			}
		}

		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] field = createPlayground();
			char[,] bombs = putBombs();
			int counter = 0;
			bool isGrum = false;
			List<Points> champions = new List<Points>(6);
			int row = 0;
			int column = 0;
			bool isDone = true;
			const int MAX = 35;
			bool isDone2 = false;

			do
			{
				if (isDone)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh fieldteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					dumpp(field);
					isDone = false;
				}
				Console.Write("Daj red i columnona : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= field.GetLength(0) && column <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						ranking(champions);
						break;
					case "restart":
						field = createPlayground();
						bombs = putBombs();
						dumpp(field);
						isGrum = false;
						isDone = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (bombs[row, column] != '*')
						{
							if (bombs[row, column] == '-')
							{
								yourTurn(field, bombs, row, column);
								counter++;
							}
							if (MAX == counter)
							{
								isDone2 = true;
							}
							else
							{
								dumpp(field);
							}
						}
						else
						{
							isGrum = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}
				if (isGrum)
				{
					dumpp(bombs);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si userName: ", counter);
					string userName = Console.ReadLine();
					Points t = new Points(userName, counter);
					if (champions.Count < 5)
					{
						champions.Add(t);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].thisPoints < t.thisPoints)
							{
								champions.Insert(i, t);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((Points r1, Points r2) => r2.thisName.CompareTo(r1.thisName));
					champions.Sort((Points r1, Points r2) => r2.thisPoints.CompareTo(r1.thisPoints));
					ranking(champions);

					field = createPlayground();
					bombs = putBombs();
					counter = 0;
					isGrum = false;
					isDone = true;
				}
				if (isDone2)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					dumpp(bombs);
					Console.WriteLine("Daj si imeto, batka: ");
					string newName = Console.ReadLine();
					Points newPoints = new Points(newName, counter);
					champions.Add(newPoints);
					ranking(champions);
					field = createPlayground();
					bombs = putBombs();
					counter = 0;
					isDone2 = false;
					isDone = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void ranking(List<Points> newPoints)
		{
			Console.WriteLine("\nTo4KI:");
			if (newPoints.Count > 0)
			{
				for (int i = 0; i < newPoints.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, newPoints[i].thisName, newPoints[i].thisPoints);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void yourTurn(char[,] gameField,
			char[,] gameBombs, int gameRow, int gameColumn)
		{
			char bombPlace = bombsQuantity(gameBombs, gameRow, gameColumn);
			gameBombs[gameRow, gameColumn] = bombPlace;
			gameField[gameRow, gameColumn] = bombPlace;
		}

		private static void dumpp(char[,] board)
		{
			int rowNum = board.GetLength(0);
			int columnNum = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rowNum; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < columnNum; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] createPlayground()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] putBombs()
		{
			int bombRows = 5;
			int bombColumns = 10;
			char[,] playField = new char[bombRows, bombColumns];

			for (int i = 0; i < bombRows; i++)
			{
				for (int j = 0; j < bombColumns; j++)
				{
					playField[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int randomNum = random.Next(50);
				if (!r3.Contains(randomNum))
				{
					r3.Add(randomNum);
				}
			}

			foreach (int i2 in r3)
			{
				int column = (i2 / bombColumns);
				int row = (i2 % bombColumns);
				if (row == 0 && i2 != 0)
				{
					column--;
					row = bombColumns;
				}
				else
				{
					row++;
				}
				playField[column, row - 1] = '*';
			}

			return playField;
		}

		private static void score(char[,] field)
		{
			int column = field.GetLength(0);
			int row = field.GetLength(1);

			for (int i = 0; i < column; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (field[i, j] != '*')
					{
						char bombsQuantityo = bombsQuantity(field, i, j);
						field[i, j] = bombsQuantityo;
					}
				}
			}
		}

		private static char bombsQuantity(char[,] r, int rr, int rrr)
		{
			int bombsNum = 0;
			int rows = r.GetLength(0);
			int columns = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, rrr] == '*')
				{ 
					bombsNum++; 
				}
			}
			if (rr + 1 < rows)
			{
				if (r[rr + 1, rrr] == '*')
				{ 
					bombsNum++; 
				}
			}
			if (rrr - 1 >= 0)
			{
				if (r[rr, rrr - 1] == '*')
				{ 
					bombsNum++;
				}
			}
			if (rrr + 1 < columns)
			{
				if (r[rr, rrr + 1] == '*')
				{ 
					bombsNum++;
				}
			}
			if ((rr - 1 >= 0) && (rrr - 1 >= 0))
			{
				if (r[rr - 1, rrr - 1] == '*')
				{ 
					bombsNum++; 
				}
			}
			if ((rr - 1 >= 0) && (rrr + 1 < columns))
			{
				if (r[rr - 1, rrr + 1] == '*')
				{ 
					bombsNum++; 
				}
			}
			if ((rr + 1 < rows) && (rrr - 1 >= 0))
			{
				if (r[rr + 1, rrr - 1] == '*')
				{ 
					bombsNum++; 
				}
			}
			if ((rr + 1 < rows) && (rrr + 1 < columns))
			{
				if (r[rr + 1, rrr + 1] == '*')
				{ 
					bombsNum++; 
				}
			}
			return char.Parse(bombsNum.ToString());
		}
	}
}
