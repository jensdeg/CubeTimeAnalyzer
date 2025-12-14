using System.Reflection;

namespace CubeTimeAnalyzer.App;

public static class Hook
{
    public static Assembly Assembly => typeof(Hook).Assembly;
}
