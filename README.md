# Laboratory Work №5: Strings and Collections

### Author
**Me**

**Variant:** Text Correction and Phone Number Normalization System

---

### Objective
Exploration of string manipulation and collection usage in C#, including the application of dictionaries and regular expressions. Implementation of automated text correction and pattern-based data transformation for files within a specified directory.

---

### Project Structure
* **Program.cs:** Main entry point responsible for processing files, applying corrections, and performing regex-based replacements.
* **TextProcessor.cs:** Core logic for handling text transformations, including error correction and phone number normalization.
* **DictionaryProvider.cs:** Contains and manages the dictionary of incorrect-to-correct word mappings.
* **FileManager.cs:** Handles file reading, writing, and directory traversal.
* **lab5.csproj:** Project configuration file for the .NET environment.

---

### Coding Standards Applied
* **Indentation:** Strictly 2 spaces (no tabs).
* **Naming Convention:** lowerCamelCase for variables and local properties.
* **Logic Separation:** Clear separation between file operations, text processing, and data storage.
* **Error Handling:** Basic validation of file paths and input data.
* **Text Processing:** Use of dictionaries for word correction and regular expressions for pattern matching and replacement.

---

### Key Features
* **Dictionary-Based Correction: Automatic fixing of common misspelled words using a predefined dictionary.
* **Batch File Processing: Ability to process multiple text files within a specified directory.
* **Regex Phone Formatting: Detection and transformation of phone numbers from (012) 345-67-89 format to +380 12 345 67 89.
* **Flexible Architecture: Modular design allowing easy extension of dictionary and processing rules.
* **Efficient Search and Replace: Optimized handling of large text files.

---

### How to Run

1. **Environment:** Ensure you have .NET SDK installed.
2. **Navigate:** Open your terminal in the project folder: cd lab5.
3. **Build (Optional):** dotnet build lab5.csproj.
4. **Run:** Execute the application using: dotnet run --project lab5.csproj.