// The program build will be developed in two parts:
// Part A – Class and Object Implementation
// Client Class

//     A read-only property named BmiScore that will return as a double the BMI score for the client
//     A read-only property named BmiStatus that will return as a string the BMI status for the corresponding BMI score
//     A read-only property named FullName that will return as a string the client's full name in the format Lastname, FirstName


namespace ClientClass;
public class Client {
    //A string field to store the client's first name 
    private string firstname;
    //A string field to store the client's last name 
    private string lastname;
    private int clientWeight;

    private int clientHeight;
    
    public Client()
    {
        FirstName = "XXXX";
        LastName = "YYYY";
        ClientWeight = 0;
        ClientHeight = 0;
    }

    public Client(string firstname, string lastname, int clientWeight, int clientHeight)
    {
        FirstName = firstname;
        LastName = lastname;
        ClientWeight = clientWeight;
        ClientHeight = clientHeight;
    }
 
    public string FirstName{
        get{
            return firstname;
        }
        set{
            if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentNullException("Tag is required. Must not be empty or blank.");
            firstname = value;
        }
    }
    public string LastName{
        get{
            return lastname;
        }
        set{
            if (string.IsNullOrWhiteSpace(value))   {
                throw new ArgumentNullException("Lastname cant be empty or null");
            } else{
                lastname = value;
            }
        }            
    }
    public int ClientWeight{
        get{
            return clientWeight;
        }
        private set{
            if (value <= 0){
                throw new FormatException("Cant be null, or 0 give me five or something");
            } else{
                clientWeight = value;
            }
    
        }
    }
    public int ClientHeight {
        get{
            return clientHeight;
        }
        set{
            if (value <= 0){
            throw new FormatException("Cant be null, or 0 give me five or something");
            } else {
                clientHeight = value;
            }
        }   
    }
    //END FIELDS AND PROPERTIES MEMEBER METHODS BELOW
    // Read Only Fully Implemented Properties
    //A read-only property named BmiScore that will return as a double the BMI score for the client
    // Formula: weight / height2 x 703
    // The formula for BMI is weight in pounds (lbs) divided by inches squared (in2). The total is then multiplied by 703
    // Where height is in inches and weight is in pounds.
    // The status for corresponding BMI values are as follows:
    // BMI Score 	Status
    // <= 18.4 	Underweight
    // 18.5 - 24.9 	Normal
    // 25.0 - 39.9 	Overweight
    // >= 40 	Obese
    public double BmiScore(){
        return clientWeight / (clientHeight * clientHeight) * 703;
    } 
    //A read-only property named BmiStatus that will return as a string the BMI status for the corresponding BMI score
    public string BmiStatus(double bmi){
        if(bmi <= 18.4){
            return "Underweight";
        } else if( bmi >= 18.5 && bmi <= 24.9){
            return "Normal";
        } else if(bmi >= 25 && bmi <= 39.9){
            return "OVerweight";
        } else {
            return "Obese";
        }
    }
    // A read-only property named FullName that will return as a string the client's full name in the format Lastname, FirstName
    public string FullName(){
        string fullname = firstname + " " + lastname;
        return fullname;
    }
 


}