using System.Text;
using System.IO;
using CS_Lab1;
class Program
{
    private const string ValidAminoAcids = "ACDEFGHIKLMNPQRSTVWY";

    static bool IsValidAminoAcidSequence(string sequence)
    {
        foreach (char c in sequence)
        {
            if (ValidAminoAcids.IndexOf(c) == -1)
            {
                return false;
            }
        }
        return true;
    }

    static string RLDecoding(string amino_acids)
    {
        if (string.IsNullOrEmpty(amino_acids))
            return amino_acids;

        var result = new StringBuilder();
        var currentNumber = new StringBuilder();

        foreach (char c in amino_acids)
        {
            if (char.IsDigit(c))
            {
                currentNumber.Append(c);
            }
            else
            {
                if (currentNumber.Length > 0)
                {
                    int count = int.Parse(currentNumber.ToString());
                    result.Append(c, count);
                    currentNumber.Clear();
                }
                else
                {
                    result.Append(c);
                }
            }
        }

        return result.ToString();
    }

    static string RLEncoding(string amino_acids)
    {
        if (string.IsNullOrEmpty(amino_acids))
            return amino_acids;

        var result = new StringBuilder();
        int count = 1;
        char currentChar = amino_acids[0];

        for (int i = 1; i < amino_acids.Length; i++)
        {
            if (amino_acids[i] == currentChar)
            {
                count++;
            }
            else
            {
                if (count > 2)
                {
                    result.Append(count);
                }
                result.Append(currentChar, count > 2 ? 1 : count);

                currentChar = amino_acids[i];
                count = 1;
            }
        }

        if (count > 2)
        {
            result.Append(count);
        }
        result.Append(currentChar, count > 2 ? 1 : count);

        return result.ToString();
    }

    static string SearchOperation(List<GeneticData> data, string searchSequence, int operationNumber)
    {
        var result = new StringBuilder();
        string decodedSearchSequence = RLDecoding(searchSequence);

        result.AppendLine($"{operationNumber:D3}   search   {searchSequence}");
        result.AppendLine("organism\t\t\tprotein");

        bool found = false;
        foreach (var item in data)
        {
            string decodedProteinSequence = RLDecoding(item.amino_acids);

            if (decodedProteinSequence.Contains(decodedSearchSequence))
            {
                result.AppendLine($"{item.organism}\t\t{item.protein}");
                found = true;
            }
        }

        if (!found)
        {
            result.AppendLine("NOT FOUND");
        }

        return result.ToString();
    }

    static string DiffOperation(List<GeneticData> data, string protein1, string protein2, int operationNumber)
    {
        var result = new StringBuilder();
        result.AppendLine($"{operationNumber:D3}   diff   {protein1}   {protein2}");
        result.AppendLine("amino-acids difference:");

        GeneticData data1 = new GeneticData();
        GeneticData data2 = new GeneticData();
        bool found1 = false, found2 = false;

        foreach (var d in data)
        {
            if (d.protein == protein1)
            {
                data1 = d;
                found1 = true;
            }
            if (d.protein == protein2)
            {
                data2 = d;
                found2 = true;
            }
        }

        if (!found1 || !found2)
        {
            string missing = "";
            if (!found1) missing += protein1;
            if (!found2)
            {
                if (missing != "") missing += ", ";
                missing += protein2;
            }
            result.AppendLine($"MISSING {missing}");
            return result.ToString();
        }

        string seq1 = RLDecoding(data1.amino_acids);
        string seq2 = RLDecoding(data2.amino_acids);

        int minLength = Math.Min(seq1.Length, seq2.Length);
        int differences = Math.Abs(seq1.Length - seq2.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (seq1[i] != seq2[i])
            {
                differences++;
            }
        }

        result.AppendLine(differences.ToString());
        return result.ToString();
    }

