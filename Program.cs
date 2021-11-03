using System;

namespace etendue_example
{
    class Program
    {
		
		
		
		
		
        static void Main(string[] args)
        {
			float[] numbers = new float[130];
			Random rand = new System.Random();
            for(int i = 0; i < numbers.Length; i ++) {
				numbers[i] = 5 + (float)rand.NextDouble() * 15;
			}
			Program pr = new Program();
			pr.printHistogram(numbers);
        }
		
		
		
		float[] sort(float[] arrr) {
			float[] arr = new float[arrr.Length];
			arrr.CopyTo(arr, 0);
			int n = arr.Length;
			for (int i = 0; i < n - 1; i++)
				for (int j = 0; j < n - i - 1; j++)
					if (arr[j] > arr[j + 1])
					{
						// swap temp and arr[i]
						float temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
			return arr;
		}
		
		void printHistogram(float[] data) {
			
			Console.Clear();
			
			int line = 1;
			
			//data = sort(data);
			
			Console.ForegroundColor = ConsoleColor.Gray;
			
			for (int i = 0; i < data[data.Length - 1]; i ++) {
				Console.SetCursorPosition(1, Console.WindowHeight - i - 2);
				Console.Write((int)i);
				line = Console.CursorLeft;
			}
			
			for (int i = 0; i < data.Length + 3; i ++) {
				Console.SetCursorPosition(i, Console.WindowHeight - 1);
				Console.Write('─');
			}
			for (int i = 0; i < data.Length + 3; i ++) {
				Console.SetCursorPosition(i, Console.WindowHeight - (int)data[data.Length - 1] - 3);
				Console.Write('─');
			}
			for (int i = 0; i < data[data.Length - 1]; i ++) {
				Console.SetCursorPosition(0, Console.WindowHeight - i - 2);
				Console.Write('│');
			}
			for (int i = 0; i < data[data.Length - 1]; i ++) {
				Console.SetCursorPosition(data.Length + 3, Console.WindowHeight - i - 2);
				Console.Write('│');
			}
			Console.SetCursorPosition(data.Length + 3, Console.WindowHeight-1);
			Console.Write('╝');
			Console.SetCursorPosition(data.Length + 3,  Console.WindowHeight - (int)data[data.Length - 1] - 3);
			Console.Write('╗');
			Console.SetCursorPosition(0,  Console.WindowHeight - 1);
			Console.Write('╚');
			Console.SetCursorPosition(0,  Console.WindowHeight - (int)data[data.Length - 1] - 3);
			Console.Write('╔');
			
			Console.SetCursorPosition(0, Console.WindowHeight - 2);
			
			foreach(float f in data) {
				Console.ForegroundColor = get_rand_col();
				if (line > Console.WindowWidth) {
					return;
				}
				Console.SetCursorPosition(line, Console.WindowHeight - 1);
				int count = (int)f;
				for(int i = 0; i < count; i ++) {
					Console.SetCursorPosition(line, Console.CursorTop - 1);
					Console.Write('█');
				}
				line ++;
			}
			
			data = sort(data);
			
			Console.SetCursorPosition(0, Console.WindowHeight);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("La différence entre le plus grand nombre, " + data[0] + " et le plus petit, " + data[data.Length - 1] + " est: " + (data[data.Length - 1] - data[0]) + "!");
			
			/*line = 0;
			
			sort(data);
			for (int i = 0; i < data[data.Length - 1]; i ++) {
				Console.SetCursorPosition(0, (int)data[i]);
				Console.Write((int)data[i]);
				line = Console.CursorLeft;
				
			}
			
			foreach(float f in data) {
				if (line > Console.WindowWidth) {
					return;
				}
				Console.SetCursorPosition(line, Console.WindowHeight);
				int count = (int)f;
				for(int i = 0; i < count; i ++) {
					Console.SetCursorPosition(line, Console.CursorTop - 1);
					Console.Write('*');
				}
				line ++;
			}*/
		}
		
		ConsoleColor get_rand_col() {
			Array values = Enum.GetValues(typeof(ConsoleColor));
			Random random = new Random();
			ConsoleColor ret = (ConsoleColor)values.GetValue(random.Next(values.Length));
			if (ret == ConsoleColor.Black) {
				ret = get_rand_col();
			}
			return ret;
		}
    }
}
