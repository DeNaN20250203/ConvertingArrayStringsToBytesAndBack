using System.Text;

namespace ConvertingArrayStringsToBytesAndBack_001
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// Исходный массив строк
			string[] strArray = { "File", "Storage", "Example" };

			// Преобразуем массив строк в массив байтов
			byte[] byteArray = StringArrayToByteArray(strArray);

			// Сохраняем данные в файл
			SaveToFile(byteArray, @"c:\Work\Загрузки\data.bin");
			Console.WriteLine("Данные успешно сохранены в файл.");

			// Читаем данные из файла
			byte[] readByteArray = ReadFromFile(@"c:\Work\Загрузки\data.bin");

			// Преобразуем массив байтов обратно в массив строк
			string[] resultStrArray = ByteArrayToStringArray(readByteArray);

			Console.WriteLine("Массив строк после чтения из файла:");
			foreach (var str in resultStrArray)
			{
				Console.WriteLine(str);
			}

			Console.ReadKey();
        }

		/// <summary>
		/// Метод для преобразования массива строк в массив байтов
		/// </summary>
		/// <param name="_strArray"></param>
		/// <returns>byte[]</returns>
		public static byte[] StringArrayToByteArray(string[] _strArray)
		{
			if (_strArray == null || _strArray.Length == 0)
				return Array.Empty<byte>();

			string combinedString = string.Join(" ", _strArray); // Используем пробел как разделитель
			return Encoding.UTF8.GetBytes(combinedString);
		}

		/// <summary>
		/// Метод для преобразования массива байтов обратно в массив строк
		/// </summary>
		/// <param name="_byteArray"></param>
		/// <returns>string[]</returns>
		public static string[] ByteArrayToStringArray(byte[] _byteArray)
		{
			if (_byteArray == null || _byteArray.Length == 0)
				return Array.Empty<string>();

			string combinedString = Encoding.UTF8.GetString(_byteArray);
			return combinedString.Split(' ');
		}

		/// <summary>
		/// Метод для сохранения массива байтов в файл
		/// </summary>
		/// <param name="_byteArray"></param>
		/// <param name="filePath"></param>
		public static void SaveToFile(byte[] _byteArray, string filePath)
		{
			try
			{
				File.WriteAllBytes(filePath, _byteArray);
				Console.WriteLine($"Данные успешно сохранены в файл: {filePath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
			}
		}

		/// <summary>
		/// Метод для чтения массива байтов из файла
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns>byte[]</returns>
		public static byte[] ReadFromFile(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
				{
					Console.WriteLine("Файл не найден.");
					return Array.Empty<byte>();
				}

				byte[] byteArray = File.ReadAllBytes(filePath);
				Console.WriteLine($"Данные успешно прочитаны из файла: {filePath}");
				return byteArray;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
				return Array.Empty<byte>();
			}
		}
	}
}
