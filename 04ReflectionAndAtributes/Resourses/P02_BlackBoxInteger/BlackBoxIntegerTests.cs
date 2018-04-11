
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class BlackBoxIntegerTests
{

    private Type type;
    private MethodInfo[] methods;
    private BlackBoxInteger blackBox;
    public BlackBoxIntegerTests(Type type)
    {
        this.type = type;
        this.methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        this.blackBox = (BlackBoxInteger)Activator.CreateInstance(this.type, true);
    }
    public int InvokeMethod(string methodToInvoke, int value)
    {
        int result = 0;

        MethodInfo method = methods.First(m => m.Name == methodToInvoke);

        method.Invoke(blackBox, new object[] { value });

        result = (int)type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(blackBox);

        return result;
    }
}

