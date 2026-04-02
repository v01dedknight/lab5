using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5_StringsAndCollections {
  class Program {
    static void Main(string[] args) {
      // Словарь ошибочных слов
      var dictionary = new Dictionary<string, string>
      {
                { "првиет", "привет" },
                { "пирвет", "привет" },
                { "здраствуйте", "здравствуйте" },
                { "програмирование", "программирование" },
                { "ошибко", "ошибка" }
            };

      Console.WriteLine("Словарь загружен. Программа готова к работе.");
    }
  }
}