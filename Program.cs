namespace CPSC1012Assignment4;
using ClientClass;
using System.Collections.Generic;
// The program build will be developed in two parts:
// Write a program to test your Client class as shown in the sample run below. The program must, at a minimum, demonstrate the following:
//     a. prompt for a string
//     b. prompt for an int
//     c. create an instance of Client
//     d. display the status or score, depending on user request, along with full client name
//     e. have user friendly error handling (i.e. the program must not crash)
// NOTE: the sample run does not demonstrate exception handling, ensure your program handles exceptions gracefully and does not crash.
class Program{
    static void DisplayMainMenu(){
        Console.WriteLine("[N]ew Client");
        Console.WriteLine("[S]how Client");
        Console.WriteLine("[E]dit Client");
        Console.WriteLine("[Q]uit Program");
	}
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
    static string Prompt(string prompt){
        string userString;
        bool invalidInput = false;

        Console.Write(prompt);
        do{
        try{
            userString = Console.ReadLine();
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
    static void DisplayEditMenu(){
        Console.WriteLine("[F]irst Name");
        Console.WriteLine("[L]ast Name");
        Console.WriteLine("[W]eight");
        Console.WriteLine("[H]eight");
        Console.WriteLine("[R]eturn to MAIN MENU");
	}
    //change from void to INT at partb 

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

    //     //add values into array here 
    //     for(int i = 0; i <= 30; i++){
    //         Console.WriteLine($"Please enter daily sales for day {i + 1} as a int value.");
    //         dailySales = Promptint();
    //         if(dailySales == -1){
    //             break;
    //         } else {
    //             count++;
    //         }
    //     //ternary operator to handle 0 for days less than 10
    //         monthlySaleString = i < 9 ? $"{month}-0{i + 1}-{userYear}" : $"{month}-{i + 1}-{userYear}";
    //         dates[i] = monthlySaleString;
    //         sales[i] = dailySales;
    //     }
    // return count;    
        }
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
        Client currentClient = null;
        //REMEBER TO RE-IMPLEMENT COUNT
        DisplayMainMenu();

         while (displayMainMenu)
        {
            mainMenuChoice = Prompt("Enter MAIN MENU option ('D' to display menu): ").ToUpper();
            Console.WriteLine();
    

            //MAIN MENU Switch statement
            switch (mainMenuChoice)
            {
                case "N": //[N]ew Client Entry

                    proceed = NewEntryDisclaimer();

                    if (proceed){
                        // TODO: uncomment the following and call the Enter New Client
                        //for PArtB downthere
                        //count = EnterClient();
                        //Console.WriteLine($"Entries completed. {count} records in temporary memory.");
                        //Console.WriteLine();
                        currentClient = EnterClient();
                    }
                    else{
                        Console.WriteLine("Cancelling new data entry. Returning to MAIN MENU.");
                    }

                    break;
                case "S" : //[S]How Client BMI Info
                    // filename = Prompt("Enter name of file to load: ");
                    // // TODO: uncomment the following and call the ShowClientBMIInfo method below
                    if(currentClient != null){
                        DisplayBMIInfo(currentClient);
                    }
                   
                    // count = LoadSalesFile(filename, sales, dates);
                    // Console.WriteLine($"{count} records were loaded.");
                    // Console.WriteLine();
                    break;
                case "E": //[E]dit Client BMI Info
                    //will need the below few lines for part b
                    // if (currentClient != null){

                    // }
                    // {
                    //     Console.WriteLine("Sorry, LOAD data or enter NEW data before ANALYSIS.");
                    // }
                    //else
                    {
                        displayEditMenu = true;
                        while (displayEditMenu)
                        {
                            // TODO: call the DisplayEditMenu here
							DisplayEditMenu();

                            editMenuChoice = Prompt("What would you like to Edit?").ToUpper();
                            Console.WriteLine();
                            Console.WriteLine($"{editMenuChoice}");
                            switch (editMenuChoice)
                            {
                                case "F": //[F]irst Name
                                          // TODO: uncomment the following and call Set FirstName
                                          currentClient.FirstName = Prompt("Enter e new firstname.");
                                    break;
                                case "L": //[L]ast Name
                                          // TODO: uncomment the following and call the Largest method below
                                          currentClient.LastName = Prompt("Enter a new lastname.");
                                  
                                    break;
                                case "W": //[W]eight 
                                          // TODO: uncomment the following and call the Smallest method below
                                          currentClient.ClientWeight = int.Parse(Prompt("Enter a new weight in pounds."));
                                        //   smallest = LowestSales(sales, count);
                                        //   month = dates[0].Substring(0, 3);
                                        //   year = dates[0].Substring(7, 4);
                                        //   Console.WriteLine($"The smallest sales for {month} {year} is: {smallest:C}");
                                        //   Console.WriteLine();
                                    break;
                                case "H": //[H]eight
                                          // TODO: call the DisplayChart method below
                                          currentClient.ClientHeight = int.Parse(Prompt("Enter a new height in inches"));
                                            // DisplaySalesChart(sales, dates, count);
                                            // Prompt("Press <enter> to continue...");
                                    break;
                                case "R": //[R]eturn to MAIN MENU
                                    displayEditMenu = false;
                                    break;
                                default: //invalid entry. Reprompt.
                                    Console.WriteLine("Invalid reponse. Enter one of the letters to choose a submenu option.");
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
