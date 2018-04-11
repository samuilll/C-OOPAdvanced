
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvestingFieldsTest
{

    private StringBuilder sb = new StringBuilder();

    public string Run()
    {
        Type type = typeof(HarvestingFields);

        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        while (true)
        {
            string accessModifier = Console.ReadLine();

            if (accessModifier == "HARVEST")
            {
                break;
            }

            switch (accessModifier)
            {
                case "public":
                    {
                        AppendFields(fields.Where(f => f.IsPublic).ToArray());
                        break;
                    }
                case "protected":
                    {
                        AppendFields(fields.Where(f => f.IsFamily).ToArray());

                        break;
                    }
                case "private":
                    {
                        AppendFields(fields.Where(f => f.IsPrivate).ToArray());

                        break;
                    }
                case "all":
                    {
                        AppendFields(fields);

                        break;
                    }
                default:
                    break;
            }
        }

        return this.sb.ToString().Trim();
    }

    private void AppendFields(FieldInfo[] fields)
    {
        foreach (var field in fields)
        {
            string modifier = field.Attributes.ToString().ToLower();

            if (modifier=="family")
            {
                modifier = "protected";
            }

            sb.AppendLine($"{modifier} {field.FieldType.Name} {field.Name}");
        }
    }
}

