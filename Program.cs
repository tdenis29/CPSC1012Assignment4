namespace CPSC1012Assignment4;
using ClientClass;

/*
    Program: BMI Status 
    Purpose: This program get a clients bmi status
    Author: Tyson Denis
    Last Modified: 2024-04-25
*/
class Program{
//  / <summary>
// / Displays the main menu options for managing clients.
// / Options include: creating new clients, showing existing ones, editing client details, and quitting the program.
// / </summary>
    static void DisplayMainMenu(){
        Console.WriteLine("[N]ew Client");
        Console.WriteLine("[S]how Client");
        Console.WriteLine("[E]dit Client");
        Console.WriteLine("[Q]uit Program");
	}
//  / <summary>
// / Displays a disclaimer warning about overwriting unsaved data and prompts the user to confirm proceeding.
// / Provides hints to edit data individually from the main menu and emphasizes the need to enter all client data.
// / Returns true if the user chooses to proceed (by entering 'y'), otherwise returns false.
// / </summary>
// / <returns>True if the user chooses to proceed, otherwise false.</returns>
    static bool NewEntryDisclaimer(){
        bool response;
        Console.WriteLine("Disclaimer: proceeding will overwrite all unsaved data.");
        Console.WriteLine("Hint: Select EDIT from the main menu instead, to change individual values.");
        Console.WriteLine("Hint: You'll need to enter ALL data for the client .");
        Console.WriteLine();
        response = Prompt("Do you wish to proceed anyway? (y/N) ").ToLower().Equals("y");
        Console.WriteLine();
        return response;
    }
// / <summary>
// / Prompts the user with a given message and validates the input string, ensuring it is not empty.
// / If the input is empty, prompts the user to enter something and retries.
// / Returns the trimmed user input string.
// / </summary>
// / <param name="prompt">The message to display as the prompt.</param>
// / <returns>The trimmed user input string.</returns>
    static string Prompt(string prompt){
        string userString;
        bool invalidInput = false;

        Console.Write(prompt);
        do{
        try{
            userString = Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(userString)){
                throw new FormatException("Please Enter something cannot be empty.");
            } else {
                invalidInput = true;
                return userString;
            }
        } catch(FormatException ex){
            Console.WriteLine(ex.Message);
            userString = "Nothing here";
        }
         } while(!invalidInput);
         return userString;
	}
// / <summary>
// / Displays the edit menu options for modifying client details.
// / Options include: editing first name, last name, weight, height, or returning to the main menu.
// / </summary>
    static void DisplayEditMenu(){
        Console.WriteLine("[F]irst Name");
        Console.WriteLine("[L]ast Name");
        Console.WriteLine("[W]eight");
        Console.WriteLine("[H]eight");
        Console.WriteLine("[R]eturn to MAIN MENU");
	}
  
// / <summary>
// / Prompts the user to enter details of a new client, including first name, last name, weight, and height.
// / Validates user input for each field and instantiates a new Client object with the provided values.
// / </summary>
// / <returns>The newly created Client object.</returns>
     static Client EnterClient(//int[] sales, string[] dates
      ){
       
      
        int userClientWeight = 0;
        int userClientHeight = 0;
        string userClientFirstName;
        string userClientLastName;
        bool firstNameGood = false;
        bool lastNameGood = false;
        bool userClientWeightGood = false;
        bool userClientHeightGood = false;
         //uncomment this when doing partB
        //int count = 0;

        do{
            userClientFirstName = Prompt("Enter Client First Name: ");
            if(!string.IsNullOrEmpty(userClientFirstName)){
                firstNameGood = true;
            }
        } while(!firstNameGood);

        //GET LastName
        do{
            userClientLastName = Prompt("Enter Client Last Name: ");
            if(!string.IsNullOrEmpty(userClientLastName)){
                lastNameGood = true;
            }
        } while(!lastNameGood);
       

       //GET Weight
        do{
            Console.Write("Please enter the clients weight in pounds: ");
            try{
                userClientWeight = Promptint();
                userClientWeightGood = true;
            } catch(FormatException ex){
                Console.WriteLine(ex.Message);
            }
        } while(!userClientWeightGood);

        ///GET CLient Height in inches
        do{
            Console.Write("Please enter the clients height in inches: ");
            try{
                userClientHeight = Promptint(); 
                userClientHeightGood = true;
            } catch(FormatException ex){
                Console.WriteLine(ex.Message);
            }
        } while(!userClientHeightGood);

       //PartA just instantiate a new client object with provided values 
       Client client1 = new Client(userClientFirstName, userClientLastName, userClientWeight, userClientHeight);
       Console.WriteLine("");
       if(client1 != null){
        Console.WriteLine("Client succesfully created.");
       }
       return client1;   
        }