    static string ModeOperation(List<GeneticData> data, string protein, int operationNumber)
    {
        var result = new StringBuilder();
        result.AppendLine($"{operationNumber:D3}   mode   {protein}");
        result.AppendLine("amino-acid occurs:");

        GeneticData proteinData = new GeneticData();
        bool found = false;

        foreach (var d in data)
        {
            if (d.protein == protein)
            {
                proteinData = d;
                found = true;
                break;
            }
        }

        if (!found)
        {
            result.AppendLine($"MISSING {protein}");
            return result.ToString();
        }

        string sequence = RLDecoding(proteinData.amino_acids);

        int[] frequency = new int[ValidAminoAcids.Length];

        foreach (char c in sequence)
        {
            int index = ValidAminoAcids.IndexOf(c);
            if (index >= 0)
            {
                frequency[index]++;
            }
        }

        int maxFrequency = 0;
        foreach (int count in frequency)
        {
            if (count > maxFrequency)
            {
                maxFrequency = count;
            }
        }

        char mostFrequentChar = ' ';
        for (int i = 0; i < frequency.Length; i++)
        {
            if (frequency[i] == maxFrequency)
            {
                mostFrequentChar = ValidAminoAcids[i];
                break;
            }
        }

        result.AppendLine($"{mostFrequentChar}\t\t{maxFrequency}");
        return result.ToString();
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== ГЕНЕТИЧЕСКИЙ ПОИСК ===");
            Console.WriteLine("Выберите пример для выполнения:");
            Console.WriteLine("1. sequences.0.txt / commands.0.txt");
            Console.WriteLine("2. sequences.1.txt / commands.1.txt");
            Console.WriteLine("3. sequences.2.txt / commands.2.txt");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор (1-4): ");

            int choice = Convert.ToInt32(Console.ReadLine());


            if (choice == 4)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            int exampleNumber = choice - 1;
            string sequencesFile = $"sequences.{exampleNumber}.txt";
            string commandsFile = $"commands.{exampleNumber}.txt";
            string outputFile = $"genedata.{exampleNumber}.txt";

            try
            {

                if (!File.Exists(sequencesFile) || !File.Exists(commandsFile))
                {
                    Console.WriteLine($"Файлы для примера {exampleNumber} не найдены!");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    continue;
                }

                List<GeneticData> geneticData = new List<GeneticData>();
                bool allSequencesValid = true;
                List<string> invalidProteins = new List<string>();

                using (StreamReader reader = new StreamReader(sequencesFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('\t');
                        if (parts.Length >= 3)
                        {
                            string decodedSequence = RLDecoding(parts[2]);
                            if (!IsValidAminoAcidSequence(decodedSequence))
                            {
                                allSequencesValid = false;
                                invalidProteins.Add(parts[0]);
                            }

                            GeneticData data = new GeneticData
                            {
                                protein = parts[0],
                                organism = parts[1],
                                amino_acids = parts[2]
                            };
                            geneticData.Add(data);
                        }
                    }
                }

                if (!allSequencesValid)
                {
                    Console.WriteLine("ОШИБКА: Обнаружены неправильные аминокислотные последовательности:");
                    foreach (string protein in invalidProteins)
                    {
                        Console.WriteLine($"- {protein}");
                    }
                    continue;
                }

                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine("Anton Klyzhuk");
                    writer.WriteLine("Genetic Searching");
                    writer.WriteLine("--------------------------------------------------------------------------");

                    int operationNumber = 1;
                    using (StreamReader commandsReader = new StreamReader(commandsFile))
                    {
                        string commandLine;
                        while ((commandLine = commandsReader.ReadLine()) != null)
                        {
                            string[] commandParts = commandLine.Split('\t');
                            if (commandParts.Length == 0) continue;

                            string operation = commandParts[0];
                            string operationResult = "";

                            switch (operation)
                            {
                                case "search":
                                    if (commandParts.Length >= 2)
                                    {
                                        operationResult = SearchOperation(geneticData, commandParts[1], operationNumber);
                                    }
                                    break;

                                case "diff":
                                    if (commandParts.Length >= 3)
                                    {
                                        operationResult = DiffOperation(geneticData, commandParts[1], commandParts[2], operationNumber);
                                    }
                                    break;

                                case "mode":
                                    if (commandParts.Length >= 2)
                                    {
                                        operationResult = ModeOperation(geneticData, commandParts[1], operationNumber);
                                    }
                                    break;
                            }

                            writer.Write(operationResult);
                            writer.WriteLine("--------------------------------------------------------------------------");
                            operationNumber++;
                        }
                    }
                }

                Console.WriteLine($"Обработка завершена. Результат записан в {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");

            }
        }
    }
}