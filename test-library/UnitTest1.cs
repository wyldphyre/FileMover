using System;
using library;
using Xunit;

namespace test_library
{
  public class RuleTests
  {
    [Fact]
    public void TestCreationOfEmptyRule()
    {
      var Rule = new Rule();
      Assert.True(Rule.TargetFolder == string.Empty, $"{nameof(Rule.TargetFolder)} == string.Empty");
    }

    [Fact]
    public void TestCreationOfPopulatedRule()
    {
      TestNewPopulatedRule(FileProperty.Name, PropertyComparisonMethod.EndsWith, "boo", "Root");
      TestNewPopulatedRule(FileProperty.Extension, PropertyComparisonMethod.Matches, "foo", "Root/sub");
    }

    private static Rule TestNewPopulatedRule(FileProperty Property, PropertyComparisonMethod ComparisonMethod, string Argument, string TargetFolder)
    {
      var Rule = new Rule(Property, ComparisonMethod, Argument, TargetFolder);
      Assert.True(Rule.Property == Property, $"{nameof(Rule.Property)} == {Property}");
      Assert.True(Rule.ComparisonMethod == ComparisonMethod, $"{nameof(Rule.ComparisonMethod)} == {ComparisonMethod}");
      Assert.True(Rule.ComparisonArgument == Argument, $"{nameof(Rule.ComparisonArgument)} == {nameof(Argument)}");
      Assert.True(Rule.TargetFolder != string.Empty, $"{nameof(Rule.TargetFolder)} != string.Empty");
      return Rule;
    }
  }

  public class RuleParserTests
  {
    [Fact]
    public void TestParsingLineToRule()
    {
      var RuleParser = new RuleParser();

      var Rule = RuleParser.Parse("File.Extension.StartsWith(\"[Test]\") -> /Path/GoesHere");
      Assert.True(Rule != null, "Rule != null");
      // Assert.True(Rule.Property == FileProperty.Extension, $"{nameof(Rule.Property)} == {nameof(FileProperty.Extension)}");
      // Assert.True(Rule.ComparisonMethod == PropertyComparisonMethod.StartsWith, $"{nameof(Rule.ComparisonMethod)} == {nameof(PropertyComparisonMethod.StartsWith)}");
    }

    public void TestParsingToRule()
    {      
    }
  }
}
