<a id="anchor"></a>
# Работа с файлами в C#...
## ...Преобразование массива строк в байты и обратно

<a href="#anchor" target="_blank"><img src="Cover 20250226_001.jpg" alt="Image" width="300" /></a>

🔄 В данной статье мы рассмотрим, как преобразовывать массив строк в массив байтов и сохранять его в файл, а затем читать эти данные из файла и восстанавливать исходный массив строк. Этот подход может быть полезен для хранения данных в бинарных файлах, передачи информации между приложениями или архивации данных.

## Введение
🔡 При работе с файлами часто возникает необходимость сохранить текстовые данные в бинарном формате. Например, вы можете захотеть сохранить массив строк в файл, чтобы позже прочитать его и восстановить исходные данные. Для этого нужно преобразовать строки в байты, записать их в файл, а затем выполнить обратное преобразование.

☑️ Мы будем использовать стандартную `библиотеку .NET` для работы с файлами (`System.IO`) и кодировку `UTF-8` для преобразования строк в байты и обратно.

## Реализация
### 1. Преобразование массива строк в массив байтов
☑️ Для преобразования массива строк в массив байтов мы объединяем все строки через разделитель (например, пробел) и затем преобразуем полученную строку в байты с помощью метода `Encoding.UTF8.GetBytes`.

```csharp
public static byte[] StringArrayToByteArray(string[] _strArray)
{
    if (_strArray == null || _strArray.Length == 0)
        return Array.Empty<byte>();

    string combinedString = string.Join(" ", _strArray); // Используем пробел как разделитель
    return Encoding.UTF8.GetBytes(combinedString);
}
```

**Пример**:
Если входной массив строк равен `{ "File", "Storage", "Example" }`, то после преобразования мы получим массив байтов:

```
[70, 105, 108, 101, 32, 83, 116, 111, 114, 97, 103, 101, 32, 69, 120, 97, 109, 112, 108, 101]
```

### 2. Сохранение массива байтов в файл
☑️ Для сохранения массива байтов в файл мы используем `метод File.WriteAllBytes`. Этот метод записывает байты прямо в указанный файл.

```csharp
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
```

**Пример**:

Если мы вызываем метод `SaveToFile` с путем к файлу `data.bin`, то массив байтов будет записан в этот файл.

### 3. Чтение массива байтов из файла
☑️ Чтобы прочитать массив байтов из файла, мы используем метод `File.ReadAllBytes`. Перед чтением проверяем, существует ли файл, чтобы избежать ошибок.

```csharp
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
```

**Пример**:

Если файл `data.bin` содержит массив байтов, то после вызова метода ReadFromFile мы получим эти байты в виде массива.

### 4. Преобразование массива байтов обратно в массив строк
☑️ Для обратного преобразования мы сначала преобразуем массив байтов в строку с помощью `метода Encoding.UTF8.GetString`, а затем разделяем ее по разделителю (пробелу) с помощью `метода Split`.

```csharp
public static string[] ByteArrayToStringArray(byte[] _byteArray)
{
    if (_byteArray == null || _byteArray.Length == 0)
        return Array.Empty<string>();

    string combinedString = Encoding.UTF8.GetString(_byteArray);
    return combinedString.Split(' ');
}

```

**Пример**:

Если массив байтов равен
`[70, 105, 108, 101, 32, 83, 116, 111, 114, 97, 103, 101, 32, 69, 120, 97, 109, 112, 108, 101]`,
то после преобразования мы получим массив строк:
`{ "File", "Storage", "Example" }`

## Полный пример программы
▶️ **_Вот полный код программы_**, который демонстрирует весь процесс в файле [`Programm.cs`][21]...


## Заключение
> ➡️ В этой статье мы рассмотрели, как можно работать с файлами `в C#`, преобразуя массив строк в массив байтов и обратно. Такой подход позволяет эффективно сохранять и восстанавливать текстовые данные в бинарном формате. Вы можете адаптировать этот код для различных задач, таких как:
>> - Хранение данных в файлах.
>> - Передача данных между приложениями.
>> - Архивация и восстановление информации.
>> - Этот метод прост в реализации и достаточно универсален для большинства сценариев работы с файлами.


<a href="https://github.com/DeNaN20250203?tab=repositories" target="_blank"><img src="GitHubDeJra.png" alt="Image" width="300" /></a>  
[Верх](#anchor)

[21]: https://github.com/DeNaN20250203/ConvertingArrayStringsToBytesAndBack/blob/main/ConvertingArrayStringsToBytesAndBack%20001/Program.cs "Program.cs"
