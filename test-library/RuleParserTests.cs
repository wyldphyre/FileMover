using System;
using library;
using Xunit;

namespace test_library
{
  public class RuleParserTests
  {
    [Fact]
    public void TestParsingLineToNonFileBasedRule()
    {
      Assert.Throws(typeof(InvalidRuleException), () => new RuleParser().Parse("Folder.Name.StartsWith(\"[Test]\") -> /Path/GoesHere"));
    }

    [Fact]
    public void TestParsingLineToRule()
    {
      var RuleParser = new RuleParser();

      Assert.Throws(typeof(InvalidRuleException), () => RuleParser.Parse("File.Name.StartsWith(\"[Test]\") /Path/GoesHere"));
      
      var Rule = RuleParser.Parse("File.Extension.StartsWith(\"[Test]\") -> /Path/GoesHere");
      Assert.True(Rule != null, "Rule != null");
      Assert.True(Rule.Property == FileProperty.Extension, $"{nameof(Rule.Property)} == '{nameof(FileProperty.Extension)}'");
      Assert.True(Rule.ComparisonMethod == PropertyComparisonMethod.StartsWith, $"{nameof(Rule.ComparisonMethod)} == '{nameof(PropertyComparisonMethod.StartsWith)}'");
      Assert.True(Rule.ComparisonArgument == "\"[Test]\"", $"{nameof(Rule.ComparisonArgument)} == '[Test]'");
      Assert.True(Rule.TargetFolder == "/Path/GoesHere", "Target folder parsed correctly");

      Rule = RuleParser.Parse("File.Name.EndsWith() -> /Path/GoesHere");
      Assert.True(Rule != null, "Rule != null");
      Assert.True(Rule.Property == FileProperty.Name, $"{nameof(Rule.Property)} == '{nameof(FileProperty.Name)}'");
      Assert.True(Rule.ComparisonMethod == PropertyComparisonMethod.EndsWith, $"{nameof(Rule.ComparisonMethod)} == '{nameof(PropertyComparisonMethod.EndsWith)}'");
      Assert.True(Rule.ComparisonArgument == null, $"{nameof(Rule.ComparisonArgument)} == 'null'");
      Assert.True(Rule.TargetFolder == "/Path/GoesHere", "Target folder parsed correctly");     
    }
  }

  public class RuleFileParserTests
  {
    [Fact]
    public void TestParsingEmptyData()
    {
      var fileParser = new RuleFileParser();
      var Rules = fileParser.ParseFileContents(string.Empty);
      Assert.True(Rules.Count == 0, "Parsed no data as empty list");
    }

    [Fact]
    public void TestParsingData()
    {
      var fileParser = new RuleFileParser();
      
      var Rule1 = "File.Name.StartsWith(\"fred\") -> /Path/1/here";
      var Rule2 = "File.Extension.EndsWith(\"sam\") -> /Path/2/here";
      var Rule3 = "File.Name.Equals(bob) -> /Path/3/here";

      var OneRule = Rule1;
      var OneRuleAndEmptyLines = $"{Environment.NewLine}{Rule1}{Environment.NewLine}";

      var Rules = fileParser.ParseFileContents(OneRule);
      Assert.True(Rules.Count == 1, "Parsed 1 rule line as one rule");
      Assert.True(Rules[0].ComparisonMethod == PropertyComparisonMethod.StartsWith);
      Assert.True(Rules[0].TargetFolder == "/Path/1/here");      
    }
  }
}
