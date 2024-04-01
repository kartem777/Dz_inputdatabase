using qwedq;

bool flag = false;
while (flag != true)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        try
        {
            Console.WriteLine("Name:");
            string? name = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Is Premium:");
            bool isP = Convert.ToBoolean(Console.ReadLine());
            User user = new User { Name = name, Age = age, IsPremium = isP };
            db.Users.Add(user);
            db.SaveChanges();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Pls try again");
        }
        var users = db.Users.ToList();
        Console.WriteLine("List:");
        foreach (User u in users)
            Console.WriteLine($"{u.Id}. {u.Name} -> {u.Age} -> {u.IsPremium}");
        Console.WriteLine("Exit?");
        try
        {
            flag = Convert.ToBoolean(Console.ReadLine());
        }
        catch( Exception ex )
        {
            flag = true;
        }
    }
}