using System;
using System.Text;

namespace TextModeApp
{
    public static class GameWorld
    {
        private const ConsoleColor DefaultColor = ConsoleColor.White;
        private const ConsoleColor BannerColor = ConsoleColor.Cyan;
        public static bool ContinueGame = true;
        private static readonly Random RandomNumberSeed = new Random();

        public static void StartGame()
        {
            
            
            ShowStartBanner();
        }

        public static void CreateAccount()
        {
            
        }

        public static void ShowStartBanner()
        {
            DisplayBanner("Welcome to TextMode. A silly little text-based RPG engine.");
        }

        public static void DisplayBanner(string bannerText)
        {
            Console.ForegroundColor = BannerColor;
            DisplayBannerBurst();
            DisplayBannerRail();
            LineBreaker(bannerText, true);
            DisplayBannerRail();
            DisplayBannerBurst();
            Console.WriteLine();
            Console.ForegroundColor = DefaultColor;
        }

        public static void LineBreaker(string breakText, bool addBannerRails = false)
        {
            var textArray = breakText.Split(' '); //Split on spaces (going cheap here)
            var buffer = new StringBuilder();

            foreach (var word in textArray)
            {
                if (buffer.Length + word.Length + 4 < Console.WindowWidth - 1)
                {
                    buffer.Append(word + " ");
                }
                else
                {
                    if (addBannerRails)
                    {
                        AddBannerPadding(buffer);
                    }
                    else
                    {
                        Console.WriteLine(" " + buffer);
                    }
                    buffer.Clear();
                    buffer.Append(word + " ");
                }
            }
            if (addBannerRails)
            {
                AddBannerPadding(buffer);
            }
            else
            {
                Console.WriteLine(" " + buffer);
            }
            
        }

        public static void AddBannerPadding(StringBuilder bufferText)
        {
            var availableSpace = (Console.WindowWidth - bufferText.Length - 5);
            for (int i = 0; i < availableSpace; i++)
            {
                bufferText.Append(" ");
            }
            Console.ForegroundColor = BannerColor;
            Console.Write("# ");
            Console.ForegroundColor = DefaultColor;
            Console.Write(bufferText);
            Console.ForegroundColor = BannerColor;
            Console.Write(" #\r\n");
            Console.ForegroundColor = DefaultColor;
        }

        public static void CreateCharacter()
        {
            Console.WriteLine("Please enter your character's name:");
            Console.Write(">");
            var username = Console.ReadLine();
            Console.Clear();
            ShowStartBanner();
            Console.WriteLine(" Welcome to Grenthak " + username + ". We certainly hope you enjoy your stay.");
            Console.WriteLine("\r\n Press Enter to Continue.");
            Console.ReadLine();

        }

        public static void ListRoom(string playerAction, ConsoleColor color = ConsoleColor.White)
        {

            Console.Clear();

            DisplayBanner("You are in a small dimly lit room. " +
                          "To the north, you see a window that is boarded over. " +
                          "To the east, you see a wooden door that has seen better days. " +
                          "To the south, you see a wooden wall that is bare of any items but is obviously aged. " +
                          "To the west, you see a brand new door that appears rather immaculate.");

            Console.ForegroundColor = color;

            LineBreaker(playerAction);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\r\n What do you want to do?");
            Console.Write(" >");
        }


        public static void DisplayBannerBurst()
        {
            Console.ForegroundColor = BannerColor;
            
            int i;
            var consoleWidth = Console.WindowWidth - 1;
            
            var windowOutput = "";
            for (i = 0; i < consoleWidth; i++)
            {
                windowOutput += "#";
            }
            Console.WriteLine(windowOutput);

            Console.ForegroundColor = DefaultColor;
        }


        public static void DisplayBannerRail()
        {
            Console.ForegroundColor = BannerColor;
            var windowOutput = "";
            int i;
            var consoleWidth = Console.WindowWidth - 1;
            for (i = 0; i < consoleWidth; i++)
            {
                if (i == 0 || i == consoleWidth - 1)
                {
                    windowOutput += "#";
                }
                else
                {
                    windowOutput += " ";
                }
            }
            Console.WriteLine(windowOutput);

            Console.ForegroundColor = DefaultColor;
        }

        public static void ParseInput()
        {
            while (ContinueGame)
            {
                var readLine = Console.ReadLine();

                if (readLine == null) continue;

                switch (readLine.ToLower())
                {
                    case "fart":
                        switch (RandomNumberSeed.Next(1, 6))
                        {
                            case 1:
                                ListRoom("A thunderous sound, similar to ripping paper, fills the room with sound.  Your trousers fall to the floor in tatters.", ConsoleColor.Gray);
                                break;
                            case 2:
                                ListRoom("The sound and smell of two mating pigs erupts into the room. Both appear to have originated from you.", ConsoleColor.Gray);
                                break;
                            case 3:
                                ListRoom("Wood shavings on the floor begin to curl of their own accord. You begin to smell smoke.", ConsoleColor.Gray);
                                break;
                            case 4:
                                ListRoom("An odor rivaling a giant cart of horse manure filled with rotting corpses causes the air to turn thick and rancid. It appears to be emanating from you.", ConsoleColor.Gray);
                                break;
                            default:
                                ListRoom("A warm pungent breeze fills the room. It appears to be emanating from you.", ConsoleColor.Gray);
                                break;
                        }
                        
                        
                    break;
                    case "exit":
                        ContinueGame = false;
                        Environment.Exit(0);
                        break;
                    case "help":
                        ListRoom(
                            "The list of commands are: Fart, Exit, Help. As new commands are added, this list will expand.");
                        break;
                    default:
                        //Do nothing.
                        ListRoom("");
                        break;
                }
            }
            
        }
    }
}
