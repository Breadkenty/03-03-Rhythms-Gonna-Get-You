using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _03_03_Rhythms_Gonna_Get_You
{
    class Program
    {
        public static string AskForString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static int AskForInt(string prompt)
        {
            Console.WriteLine(prompt);
            int result = 0;
            bool goodInput = false;

            while (!goodInput)
            {
                var input = Console.ReadLine();
                goodInput = int.TryParse(input, out result);

                if (!goodInput)
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

            return result;
        }

        public static bool AskForBool(string prompt)
        {
            bool result = false;
            bool goodInput = false;

            while (!goodInput)
            {
                var input = AskForKey(prompt);
                goodInput = "yn".Contains(input);

                if (!goodInput)
                {
                    Console.WriteLine("\nInvalid key!");
                }

                if (input == 'y')
                {
                    result = true;
                }

                if (input == 'n')
                {
                    result = false;
                }
            }

            return result;
        }

        public static DateTime AskForDateTime(string prompt)
        {
            Console.WriteLine(prompt);
            DateTime result;
            var input = Console.ReadLine();
            var goodInput = DateTime.TryParse(input, out result);

            while (!goodInput)
            {
                Console.WriteLine("Invalid input!");
                input = Console.ReadLine();
                goodInput = DateTime.TryParse(input, out result);
            }

            return result;
        }

        public static char AskForKey(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadKey().KeyChar;
            return input;
        }

        public static void PressAnyKey(string prompt)
        {
            Console.WriteLine(prompt);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var context = new BandDatabaseContext();
            var bands = context.Bands.Include(band => band.Albums);

            bool applicationOpen = true;
            while (applicationOpen)
            {
                Console.Clear();
                Console.WriteLine("♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪");
                Console.WriteLine("Welcome to the Rhythm's Gonna Run You Database!");
                Console.WriteLine("♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪");
                Console.WriteLine();
                Console.WriteLine($"1 - Add a new band");
                Console.WriteLine($"2 - Add an album to a band");
                Console.WriteLine($"3 - Delete a band");
                Console.WriteLine($"4 - Sign/let go of a band");
                Console.WriteLine($"5 - View all bands");
                Console.WriteLine($"6 - View albums by band");
                Console.WriteLine($"7 - View all albums");
                Console.WriteLine($"8 - View all signed/unsigned bands");
                Console.WriteLine($"Q - quit the application");
                Console.WriteLine();
                var mainMenuInput = AskForKey("Choose an option: ");
                var goodMenuInput = "12345678q".Contains(mainMenuInput);

                if (mainMenuInput == '1')
                {
                    Console.Clear();
                    bool addingBand = true;
                    while (addingBand)
                    {
                        var userInput = AskForKey("Would you like to add a band? Y/N: ");
                        var goodUserInput = "yn".Contains(userInput);

                        if (userInput == 'y')
                        {
                            var bandNameInput = AskForString("\nWhat is the name of the band?");
                            var bandCountryInput = AskForString($"\nWhat country is {bandNameInput} from?");
                            var bandMemberAmountInput = AskForInt($"\nHow many members are in {bandNameInput}?");
                            var bandURLInput = AskForString($"\nWhat is the website URL for {bandNameInput}?");
                            var bandStyleInput = AskForString($"\nWhat style does {bandNameInput} have?");
                            var bandSignedInput = AskForBool($"\n\nIs {bandNameInput} signed? Y/N: ");
                            var bandContactInput = AskForString($"\nWho can we contact about {bandNameInput}?");
                            var bandContactNumberInput = AskForString($"\nWhat is {bandContactInput}'s number?");

                            var newBand = new Band()
                            {
                                Name = bandNameInput,
                                CountryOfOrigin = bandCountryInput,
                                NumberOfMembers = bandMemberAmountInput,
                                Website = bandURLInput,
                                Style = bandStyleInput,
                                IsSigned = bandSignedInput,
                                ContactName = bandContactInput,
                                ContactPhoneNumber = bandContactNumberInput
                            };

                            context.Bands.Add(newBand);
                            context.SaveChanges();

                            PressAnyKey($"Great, we've added {bandNameInput} into the database. Press any key to return to the main menu...");
                            addingBand = false;
                        }

                        if (userInput == 'n')
                        {
                            addingBand = false;
                        }

                        if (!goodUserInput)
                        {
                            Console.WriteLine("\nInvalid Input!");
                        }
                    }
                }

                if (mainMenuInput == '2')
                {
                    Console.Clear();
                    bool addingAlbum = true;

                    while (addingAlbum)
                    {
                        var userInput = AskForKey("Would you like to add an album to a band? Y/N: ");
                        var goodUserInput = "yn".Contains(userInput);

                        if (userInput == 'y')
                        {
                            var bandNameInput = AskForString("\nWhich band do you want to add the album to?");
                            var bandExists = bands.Any(band => band.Name == bandNameInput);
                            var selectedBand = bands.FirstOrDefault(band => band.Name == bandNameInput);

                            if (bandExists)
                            {
                                var albumNameInput = AskForString($"\nWhat is the album title?");
                                var albumExplicitInput = AskForBool($"\nIs {albumNameInput} explicit? Y/N: ");
                                var albumReleaseDateInput = AskForDateTime($"\n\nWhen was {albumNameInput} released? Enter a response in the format: MM/DD/YYYY ");

                                var newAlbum = new Album()
                                {
                                    Title = albumNameInput,
                                    IsExplicit = albumExplicitInput,
                                    ReleaseDate = albumReleaseDateInput,
                                    BandId = selectedBand.Id
                                };

                                context.Albums.Add(newAlbum);
                                context.SaveChanges();

                                PressAnyKey($"\nGreat, we've added {albumNameInput} to {bandNameInput}.");
                                addingAlbum = false;
                            }

                            if (!bandExists)
                            {
                                Console.WriteLine("The band does not exist in the database.");
                            }
                        }

                        if (userInput == 'n')
                        {
                            addingAlbum = false;
                        }

                        if (!goodUserInput)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                }

                if (mainMenuInput == '3')
                {
                    Console.Clear();
                    bool deletingBand = true;

                    while (deletingBand)
                    {
                        var userInput = AskForKey("Would you like to delete a band? Y/N: ");
                        var goodUserInput = "yn".Contains(userInput);

                        if (userInput == 'y')
                        {
                            var bandNameInput = AskForString("\nWhich band do you want to delete?");
                            var bandExists = bands.Any(band => band.Name == bandNameInput);
                            var selectedBand = bands.FirstOrDefault(band => band.Name == bandNameInput);

                            if (bandExists)
                            {
                                userInput = AskForKey($"Are you sure you want to delete {bandNameInput}? This will also delete all of the albums by the band. Y/N: ");
                                goodUserInput = "yn".Contains(userInput);

                                if (userInput == 'y')
                                {
                                    userInput = AskForKey("\nAre you reeeeeeally sure you want to delete {bandNameInput} from the database? Y/N: ");
                                    goodUserInput = "yn".Contains(userInput);

                                    if (userInput == 'y')
                                    {
                                        foreach (var album in selectedBand.Albums)
                                        {
                                            context.Albums.Remove(album);
                                        }

                                        context.Bands.Remove(selectedBand);
                                        context.SaveChanges();

                                        PressAnyKey($"\nWe've deleted {bandNameInput} from our database. Press any key to continue...");
                                        deletingBand = false;
                                    }

                                    if (userInput == 'n')
                                    {
                                        deletingBand = false;
                                    }

                                    if (!goodUserInput)
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                }

                                if (userInput == 'n')
                                {
                                    deletingBand = false;
                                }

                                if (!goodUserInput)
                                {
                                    Console.WriteLine("Invalid input!");
                                }
                            }

                            if (!bandExists)
                            {
                                Console.WriteLine("The band does not exist in the database.");
                            }
                        }

                        if (userInput == 'n')
                        {
                            deletingBand = false;
                        }

                        if (!goodUserInput)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                }

                if (mainMenuInput == '4')
                {
                    bool signingBand = true;
                    while (signingBand)
                    {
                        Console.Clear();
                        var userInput = AskForKey("\nWould you like to sign or let go of a band?\nS - Sign | L - Let go | M - Main Menu ");
                        var goodUserInput = "slm".Contains(userInput);

                        if (userInput == 's')
                        {
                            var bandNameInput = AskForString("\n\nWhich band do you want to sign?");
                            var bandExists = bands.Any(band => band.Name == bandNameInput);
                            var selectedBand = bands.FirstOrDefault(band => band.Name == bandNameInput);

                            if (bandExists)
                            {
                                bool confirming = true;

                                while (confirming)
                                {
                                    userInput = AskForKey($"\nDo you want to sign {bandNameInput}? Y/N: ");
                                    goodUserInput = "yn".Contains(userInput);

                                    if (userInput == 'y')
                                    {
                                        selectedBand.IsSigned = true;
                                        context.SaveChanges();

                                        PressAnyKey($"\nWe've signed {bandNameInput}. Press any key to continue...");
                                        confirming = false;
                                        signingBand = false;
                                    }

                                    if (userInput == 'n')
                                    {
                                        confirming = false;
                                    }

                                    if (!goodUserInput)
                                    {
                                        PressAnyKey($"\nInvalid input! Press any key to continue...");
                                    }
                                }
                            }

                            if (!bandExists)
                            {
                                PressAnyKey($"\n{bandNameInput} does not exist in the database. Press any key to continue...");
                            }
                        }

                        if (userInput == 'l')
                        {
                            var bandNameInput = AskForString("\n\nWhich band do you want to let go?");
                            var bandExists = bands.Any(band => band.Name == bandNameInput);
                            var selectedBand = bands.FirstOrDefault(band => band.Name == bandNameInput);

                            if (bandExists)
                            {
                                bool confirming = true;
                                while (confirming)
                                {
                                    userInput = AskForKey($"\nDo you want to let {bandNameInput} go? Y/N: ");
                                    goodUserInput = "yn".Contains(userInput);

                                    if (userInput == 'y')
                                    {
                                        selectedBand.IsSigned = false;
                                        context.SaveChanges();

                                        PressAnyKey($"\nWe've let {bandNameInput} go. Press any key to continue...");
                                        confirming = false;
                                        signingBand = false;
                                    }

                                    if (userInput == 'n')
                                    {
                                        confirming = false;
                                    }

                                    if (!goodUserInput)
                                    {
                                        PressAnyKey($"\nInvalid input! Press any key to continue...");
                                    }
                                }
                            }

                            if (!bandExists)
                            {
                                PressAnyKey($"\n{bandNameInput} does not exist in the database. Press any key to continue...");
                            }
                        }

                        if (userInput == 'm')
                        {
                            signingBand = false;
                        }

                        if (!goodUserInput)
                        {
                            Console.WriteLine("\nInvalid input!");
                        }
                    }
                }

                if (mainMenuInput == '5')
                {
                    Console.Clear();
                    Console.WriteLine($"There are a total of {bands.Count()} bands in the database:\n");

                    foreach (var band in bands)
                    {
                        Console.WriteLine($"* -- {band.Name}");
                    }

                    PressAnyKey("\nPress any key to continue...");
                }

                if (mainMenuInput == '6')
                {
                    bool viewingAlbums = true;
                    while (viewingAlbums)
                    {
                        Console.Clear();
                        var bandNameInput = AskForString("Which band's album did you want to see? Type 'menu' to go back to the main menu...\n");
                        var bandExists = bands.Any(band => band.Name == bandNameInput);
                        var selectedBand = bands.FirstOrDefault(band => band.Name == bandNameInput);

                        if (bandExists)
                        {
                            Console.WriteLine($"\nThere are {selectedBand.Albums.Count()} albums by {bandNameInput}:\n");

                            foreach (var album in selectedBand.Albums)
                            {
                                Console.WriteLine($"* -- {album.Title}");
                            }

                            PressAnyKey("\nPress any key to continue...");
                        }

                        if (!bandExists && bandNameInput != "menu")
                        {
                            PressAnyKey($"\n{bandNameInput} does not exist in the database. Press any key to continue...");
                        }

                        if (bandNameInput == "menu")
                        {
                            viewingAlbums = false;
                        }
                    }
                }

                if (mainMenuInput == '7')
                {
                    Console.Clear();
                    Console.WriteLine($"Here are all of the albums in the database ordered by the release date:\n");

                    var albumsOrderedByReleaseDate = context.Albums.OrderBy(album => album.ReleaseDate);

                    foreach (var album in albumsOrderedByReleaseDate)
                    {
                        Console.WriteLine($"* -- {album.ReleaseDate.ToString("MM/dd/yyyy")} ----- \"{album.Title}\"");
                    }

                    PressAnyKey("\nPress any key to continue...");
                }

                if (mainMenuInput == '8')
                {
                    bool viewingSignedBands = true;

                    while (viewingSignedBands)
                    {
                        Console.Clear();
                        var userInput = AskForKey("S - all signed bands | U - all unsigned bands | M -  main menu ");
                        var goodUserInput = "sum".Contains(userInput);

                        if (userInput == 's')
                        {
                            Console.WriteLine($"\n\nHere are all of the signed bands in the database: \n");

                            var signedBands = bands.Where(band => band.IsSigned == true);

                            foreach (var band in signedBands)
                            {
                                Console.WriteLine($"* -- {band.Name}");
                            }

                            PressAnyKey("\nPress any key to continue...");
                        }

                        if (userInput == 'u')
                        {
                            Console.WriteLine($"\n\nHere are all of the bands that are not signed in the database: \n");

                            var unsignedBands = bands.Where(band => band.IsSigned == false);

                            foreach (var band in unsignedBands)
                            {
                                Console.WriteLine($"* -- {band.Name}");
                            }

                            PressAnyKey("\nPress any key to continue...");
                        }

                        if (userInput == 'm')
                        {
                            viewingSignedBands = false;
                        }

                        if (!goodUserInput)
                        {
                            PressAnyKey("\nInvalid input! Press any key to continue...");
                        }
                    }
                }

                if (mainMenuInput == 'q')
                {
                    Console.Clear();
                    PressAnyKey("See ya again real soon~♪");
                    applicationOpen = false;
                }

                if (!goodMenuInput)
                {
                    PressAnyKey("\nInvalid Input! Press any key to try again...");
                }
            }
        }
    }
}
