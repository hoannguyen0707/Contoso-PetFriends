internal class Program
{
    private static void Main(string[] args)
    {

        //show menu and let user select the menu
        string? readResult;
        string menuSelection = "";

        //the ourAnimal array will store the following
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";
        string suggestedDonation = "";

        //variables that support data entry
        int maxPets = 8;
        int maxPetsInfo = 7;

        //array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, maxPetsInfo];

        //array used to store each animal information
        string[] eachAnimalInfo;

        //support to store the suggested donation to decimal donation


        //initial animals list before display the menu
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    suggestedDonation = "85.00";
                    break;
                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "loki";
                    suggestedDonation = "49.99";
                    break;
                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "Puss";
                    suggestedDonation = "40.00";
                    break;
                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "?";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    suggestedDonation = "";
                    break;
                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    suggestedDonation = "";
                    break;
            }

            //format the suggested donation
            decimal decimalDonation;
            if (!decimal.TryParse(suggestedDonation, out decimalDonation))
            {
                decimalDonation = 45.00m; //if guggested donation is not a number, default is 45.00
            }

            //string array to store each animal information
            eachAnimalInfo = new string[]{
                "ID #: " + animalID,
                "Species: " + animalSpecies,
                "Age: " + animalAge,
                "Nickname: " + animalNickname,
                "Physical description: " + animalPhysicalDescription,
                "Personality: " + animalPersonalityDescription,
                $"Suggested Donation:  {decimalDonation:C2}"
            };

            //assign each animal information to the our animal array
            for (int j = 0; j < eachAnimalInfo.Length; j++)
            {
                ourAnimals[i, j] = eachAnimalInfo[j];
            }

        }


        // display the menu to the user 
        do
        {
            //Console.Clear(); //use to run with command dotnet run
            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Display all dogs with a specified characteristic");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Edit an animal's age");
            Console.WriteLine(" 6. Edit an animal's personality description");
            Console.WriteLine(" 7. Display all cats with a specified characteristic");
            Console.WriteLine(" 8. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.Trim().ToLower();
            }

            switch (menuSelection)
            {
                case "1":
                    //list all of the currrent pet information
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < maxPetsInfo; j++)
                            {
                                Console.WriteLine($"{ourAnimals[i, j]}");
                            }
                        }
                    }
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "2":
                    // add a new animal friend to the ourAnimals array
                    string anotherPet = "y";
                    int petCount = 0;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            petCount += 1;
                        }
                    }

                    if (petCount < maxPets)
                    {
                        Console.WriteLine($"We have {petCount} pets in house and can add {maxPets - petCount} pets for further.");
                    }


                    while (anotherPet == "y")
                    {
                        // get species (cat or dog) - string animalSpecies is a required field 
                        bool validEntry = false;
                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalSpecies = readResult.Trim().ToLower();

                                if (animalSpecies != "dog" && animalSpecies != "cat")
                                {
                                    validEntry = false;
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        }
                        while (validEntry == false);
                        // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        //get the pet's age. can be ? at initial entry.
                        do
                        {
                            //int petAge;
                            Console.WriteLine("Please input the pet's age, can be ? if unknown.");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult.Trim();
                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out int petAge);
                                }
                                else
                                    validEntry = true;
                            }
                        } while (validEntry == false);

                        // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.Trim();
                                if (animalPhysicalDescription == "")
                                {
                                    animalPhysicalDescription = "tbd";
                                }
                            }
                        }
                        while (animalPhysicalDescription == "");

                        // get a description of the pet's personality - animalPersonalityDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.Trim();
                                if (animalPersonalityDescription == "")
                                    animalPersonalityDescription = "tbd";
                            }
                        }
                        while (animalPersonalityDescription == "");

                        // get the pet's nickname. animalNickname can be blank.
                        do
                        {
                            Console.WriteLine("Enter the pet's nickname.");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult.Trim();
                                if (animalNickname == "")
                                {
                                    animalNickname = "tbd";
                                }
                            }

                        }
                        while (animalNickname == "");

                        //add suggested Donation
                        decimal decimalDonation = 45.00m;
                        Console.WriteLine("Please help to donate to support the pets.");
                        readResult = Console.ReadLine();
                        if (readResult != null && !decimal.TryParse(readResult, out decimalDonation))
                        {
                            decimalDonation = 45.00m;
                        }
                        else if (string.IsNullOrWhiteSpace(readResult))
                        {
                            decimalDonation = 45.00m;
                        }



                        // store the pet information in the ourAnimals array (zero based)
                        ourAnimals[petCount, 0] = "ID #: " + animalID;
                        ourAnimals[petCount, 1] = "Species: " + animalSpecies; ;
                        ourAnimals[petCount, 2] = "Age: " + animalAge;
                        ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                        ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                        ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                        ourAnimals[petCount, 6] = $"suggested Donation: {decimalDonation:C2}";

                        // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                        petCount += 1;

                        // check maxPet limit
                        if (petCount < maxPets)
                        {
                            //another pet
                            Console.WriteLine("Do you want to add another pet (y/n).");

                            do
                            {
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    anotherPet = readResult.Trim().ToLower();
                                }

                            }
                            while (anotherPet != "y" && anotherPet != "n");
                        }
                    }


                    if (petCount >= maxPets)
                    {
                        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                    }

                    break;
                case "3":
                    Console.WriteLine("You selected option 3");
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("You selected option 4");
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("You selected option 5");
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("You selected option 6");
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "7":
                    Console.WriteLine("You selected option 7");
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "8":
                    Console.WriteLine("You selected option 8");
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                default:
                    break;
            }

        } while (menuSelection != "exit");
        Console.WriteLine($"You enterd {menuSelection}. Press any key to quick.");
        readResult = Console.ReadLine();

    }
}