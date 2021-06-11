using System;
using System.Reflection;

public class TypeFactory
{
    public static T CreateWithConstructor<T>() 
        where T : class
    {
        Type myType = typeof(T);
        ConstructorInfo constructor = myType.GetConstructor(Type.EmptyTypes);
        T instance = null;
        if (constructor != null)
            instance = (T)constructor.Invoke(null);
        return instance;
    }
    public static T CreateWithActivator<T>()
        where T : class
    {
        Type myType = typeof(T);
        Object instance = Activator.CreateInstance(myType);
        return (T) instance;
    }

    public static T CreateWithParameters<T>(Object[] objects)
    {
        Type myType = typeof(T);
        Object instance = Activator.CreateInstance(myType, objects);
        return (T) instance;
    }
}