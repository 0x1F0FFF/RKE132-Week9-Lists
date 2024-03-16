string folderPath = @"/Users/morten/Documents";
string fileName = "shoppinglist.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myShoppingList = new List<String>(); 

if (File.Exists(filePath))
{
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}
else
{
    Console.WriteLine($"File {fileName} does not exist.");
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}

static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item (add) / exit (exit): ");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item: ");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else if (userChoice == "exit")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count();

    Console.WriteLine($"You have added {listLength} items.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
