using System;

{
    IdentityUser user = new IdentityUser();
    IdentityRole role = new IdentityRole();
    ConsoleSetter.SetValues<IdentityUser>(user);
    ConsoleSetter.SetValues<IdentityRole>(role);
}