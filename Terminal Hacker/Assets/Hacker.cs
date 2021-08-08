using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Config Data
    const string menu = "U can write menu to return back";
    string[] level1Passwords = { "lion", "wolf", "horse", "deer", "bats" };
    string[] level2Passwords = { "garlic", "onion", "broccoli", "carrot", "eggplant" };
    string[] level3Passwords = { "Computer", "Laptop", "Microsoft", "Processor", "Motherboard" };



    //Game State
    int level;      //Level Sate Var
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen CurrentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    //OnUserInput called when the user press (Enter)
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        //For PC
        else if (input == "quit" || input == "exit" || input == "leave" || input == "close")
        {
            Application.Quit();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            RuMainMenu(input);
        }
        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (CurrentScreen == Screen.Win)
        {
            WinScreen();
        }

    }

    //The MainMenu Screen all details
    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello My man/girl");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 to enter to (Animals)");
        Terminal.WriteLine("Press 2 to enter to (Vegtables)");
        Terminal.WriteLine("Press 3 to enter to (Tech)");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter Your Selection:");

    }


    //Check a valid input in MainMenu Screen
    void RuMainMenu(string input)
    {

        bool isValidNum = (input == "1" || input == "2" || input == "3");
        if (isValidNum)
        {
            level = int.Parse(input);
            askForPassword();
        }
        else
        {
            Terminal.WriteLine("Not Valid.");
            Terminal.WriteLine(menu);
        }
    }

    //Asking The user for the password
    void askForPassword()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("U have chosen level " + level);
        setRandomPassword();
        Terminal.WriteLine("Write a password, hint: " + password.Anagram());
    }

    //Setting a password randomly
    void setRandomPassword()
    {
        int index = Random.Range(0, level1Passwords.Length);
        switch (level)
        {
            case 1:
                password = level1Passwords[index];
                break;
            case 2:
                password = level2Passwords[index];
                break;
            case 3:
                password = level3Passwords[index];
                break;
            //FOR PROTECTION
            default:
                Debug.LogError("Invalid Syntax.");
                break;
        }
    }
    //If we are in the Password Screen and the user type a password then check it
    void CheckPassword(string input)
    {

        if (input == password)
        {
            WinScreen();
        }
        else
        {
            askForPassword();       //For changing the password
            Terminal.WriteLine(menu);
        }


    }

    void WinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        levelReword();
    }

    void levelReword()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You are one of the fastest bats in the world....(Mexican free-tailed bat)");
                Terminal.WriteLine(@"
        _     _     _ 
       / `'--) (--'` \
      /  _,-'\_/'-,_  \
     /.-'           '-.\
                                    ");

                break;

            case 2:
                Terminal.WriteLine("U pretty Good...");
                Terminal.WriteLine("I think u deserve a carrot");
                Terminal.WriteLine(@"                                              
   _\/_
   \  /
    \/                                                                                                        
                ");

                break;

            case 3:
                Terminal.WriteLine("u deserve the first Logo for Microsoft Inc.");
                Terminal.WriteLine(@"
             _.-;;-._
      '-..-'|   ||   |
      '-..-'|_.-;;-._|
      '-..-'|   ||   |
      '-..-'|_.-''-._|

");
                break;
            //FOR PROTECTION
            default:
                Debug.LogError("Invalid Level");
                break;


        }
        Terminal.WriteLine(menu);

    }
}
