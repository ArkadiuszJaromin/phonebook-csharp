using System.Text.RegularExpressions;

internal class Program
{
    public static Dictionary<string, string> ContactList = new Dictionary<string, string>();

    private static void AddContact(Dictionary<string, string> contactList)
    {
        Console.WriteLine("Type name that you want to add | c to cancel");

        while (true)
        {
            string? nameAdd = Console.ReadLine();
            Console.WriteLine("");

            if (nameAdd == "c")
            {
                return;
            }
            if(!string.IsNullOrEmpty(nameAdd))
            {
                Console.WriteLine("Type number that you want to add | c to cancel");
                while (true)
                {
                    string? numberAdd = Console.ReadLine();
                    Console.WriteLine("");

                    if (numberAdd == "c")
                    {
                        return;
                    }
                    Regex regex = new Regex(@"^\+?[0-9]{8,}$");
                    if (regex.IsMatch(numberAdd))
                    {
                        if (contactList.TryAdd(numberAdd, nameAdd))
                        {
                            Console.WriteLine($"Success! Added {nameAdd} - number: {numberAdd} to contact list");

                            return;
                        }
                        Console.WriteLine("Something went wrong...");

                    }
                    Console.WriteLine("Number incorrect! Try again");
                }
            }
            
            
            Console.WriteLine("Name incorrect! Try again");


        }
    }
    private static void DeleteContact(Dictionary<string, string> contactList)
    {
        Console.WriteLine("Type number that you want to delete | c to cancel");

        while (true)
        {
            string? numberDelete = Console.ReadLine();
            Console.WriteLine("");

            if (numberDelete == "c")
            {
                return;
            }
            if (numberDelete != null) 
            {
                var toRemove = contactList.FirstOrDefault(e => e.Key == numberDelete);
                if(toRemove.Key != null)
                {
                    Console.WriteLine($"Removing {toRemove.Key} - {toRemove.Value}");
                    Console.WriteLine("");
                    contactList.Remove(numberDelete);
                    return;
                }
                else
                {
                    Console.WriteLine("Number not found");
                    return;
                }

            }
            


        }
    }
    private static void ListAllContacts(Dictionary<string, string> contactList)
    {
        
        Console.WriteLine($"Contact list (No. records - {contactList.Count()}):");
        if(contactList.Count() ==0)
            Console.WriteLine("No data");

        foreach (var contact in contactList) 
        {
            Console.WriteLine($"{contact.Key} - {contact.Value}");
        }

    }

    private static void SearchingEngine(Dictionary<string, string> contactList, string userInput)
    {
       

        var listSearch = contactList.Where(e => e.Key == userInput || e.Value == userInput);
        

        int countRecords = listSearch.Count();

        if(countRecords > 0)
        {
            Console.WriteLine("Searched output: ");
            foreach (var contact in listSearch)
            {
                Console.WriteLine($"{contact.Key} - {contact.Value}");
            }
        }
        else
        {
            Console.WriteLine("Nothing found...");
        }
        
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello user!");

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Instruction:");
            Console.WriteLine("Type \"add\" to add contact to contact list");
            Console.WriteLine("Type \"delete\" to delete contact from contact list");
            Console.WriteLine("Type \"list\" to show all contacts from contact list");
            Console.WriteLine("Type name or number to search for it in contact list");
            Console.WriteLine("Type \"exit\" to exit the application");
            Console.WriteLine("");

            string? userControlActionInput = Console.ReadLine();
            Console.WriteLine("");


            if (userControlActionInput != null)
            {
                if(userControlActionInput == "exit")
                {
                    break;
                }
                else if (userControlActionInput == "add")
                {
                    AddContact(ContactList);
                }
                else if (userControlActionInput == "delete")
                {
                    DeleteContact(ContactList);
                }
                else if (userControlActionInput == "list")
                {
                    ListAllContacts(ContactList);
                }
                else
                {
                    SearchingEngine(ContactList, userControlActionInput);
                }
            }


        }
    }
}
