using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;

{
    var contextType = typeof(DefaultHttpContext);
    Console.WriteLine($"Type: {contextType.FullName}");
    Console.WriteLine($"Assembly: {contextType.Assembly.FullName}");
    Console.WriteLine($"Based on: {contextType.BaseType}\n");
    
    var bindingAttr = BindingFlags.Public | 
                      BindingFlags.NonPublic | 
                      BindingFlags.Static | 
                      BindingFlags.Instance | 
                      BindingFlags.DeclaredOnly;
    
    var fields = contextType.GetFields(bindingAttr);
    Console.WriteLine("Fields:");
    foreach (var field in fields)
    {
        Console.WriteLine(field.FieldType + " " + field.Name);
    }

    bindingAttr =  BindingFlags.Public |
                   BindingFlags.Static | 
                   BindingFlags.Instance | 
                   BindingFlags.DeclaredOnly;
    
    var Properties = contextType.GetProperties(bindingAttr);
    Console.WriteLine("\nProperties:");
    foreach (var property in Properties)
    {
        Console.WriteLine(property.PropertyType + " " + property.Name);
    }
    
    var Methods = contextType.GetMethods();
    Console.WriteLine("\nMethods:");
    foreach (var method in Methods)
    {
        var parametersInfo = method.GetParameters();
        string parameters = "";
        foreach (var param in parametersInfo)
        {
            parameters += param.ParameterType.Name + " " + param.Name;
            parameters += ", ";
        }
        if (!string.IsNullOrEmpty(parameters))
            parameters = parameters.Remove(parameters.Length - 2);
        Console.WriteLine(method.ReturnType.Name + " " + method.Name + " (" + parameters + ")");
    }
}