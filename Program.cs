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

     static void EnterClient(//double[] sales, string[] dates
     ){
       
      
        double userClientWeight = 0;
        double userClientHeight = 0;
        string userClientFirstName = "";
        string userClientLastName = "";
        bool firstNameGood = false;
        bool lastNameGood = false;
         //uncomment this when doing partB
        //int count = 0;


        // get firstname first
        //Console.Write("Enter Client First Name: ");
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
        //END GET MONTH
        
    //     Console.Write("Please enter year. (eg. YYYY): ");

    //     do{
    //         try{
    //             userYear = Console.ReadLine();
    //             if(!Regex.IsMatch(userYear, yearTest)){
    //                 throw new FormatException("Please enter a year between 1900 and 2100");
    //             } else {
    //                 Console.WriteLine($"{userYear} is confirmed.");
    //                 break;
    //             }
    //         } catch(FormatException ex){
    //             Console.WriteLine(ex.Message);
    //         }
    //     } while(userYear != "0");

        
    //     //add values into array here 
    //     for(int i = 0; i <= 30; i++){
    //         Console.WriteLine($"Please enter daily sales for day {i + 1} as a double value.");
    //         dailySales = PromptDouble();
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
	static double PromptDouble(){
        double userDouble = 0.0;
        double min = 0;
        double max = 100;

        bool exit = false;

        do{
            try{
                userDouble = double.Parse(Console.ReadLine());
                if(userDouble >= min && userDouble <= max){
                    exit = true;
                } else if( userDouble == -1){
                    exit = true;
                } 
                else{
                    Console.WriteLine($"Please Enter a value between {min} and {max}");
                }
            }catch (FormatException ex){
                Console.WriteLine(ex.Message);
            }
        }while(!exit);

        return userDouble;
    } 

    static void Main(string[] args){

        string mainMenuChoice;
        string editMenuChoice;
        bool displayMainMenu = true;
        bool displayEditMenu;
        bool proceed;
        bool quit;
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

                    if (proceed)
                    {
                        // TODO: uncomment the following and call the Enter New Client
                        //for PArtB downthere
                        //count = EnterClient();

                        EnterClient();
                        //Console.WriteLine();
                        //Console.WriteLine($"Entries completed. {count} records in temporary memory.");
                        //Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Cancelling new data entry. Returning to MAIN MENU.");
                    }
                    break;
                
                case "S": //[S]How Client BMI Info
                    // filename = Prompt("Enter name of file to load: ");
                    // // TODO: uncomment the following and call the ShowClientBMIInfo method below
                    // count = LoadSalesFile(filename, sales, dates);
                    // Console.WriteLine($"{count} records were loaded.");
                    // Console.WriteLine();
                    // break;
                case "E": //[E]dit Client BMI Info
                    //will need the below few lines for part b
                    // if (count == 0)
                    // {
                    //     Console.WriteLine("Sorry, LOAD data or enter NEW data before ANALYSIS.");
                    // }
                    //else
                    {
                        displayEditMenu = true;
                        while (displayEditMenu)
                        {
                            // TODO: call the DisplayAnalysisMenu here
							DisplayEditMenu();

                            editMenuChoice = Prompt("What would you like to Edit?").ToUpper();
                            Console.WriteLine();
                            Console.WriteLine($"{editMenuChoice}");
                            switch (editMenuChoice)
                            {
                                case "F": //[F]irst Name
                                          // TODO: uncomment the following and call Get FirstName
                                    break;
                                case "L": //[H]ighest Sales
                                          // TODO: uncomment the following and call the Largest method below
                                  
                                    break;
                                case "W": //[L]owest Sales
                                          // TODO: uncomment the following and call the Smallest method below
                                        //   smallest = LowestSales(sales, count);
                                        //   month = dates[0].Substring(0, 3);
                                        //   year = dates[0].Substring(7, 4);
                                        //   Console.WriteLine($"The smallest sales for {month} {year} is: {smallest:C}");
                                        //   Console.WriteLine();
                                    break;
                                case "H": //[G]raph Sales
                                          // TODO: call the DisplayChart method below
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
