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

      var dictionaryOfIncorrectWords = new Dictionary<string, string>
      {
                { "првиет", "привет" },
                { "пирвет", "привет" },
                { "здраствуйте", "здравствуйте" },
                { "програмирование", "программирование" },
                { "ошибко", "ошибка" }
            };

      Console.WriteLine("Словарь загружен. Программа готова к работе.");
      Console.Write("Введите путь к директории: ");
      targetDirectoryPath = Console.ReadLine();

      // Проверка существования директории и валидация ввода
      if (string.IsNullOrWhiteSpace(targetDirectoryPath) || !Directory.Exists(targetDirectoryPath)) {
        Console.WriteLine("Ошибка: Директория не найдена или путь пуст.");
        return;
      }

      // Список всех текстовых файлов в указанной папке
      foundTextFiles = Directory.GetFiles(targetDirectoryPath, "*.txt");
      Console.WriteLine($"Найдено файлов для обработки: {foundTextFiles.Length}");

      // Итерация по каждому найденному файлу
      foreach (string currentFilePath in foundTextFiles) {
        currentFileContent = File.ReadAllText(currentFilePath);

        // Перебор каждой пары в словаре
        foreach (var dictionaryEntry in dictionaryOfIncorrectWords) {

          // Паттерн для поиска целого слова (граница \b) без учета регистра
          regexWordPattern = $@"\b{Regex.Escape(dictionaryEntry.Key)}\b";
          currentFileContent = Regex.Replace(
              currentFileContent,
              regexWordPattern,
              dictionaryEntry.Value,
              RegexOptions.IgnoreCase
          );
        }

        Console.WriteLine($"Обработка слов в файле {Path.GetFileName(currentFilePath)} завершена.");
      }
    }
  }
}