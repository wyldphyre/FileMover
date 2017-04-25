using System;

namespace library
{
  public class RuleParser
  {
    private const string TargetFolderMarker = "->";

    public Rule Parse(string input)
    {
      var components = input.Split(TargetFolderMarker);

      var s = $"Missing target folder marker '{TargetFolderMarker}'";
      if (components.Length != 2)
        throw new InvalidRuleException($"Missing target folder marker '{TargetFolderMarker}'");

      var instructions = components[0].Trim();
      var TargetFolder = components[1].Trim();

      components = instructions.Split(".");
      
      if (!components[0].Equals("File", StringComparison.CurrentCultureIgnoreCase))
        throw new InvalidRuleException("Only 'File' rules allowed");

      var fileProperty = FilePropertyHelper.FromString(components[1]);
      var (method, argument) = PropertyComparisonMethodHelper.GetMethodAndArgument(components[2]);

      var rule = new Rule(fileProperty, method, argument, TargetFolder);
      return rule;
    }
  }

  public class InvalidRuleException : Exception
  {
    public InvalidRuleException() {}

    public InvalidRuleException(string message) : base(message)
    {      
    }    
  }
}