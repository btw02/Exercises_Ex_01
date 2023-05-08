namespace Ex_01_TextFileWordCounter
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string folderPath;
                do
                {
                    // Pobiera ścieżkę do folderu od użytkownika
                    Console.Write("Podaj ścieżkę do katalogu: "); // (użytkownik musi sam wprowadzić ścieżkę, np: "C:\folder_do_testowania_Ex_01" )
                    folderPath = Console.ReadLine().Trim();
                }
                while (!Directory.Exists(folderPath)); // Sprawdza czy ta ścieżka istnieje

                // Znajduje pliki tekstowe w folderze i liczy ilość słów
                int totalWordCount = 0;
                string[] textFiles = Directory.GetFiles(folderPath, "*.txt");
                if (textFiles.Length == 0)
                {
                    Console.WriteLine("Nie znaleziono plików tekstowych w podanym folderze.");
                    return;
                }
                foreach (string file in textFiles)
                {
                    int wordCount = GetWordCount(file);
                    totalWordCount += wordCount;
                    Console.WriteLine("Plik: {0} -- Liczba słów: {1}", Path.GetFileName(file), wordCount);
                }

                Console.WriteLine("Łączna liczba słów we wszystkich plikach: {0}", totalWordCount); // Wyświetla łączną ilość słów we wszystkich plikach

            }
            catch (Exception plsDontBreak) // szybko zrobiona próba łapania błędów, jeśli jakieś wystąpią
            {
                Console.WriteLine("Wystąpił błąd: " + plsDontBreak.Message);
            }
            finally
            {
                // Zatrzymanie konsoli
                Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć.");
                Console.ReadKey();
            }
        }

        static int GetWordCount(string filePath)
        {
            // Odczytuje zawartość pliku i dzieli ją na słowa
            string content = File.ReadAllText(filePath);
            string[] words = content.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}
