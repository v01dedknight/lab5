using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5_StringsAndCollections {
  class Program {
    static void Main(string[] args) {
      string path;
      string[] files;
      string content;
      string pattern;

      // Словарь ошибочных слов
      var dictionary = new Dictionary<string, string>{
                { "првиет", "привет" },
                { "пирвет", "привет" },
                { "здраствуйте", "здравствуйте" },
                { "програмирование", "программирование" },
                { "ошибко", "ошибка" }
      };
      Console.WriteLine("Словарь загружен. Программа готова к работе.");

      Console.Write("Введите путь к директории: ");
      path = Console.ReadLine();

      // Проверка существования директории
      if (!Directory.Exists(path)) {
        Console.WriteLine("Директория не найдена.");
        return;
      }

      // Возвращает список всех текстовых файлов
      files = Directory.GetFiles(path, "*.txt");
      Console.WriteLine($"Найдено файлов для обработки: {files.Length}");

      // Сделал через foreach вместо for, т. к. в этом случае пришлось бы подготавливать ключи
      foreach (string filePath in files) {
        content = File.ReadAllText(filePath);

        // Исправление слов по словарю
        foreach (var entry in dictionary) {
          // Поиск слова целиком, игнорируя регистр
          pattern = $@"\b{entry.Key}\b";
          content = Regex.Replace(content, pattern, entry.Value, RegexOptions.IgnoreCase);
        }

        Console.WriteLine($"Обработка слов в {Path.GetFileName(filePath)} завершена.");
      }
    }
  }
}