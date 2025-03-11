using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        FileManager fileManager = new FileManager();
        fileManager.LoadLastSession(); // Загружаем последнее состояние

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Файловый менеджер");
            Console.WriteLine("1. Просмотр файловой структуры");
            Console.WriteLine("2. Копировать файл/каталог");
            Console.WriteLine("3. Удалить файл/каталог");
            Console.WriteLine("4. Получить информацию о файле/каталоге");
            Console.WriteLine("5. Выход");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    fileManager.DisplayFileStructure();
                    break;
                case "2":
                    fileManager.CopyElement();
                    break;
                case "3":
                    // Удаление еще не сделанно
                    Console.WriteLine("Эта функция еще не реализована.");
                    break;
                case "4":
                    // Получение информации еще не сделанно
                    Console.WriteLine("Эта функция еще не реализована.");
                    break;
                case "5":
                    fileManager.SaveLastSession();
                    return; // Выход из программы
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}

class FileManager
{
    private const string LastSessionFile = "session.txt";

    public void LoadLastSession()
    {
        if (File.Exists(LastSessionFile))
        {
            string lastPath = File.ReadAllText(LastSessionFile);
            Console.WriteLine($"Последняя открытая директория: {lastPath}");
        }
        else
        {
            Console.WriteLine("Нет сохраненного состояния.");
        }
    }

    public void SaveLastSession(string path = ".")
    {
        File.WriteAllText(LastSessionFile, path);
    }

    public void DisplayFileStructure(string path = ".")
    {
        try
        {
            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            Console.WriteLine($"Содержимое директории: {path}");
            foreach (var dir in directories)
            {
                Console.WriteLine($"[Директория] {Path.GetFileName(dir)}");
            }

            foreach (var file in files)
            {
                Console.WriteLine($"[Файл] {Path.GetFileName(file)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    public void CopyElement()
    {
        Console.WriteLine("Введите путь к исходному файлу или каталогу:");
        string source = Console.ReadLine();
        Console.WriteLine("Введите путь к месту назначения:");
        string destination = Console.ReadLine();
        try
        {
            if (Directory.Exists(source))
            {
                Console.WriteLine("Копирование директории еще не реализовано.");
            }
            else if (File.Exists(source))
            {
                File.Copy(source, destination, true);
                Console.WriteLine("Файл успешно скопирован.");
            }
            else
            {
                Console.WriteLine("Исходный файл или каталог не существует.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    // Остальные методы, такие как Удаление элемента и информация об элементе, еще не сделанны
}