using System;
using System.ComponentModel;
using System.Reflection;

public class ConsoleSetter
{
    public static void SetValues<T>(T input)
        where T : class
    {
        var classType = typeof(T);
        Console.WriteLine($"Let's set {classType.Name}");
        var bindingAttr = BindingFlags.Public |
                          BindingFlags.Instance | 
                          BindingFlags.DeclaredOnly;
        string value;
        var Properties = classType.GetProperties(bindingAttr);
        foreach (var property in Properties)
        {
            var attrs = property.GetCustomAttributes();
            bool Display = true;
            bool described = false;
            bool defaulted = false;
            foreach (var attr in attrs)
            {
                if (attr is NoDisplayAttribute)
                    Display = false;
                else if (attr is DescriptionAttribute)
                    described = true;
                else if (attr is DefaultValueAttribute)
                    defaulted = true;
            }
            if (Display)
            {
                AttributeCollection attributes =
                    TypeDescriptor.GetProperties(input)[property.Name].Attributes;
                DescriptionAttribute description = 
                    (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];
                string name = property.Name;
                if (described)
                    name = description.Description;
                Console.WriteLine($"Set {name}");
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value) && defaulted)
                {
                    DefaultValueAttribute defValue =
                        (DefaultValueAttribute) attributes[typeof(DefaultValueAttribute)];
                    value = defValue.Value.ToString();
                }
                PropertyInfo prop = classType.GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
                prop.SetValue(input, value);
            }
        }
        Console.WriteLine(input);
    }
}