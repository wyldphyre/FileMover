using System;

namespace library
{
  public class Rule
  {
    public Rule ()
    {
      this.TargetFolder = string.Empty;
    }
    public Rule(FileProperty Property, PropertyComparisonMethod ComparisonMethod, string ComparisonArgument, string TargetFolder)
    {
      this.Property = Property;
      this.ComparisonMethod = ComparisonMethod;
      this.ComparisonArgument = ComparisonArgument;
      this.TargetFolder = TargetFolder;
    }
    public FileProperty Property { get; set; }
    public PropertyComparisonMethod ComparisonMethod { get; set; }
    public string ComparisonArgument { get; set; }
    public string TargetFolder { get; set; }
  }

  public enum FileProperty
  {
    Name,
    Extension
    // To Do: Could perhaps add parent folder etc as additional properties of the file
  }

  public enum PropertyComparisonMethod
  {
    StartsWith,
    EndsWith,
    Equals,
    Matches
  }
}