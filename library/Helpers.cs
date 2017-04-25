using System;
using System.Collections.Generic;

namespace library
{
  public static class StringHelper
  {
    public static string[] Split(this string input, string separator)
    {
      if (separator == string.Empty)
        return new string[1] { input };

      var result = new List<string>();
      var remaining = input;

      var index = remaining.IndexOf(separator);
      while (index >= 0 && remaining != string.Empty)
      {
        if (index > 0)
          result.Add(remaining.Substring(0, index));
        
        index += separator.Length;
        remaining = remaining.Substring(index, remaining.Length - index);
        
        index = remaining.IndexOf(separator);
      }

      if (remaining.Length > 0)
        result.Add(remaining);

      return result.ToArray();
    }
  }

  public static class PropertyComparisonMethodHelper
  {
    public static PropertyComparisonMethod FromString(string input)
    {
      switch (input.ToUpper())
      {
        case "EQUALS": return PropertyComparisonMethod.Equals;
        case "MATCHES": return PropertyComparisonMethod.Matches;
        case "STARTSWITH": return PropertyComparisonMethod.StartsWith;
        case "ENDSWITH": return PropertyComparisonMethod.EndsWith;

        default:
          throw new Exception($"Unknown PropertyComparisonMethod {input}");
      }
    }

    public static (PropertyComparisonMethod method, string argument) GetMethodAndArgument(string input)
    {
      if (input == string.Empty)
        throw new Exception("Input is an empty string");

      var components = input.Split("(");
      var method = FromString(components[0]);
      string argument = null;

      if (components.Length > 1)
        argument = components[1].Replace(")", string.Empty).Trim();

      if (argument == string.Empty)
        argument = null;

      return (method, argument);
    }
  }

  public static class FilePropertyHelper
  {
    public static FileProperty FromString(string input)
    {
      switch (input.ToUpper())
      {
        case "NAME": return FileProperty.Name;
        case "EXTENSION": return FileProperty.Extension;
        
        default:
          throw new Exception($"Unknown FileProperty {input}");
      }
    }
  }
}