using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


  public  class Spy
    {
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        var fields = Type.GetType(classToInvestigate).GetFields(BindingFlags.Instance  | BindingFlags.NonPublic | BindingFlags.Public|BindingFlags.Static);

        var classInstance = Activator.CreateInstance(Type.GetType(classToInvestigate),new object[] { });

        foreach (var field in fields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        FieldInfo[] publicFields = Type.GetType(className).GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        PropertyInfo[] properties = Type.GetType(className).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        //  var hacker = Activator.CreateInstance(Type.GetType(className));

        foreach (var field in publicFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var property in properties)
        {
            if (!property.GetMethod.IsPublic)
            {
                sb.AppendLine($"{property.GetMethod.Name} have to be public!");
            }
        }
        foreach (var property in properties)
        {
            if (property.CanWrite)
            {
                if (!property.SetMethod.IsPrivate)
                {
                    sb.AppendLine($"{property.SetMethod.Name} have to be private!");
                }
            }
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic| BindingFlags.Instance);

        foreach (var method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance| BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var method in methods.Where(m=>m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}

