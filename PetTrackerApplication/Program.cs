// the ourAnimals array will store the following: 
using System.Reflection.Metadata.Ecma335;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
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
            break;
    
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:

            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}
do
{

    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    readResult = Console.ReadLine();

    switch(menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i =0; i < maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i,j]);
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;

            for (int i =0; i < maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage{(maxPets-petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;

                // get species (cat or dog) - string animalSpecies is a required field.
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult= Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            // Console.WriteLine($"You entered: {animalSpecies}.");
                            validEntry = false;
                        }
                        else
                        {
                            validEntry= true;
                        }
                    }

                } while (validEntry == false);

                // build the ID number - for example C1, C2, D3 ( for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0,1) + (petCount + 1).ToString();

                // get the pet's age. Can be ? at initial entry.
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();

                    if(readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // get a description of the pet's physical apearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }  

                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }

                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }

                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                // increment petCount (the array is zero-based, so we increment the counter after adding to the array
                petCount = petCount + 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet? (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
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
            // Ensure anaimal ages and physcial descriptions are complete
            string updatePet = "y";
            int needUpdateCount = 0;
            

            // Gets a count of how many pets have ages or physical descriptions without valid entries.
            for( int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i,0] != "ID #: " && (ourAnimals[i,2] =="Age: ?" || ourAnimals[i, 4] == "Physical description: tbd"))
                {
                    needUpdateCount+=1;
                }
            }
            Console.WriteLine($"We currently have {needUpdateCount} pets that have ages or physical descriptions that need updating.");

            // begins while loop with the count and y as conditions
            while(updatePet == "y" && needUpdateCount > 0)
            {
                bool validUpdate = false;
                // bool variable to only change the count once even if needing to update both age and physical description. It is possible an entry has an age but no description and vice versa.
                bool changedValue = false;

                // for loop to go through entries until one mising the specific data
                for (int i = 0; i < maxPets; i++)
                {
                    // checks age first
                    if (ourAnimals[i,0] !="ID #: " && (ourAnimals[i,2]=="Age: ?"))
                    {
                        do
                        {
                            int petAge;
                            Console.WriteLine($"\n\nEnter an age for ID #: {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();

                            if(readResult != null)
                            {
                                animalAge = readResult;
                                validUpdate = int.TryParse(animalAge, out petAge);
                            }
                        } while (validUpdate==false);

                        // update value in the array
                        ourAnimals[i, 2] = "Age: " + animalAge;
                        Console.WriteLine($"\n\nPet {ourAnimals[i,0]} has been updated with the age {animalAge}.");
                        
                        // subtracts update count to track if there are more pets that need updates
                        needUpdateCount--;
                        
                        // changes bool value so even if we change both items it will only subract the counter once. If age is filled in but description is not then it will subract in the description if statement.
                        changedValue = true;
                    }

                    // checks physical description
                    if (ourAnimals[i,0] != "ID #: " && (ourAnimals[i,4] =="Physical description: tbd" || ourAnimals[i,4] == "Physical description: "))
                    {
                        do
                        {
                            Console.WriteLine($"\n\nEnter a physical description for ID #:{ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");
                            readResult= Console.ReadLine();

                            // added condition of length being more than 0 char
                            if(readResult != null && readResult.Length > 0)
                            {
                                animalPhysicalDescription = readResult.ToLower();
                            }
                        } while (animalPhysicalDescription == "tbd");

                        // update array
                        ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                        Console.WriteLine($"\n\nPet {ourAnimals[i,0]} has been updated with the description {animalPhysicalDescription}");
                        // checks bool in order to subtract coutner
                        needUpdateCount = (changedValue == false) ? needUpdateCount-- : needUpdateCount;
                        /*if (changedValue == false)
                        {
                            needUpdateCount--;
                        }*/
                    }
                    // conditions for asking if they want to update another pet, to continue the statement, or break the statement because no more pets are left that need updating.
                    if (needUpdateCount > 0 && changedValue == true)
                    {
                        Console.WriteLine("Do you want to update another pet? (y/n)");

                        do
                        {
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                updatePet = readResult.ToLower();
                            }

                        } while (updatePet != "y" && updatePet != "n");
                    }
                    else if (needUpdateCount > 0 && changedValue == false)
                    {
                        continue;
                    }
                    else if (needUpdateCount == 0) break;
                }
                
            }
            if ( needUpdateCount == 0)
                {
                    Console.WriteLine("All age and physical descriptions have been successfully updated! We have no more pets that need upating, please check back later.");
                }
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            Console.WriteLine("Challenge Project - please check back to see progress");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Edit an animal's age
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Edit an animal's personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back to see progress");
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");
