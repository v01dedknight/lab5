using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5_StringsAndCollections {
  class Program {
    static void Main(string[] args) {
      string targetDirectoryPath;
      string[] foundTextFiles;
      string currentFileContent;
      string regexWordPattern;
      string phonePattern;
      string phoneReplacement;

      var dictionaryOfIncorrectWords = new Dictionary<string, string>
      {
                { "првиет", "привет" },
                { "пирвет", "привет" },
                { "здраствуйте", "здравствуйте" },
                { "програмирование", "программирование" },
                { "ошибко", "ошибка" }
            };

      Console.WriteLine("Словарь загружен. Программа готова к работе.\n"+
        "Введите путь к директории: ");
      targetDirectoryPath = Console.ReadLine();

      // Проверка существования директории и валидация ввода
      if (string.IsNullOrWhiteSpace(targetDirectoryPath) || !Directory.Exists(targetDirectoryPath)) {
        Console.WriteLine("Ошибка: Директория не найдена или путь пуст.");
        return;
      }

      // Список всех текстовых файлов в указанной папке
      foundTextFiles = Directory.GetFiles(targetDirectoryPath, "*.txt");
      Console.WriteLine($"Найдено файлов для обработки: {foundTextFiles.Length}");

      // Перебор каждого найденного текстового файла
      foreach (string currentFilePath in foundTextFiles) {
        // Чтение содержимого файла
        currentFileContent = File.ReadAllText(currentFilePath);

        // Исправление опечаток по словарю
        foreach (var dictionaryEntry in dictionaryOfIncorrectWords) {
          // Используем \b для точного поиска слова и Regex.Escape для безопасности
          regexWordPattern = $@"\b{Regex.Escape(dictionaryEntry.Key)}\b";
          currentFileContent = Regex.Replace(
              currentFileContent,
              regexWordPattern,
              dictionaryEntry.Value,
              RegexOptions.IgnoreCase
          );
        }

        // Паттерн ищет (0 + две цифры кода) + пробел? + 3 цифры + дефис + 2 цифры + дефис + 2 цифры
        phonePattern = @"\(0(\d{2})\)\s*(\d{3})-(\d{2})-(\d{2})";

        // Строка замены, где $1 — это код оператора без нуля
        phoneReplacement = "+380 $1 $2 $3 $4";

        // Замена номеров в тексте
        currentFileContent = Regex.Replace(currentFileContent, phonePattern, phoneReplacement);

        // Сохранение изменений
        File.WriteAllText(currentFilePath, currentFileContent);

        Console.WriteLine($"Обработка и сохранение завершены для: {Path.GetFileName(currentFilePath)}");
      }

      Console.WriteLine("\nЛабораторная работа успешно выполнена.\n"+
        "Нажмите любую клавишу, чтобы выйти...");
      Console.ReadKey();
    }
  }
}