// / <summary>
// / Prompts the user to enter an integer within a specified range and validates the input.
// / Validates that the input is an integer and falls within the specified range.
// / Returns the validated integer input.
// / </summary>
// / <returns>The validated integer input.</returns>
	static int Promptint(){
        int userint = 0;
        int min = 10;
        int max = 1000;

        bool exit = false;

        do{
            try{
                userint = int.Parse(Console.ReadLine());
                if(userint >= min && userint <= max){
                    exit = true;
                } else if( userint == -1){
                    exit = true;
                } 
                else{
                    Console.WriteLine($"Please Enter a value between {min} and {max}");
                }
            }catch (FormatException ex){
                Console.WriteLine(ex.Message);
            }
        }while(!exit);

        return userint;
    } 



// / <summary>
// / Displays the BMI (Body Mass Index) information for a given client.
// / Calculates the client's BMI score and retrieves the BMI status based on the score.
// / Prints the client's name, BMI score, and BMI status.
// / </summary>
// / <param name="currentClient">
    static void DisplayBMIInfo(Client currentClient){
     
        double currentClientBMI = currentClient.BmiScore();
        Console.WriteLine("Client Name: " + $"{currentClient.LastName}" + "," + $"{currentClient.FirstName}");
        Console.WriteLine("Client BMI Score: " + $"{currentClientBMI:n2}");
        Console.WriteLine("Client BMI Status: " + $"{currentClient.BmiStatus(currentClientBMI)}" );
    }

    

    static void Main(string[] args){

        string mainMenuChoice;
        string editMenuChoice;
        bool displayMainMenu = true;
        bool displayEditMenu;
        bool proceed;
        bool quit;
        Client currentClient = new Client();
        
        DisplayMainMenu();

         while (displayMainMenu)
        {
            mainMenuChoice = Prompt("Enter MAIN MENU option ('D' to display menu): ").ToUpper();
            Console.WriteLine();
            switch (mainMenuChoice)
            {
                case "N": //[N]ew Client Entry

                    proceed = NewEntryDisclaimer();

                    if (proceed){
                        // TODO: uncomment the following and call the Enter New Client
                        currentClient = EnterClient();
                    }
                    else{
                        Console.WriteLine("Cancelling new data entry. Returning to MAIN MENU.");
                    }

                    break;
                case "S" : //[S]How Client BMI Info
             
                    if(currentClient != null){
                        DisplayBMIInfo(currentClient);
                    }
        
                    break;
                case "E": //[E]dit Client BMI Info
             
                    {
                        displayEditMenu = true;
                        while (displayEditMenu)
                        {
                            // TODO: call the DisplayEditMenu here
							DisplayEditMenu();

                            editMenuChoice = Prompt("What would you like to Edit? ").ToUpper();
                            Console.WriteLine();
                            Console.WriteLine($"{editMenuChoice}");
                            switch (editMenuChoice)
                            {
                                case "F": //[F]irst Name
                                          currentClient.FirstName = Prompt("Enter a new firstname. ");
                                    break;
                                case "L": //[L]ast Name
                                          currentClient.LastName = Prompt("Enter a new lastname. ");
                                  
                                    break;
                                case "W": //[W]eight 
                                          
                                          currentClient.ClientWeight = int.Parse(Prompt("Enter a new weight in pounds. "));
                                     
                                    break;
                                case "H": //[H]eight
                                          currentClient.ClientHeight = int.Parse(Prompt("Enter a new height in inches "));  
                                    break;
                                case "R": //[R]eturn to MAIN MENU
                                    displayEditMenu = false;
                                    break;
                                default: //invalid entry. Reprompt.
                                    Console.WriteLine("Invalid reponse. Enter one of the letters to choose a submenu option. ");
                                    break;
                            }
                        }
                    }
                    break;
                case "D":
					DisplayMainMenu();
                    break;
                case "Q": //[Q]uit Program
                    quit = Prompt("Are you sure you want to quit (y/N)? ").ToLower().Equals("y");
                    Console.WriteLine();
                    if (quit)
                    {
                        displayMainMenu = false;
                    }
                    break;
                default: //invalid entry. Reprompt.
                    Console.WriteLine("Invalid reponse. Enter one of the letters to choose a menu option.");
                    break;
            }
        }
    }
}
