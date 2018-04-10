using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Petar.IFMO.sem_2.programming.lab_1
    {

    class Program
        {

        #region Fields

        private static String input;
        private static Boolean toExit, toLoop, bookFound;
        private static String name, author, annotation, ISBN, publicationDate;

        private static List<Book> Bookshelf = new List<Book>();
        private static List<KeyboardOccurency> KeywordOccurencies = new List<KeyboardOccurency>();

        #endregion

        #region Methods

        static void Main(string[] args)
            {
            // Exit indicator initializing
            toExit = false;
            // Loop while the indicator is false
            while (toExit == false)
                {
                PrintMenu();
                ReadMenuAction();
                Console.Clear();
                switch (input)
                    {
                    case "1":
                        // Print a message
                        Console.WriteLine("ACTION: add a book in the bookshelf");
                        Console.WriteLine("===================================\n");
                        Console.WriteLine("Adding book #" + (Bookshelf.Count + 1).ToString());
                        // Input all the book characteristics
                        name = ReadBookCharacteristics("name");
                        author          = ReadBookCharacteristics("author");
                        annotation      = ReadBookCharacteristics("annotation");
                        ISBN            = ReadBookCharacteristics("ISBN");
                        publicationDate = ReadBookCharacteristics("publicationDate");
                        // Make a new book
                        Bookshelf.Add(new Book(name, author, annotation, ISBN, publicationDate));
                        break;
                    case "2":
                        // Print a message
                        Console.WriteLine("ACTION: search for a book by ISBN");
                        Console.WriteLine("=================================\n");
                        // Input ISBN to be found
                        input = ReadBookCharacteristics("ISBN");
                        Console.WriteLine();
                        // Search for a book with the ISBN inputed
                        bookFound = false;
                        for (Int32 i = 0; i < Bookshelf.Count; i++)
                            {
                            if (input == Bookshelf[i].ISBN)
                                {
                                Console.WriteLine("BOOK #" + (i + 1).ToString());
                                PrintBookCharacteristic(i, "name");
                                PrintBookCharacteristic(i, "author");
                                PrintBookCharacteristic(i, "annotation");
                                PrintBookCharacteristic(i, "ISBN");
                                PrintBookCharacteristic(i, "publicationDate");
                                bookFound = true;
                                break;
                                }
                            }
                        if (bookFound == false)
                            {
                            Console.WriteLine("Book with the ISBN inputed not found");
                            }
                        break;
                    case "3":
                        // Print a message
                        Console.WriteLine("ACTION: sort books by keyword occurencies");
                        Console.WriteLine("=========================================\n");
                        // Input keyword
                        do
                            {
                            Console.Write("| KEYWORD: ");
                            input = Console.ReadLine();
                            }
                        while (input.Length < 1);
                        // Search for the keyword in the Bookshelf
                        Int32 count;
                        Boolean foundInAnnotation;
                        KeywordOccurencies = new List<KeyboardOccurency>();
                        for (Int32 i = 0; i < Bookshelf.Count; i++)
                            {
                            // 1. Name
                            count = Regex.Matches(Bookshelf[i].name, input).Count;
                            // 2. Author
                            count += Regex.Matches(Bookshelf[i].author, input).Count;
                            // 3. Annotation
                            foundInAnnotation = false;
                            if (Regex.Matches(Bookshelf[i].annotation, input).Count > 0)
                                {
                                count += Regex.Matches(Bookshelf[i].annotation, input).Count;
                                foundInAnnotation = true;
                                }
                            // Add the i index and count of occurencies in the KeywordOccurencies list
                            KeywordOccurencies.Add(new KeyboardOccurency(i, count, foundInAnnotation));
                            }
                        // Sort books by occurencies
                        SortBookshelfByOccurencies();
                        // Output books in a descending order
                        for (Int32 i = KeywordOccurencies.Count - 1; i > -1; i--)
                            {
                            Console.Write("BOOK #" + KeywordOccurencies[i].index.ToString() + "\t(" + KeywordOccurencies[i].count.ToString() + " occurencies, in annotation — ");
                            if (KeywordOccurencies[i].foundInAnnotation == true)
                                {
                                Console.WriteLine("YES)");
                                }
                            else
                                {
                                Console.WriteLine("NO)");
                                }
                            PrintBookCharacteristic(KeywordOccurencies[i].index, "name");
                            PrintBookCharacteristic(KeywordOccurencies[i].index, "author");
                            PrintBookCharacteristic(KeywordOccurencies[i].index, "ISBN");
                            PrintBookCharacteristic(KeywordOccurencies[i].index, "publicationDate");
                            Console.WriteLine();
                            }
                        break;
                    case "4":
                        // Print a message
                        Console.WriteLine("ACTION: exit");
                        Console.WriteLine("============");
                        toExit = true;
                        break;
                    }
                // 
                Console.Write("\n...press any key...");
                Console.ReadLine();
                Console.Clear();
                }
            // Quit the program
            Environment.Exit(0);
            }

        // Print menu
        static void PrintMenu()
            {
            Console.WriteLine("===MENU==========================");
            Console.WriteLine("1. add book in the catalogue");
            Console.WriteLine("2. search for a book by ISBN");
            Console.WriteLine("3. search for a book by keywords");
            Console.WriteLine("4. exit");
            Console.WriteLine("=================================");
            }

        // Reads user input while it is not valid
        static void ReadMenuAction()
            {
            toLoop = true;
            while (toLoop == true)
                {
                Console.Write("...");
                input = Console.ReadLine();
                if (InputValidator.CheckMenuAction(input) == true)
                    {
                    toLoop = false;
                    }
                }
            }

        static String ReadBookCharacteristics(String characteristicToInput)
            {
            toLoop = true;
            switch (characteristicToInput)
                {
                case "name":
                    while (toLoop == true)
                        {
                        Console.Write("| NAME:             ");
                        input = Console.ReadLine();
                        if (InputValidator.CheckCharacteristicInput("name", input) == true)
                            {
                            toLoop = false;
                            }
                        }
                    break;
                case "author":
                    while (toLoop == true)
                        {
                        Console.Write("| AUTHOR:           ");
                        input = Console.ReadLine();
                        if (InputValidator.CheckCharacteristicInput("author", input) == true)
                            {
                            toLoop = false;
                            }
                        }
                    break;
                case "annotation":
                    while (toLoop == true)
                        {
                        Console.Write("| ANNOTATION:       ");
                        input = Console.ReadLine();
                        if (InputValidator.CheckCharacteristicInput("annotation", input) == true)
                            {
                            toLoop = false;
                            }
                        }
                    break;
                case "ISBN":
                    while (toLoop == true)
                        {
                        Console.Write("| ISBN:             ");
                        input = Console.ReadLine();
                        if (InputValidator.CheckCharacteristicInput("ISBN", input) == true)
                            {
                            Boolean isUnique = true;
                            for (Int32 i = 0; i < Bookshelf.Count; i++)
                                {
                                if (Bookshelf[i].ISBN == input)
                                    {
                                    isUnique = false;
                                    break;
                                    }
                                }
                            if (isUnique == true)
                                {
                                toLoop = false;
                                }
                            }
                        }
                    break;
                case "publicationDate":
                    while (toLoop == true)
                        {
                        Console.Write("| PUBLICATION DATE: ");
                        input = Console.ReadLine();
                        if (InputValidator.CheckCharacteristicInput("publicationDate", input) == true)
                            {
                            toLoop = false;
                            }
                        }
                    break;
                }
            return input;
            }

        static void PrintBookCharacteristic(Int32 bookNumber, String characteristicToPrint)
            {
            switch (characteristicToPrint)
                {
                case "name":
                    Console.Write("| NAME:             ");
                    Console.WriteLine(Bookshelf[bookNumber].name);
                    break;
                case "author":
                    Console.Write("| AUTHOR:           ");
                    Console.WriteLine(Bookshelf[bookNumber].author);
                    break;
                case "annotation":
                    Console.Write("| ANNOTATION:       ");
                    Console.WriteLine(Bookshelf[bookNumber].annotation);
                    break;
                case "ISBN":
                    Console.Write("| ISBN:             ");
                    Console.WriteLine(Bookshelf[bookNumber].ISBN);
                    break;
                case "publicationDate":
                    Console.Write("| PUBLICATION DATE: ");
                    Console.WriteLine(Bookshelf[bookNumber].publicationDate);
                    break;
                }
            }

        static void SortBookshelfByOccurencies()
            {
            for (Int32 i = 0; i < KeywordOccurencies.Count; i++)
                {
                for (Int32 j = 0; j < KeywordOccurencies.Count - 1; j++)
                    {
                    if (KeywordOccurencies[j].count > KeywordOccurencies[j + 1].count)
                        {
                        var buffer = KeywordOccurencies[j + 1];
                        KeywordOccurencies[j + 1] = KeywordOccurencies[j];
                        KeywordOccurencies[j] = buffer;
                        }
                    }
                }
            }

        #endregion

        }
    }
