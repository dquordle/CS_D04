using System;

{
    IdentityUser user1 = TypeFactory.CreateWithConstructor<IdentityUser>();
    user1.UserName = "Ostin";
    IdentityUser user2 = TypeFactory.CreateWithActivator<IdentityUser>();
    user2.UserName = "George";
    Console.WriteLine("d04_ex03.Models.IdentityUser");
    if (user1 == user2)
        Console.WriteLine("user1 == user2");
    else
        Console.WriteLine("user1 != user2");

    IdentityRole role1 = TypeFactory.CreateWithConstructor<IdentityRole>();
    role1.Name = "kek";
    IdentityRole role2 = TypeFactory.CreateWithActivator<IdentityRole>();
    role2.Name = "lol";
    Console.WriteLine("d04_ex03.Models.IdentityRole");
    if (role1 == role2)
        Console.WriteLine("role1 == role2");
    else
        Console.WriteLine("role1 != role2");
    
    Console.WriteLine("\nd04_ex03.Models.IdentityUser");
    Console.WriteLine("Set Name:");
    string name = Console.ReadLine();
    string[] objects = new[] {name};
    IdentityUser user3 = TypeFactory.CreateWithParameters<IdentityUser>(objects);
    Console.WriteLine($"Username set: {user3.UserName}");
}