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
}