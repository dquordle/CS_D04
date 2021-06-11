using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;

{
    DefaultHttpContext context = new DefaultHttpContext();
    Console.WriteLine($"Old Response value: {context.Response}");
    Type myType = typeof(DefaultHttpContext);
    FieldInfo field = myType.GetField("_response", BindingFlags.NonPublic | BindingFlags.Instance);
    field.SetValue(context, null);
    Console.WriteLine($"New Response value: {context.Response}");
}