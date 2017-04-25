using System;
using library;
using Xunit;

namespace test_library
{
  public class StringHelperTests
  {
    [Fact]
    public void TestSplit()
    {
      Assert.True(string.Empty.Split("").Length == 1, "Empty string Split result length is zero");

      var source = "hello world";
      var components = source.Split("");

      Assert.True(components.Length == 1, "String with no separator Split: Expected length = 1");
      Assert.True(components[0] == source, "Using empty string as separator results in original value");

      components = source.Split(" ");      
      Assert.True(components.Length == 2, "String with 1 separator Split: Expected length = 2");
      Assert.True(components[0] == "hello", "First component == 'hello'");
      Assert.True(components[1] == "world", "First component == 'world'");
      
      source = "hello again world";
      components = source.Split(" ");      
      
      Assert.True(components.Length == 3, "String with 2 separator Split: Expected length = 2");
      Assert.True(components[0] == "hello", "First component == 'hello'");
      Assert.True(components[1] == "again", "First component == 'again'");
      Assert.True(components[2] == "world", "First component == 'world'");

      source = "hello -> again -> world";
      components = source.Split("->");      
      
      Assert.True(components.Length == 3, "String with 2 multi-character separator Split: Expected length = 3");
      Assert.True(components[0] == "hello ", "First component == 'hello '");
      Assert.True(components[1] == " again ", "First component == ' again '");
      Assert.True(components[2] == " world", "First component == ' world'");
    }
  }

  public class PropertyComparisonMethodHelperTests
  {
    [Fact]
    public void TestFromString()
    {
      Assert.Throws<Exception>(() => PropertyComparisonMethodHelper.FromString(""));
      Assert.Throws<Exception>(() => PropertyComparisonMethodHelper.FromString("blah"));
      Assert.True(PropertyComparisonMethodHelper.FromString("Equals") == PropertyComparisonMethod.Equals);
      Assert.True(PropertyComparisonMethodHelper.FromString("Matches") == PropertyComparisonMethod.Matches);
      Assert.True(PropertyComparisonMethodHelper.FromString("StartsWith") == PropertyComparisonMethod.StartsWith);
      Assert.True(PropertyComparisonMethodHelper.FromString("endswith") == PropertyComparisonMethod.EndsWith);
      Assert.True(PropertyComparisonMethodHelper.FromString("EndsWith") == PropertyComparisonMethod.EndsWith);
    }

    [Fact]
    public void TestGetMethodAndArgument()
    {
      Assert.Throws<Exception>(() => PropertyComparisonMethodHelper.GetMethodAndArgument(""));
      Assert.Throws<Exception>(() => PropertyComparisonMethodHelper.GetMethodAndArgument("Blah"));
      Assert.Throws<Exception>(() => PropertyComparisonMethodHelper.GetMethodAndArgument("Blah()"));

      var (method, argument) = PropertyComparisonMethodHelper.GetMethodAndArgument("StartsWith(Fred)");
      Assert.True(method == PropertyComparisonMethod.StartsWith, "Parsed method correctly");
      Assert.True(argument == "Fred", "Parsed argument correctly");

      (method, argument) = PropertyComparisonMethodHelper.GetMethodAndArgument("Equals(\"Fred\")");
      Assert.True(method == PropertyComparisonMethod.Equals, "Parsed method correctly");
      Assert.True(argument == "\"Fred\"", "Parsed argument correctly"); 

      (method, argument) = PropertyComparisonMethodHelper.GetMethodAndArgument("Equals()");
      Assert.True(method == PropertyComparisonMethod.Equals, "Parsed method correctly");
      Assert.True(argument == null, "No argument correctly returned as null"); 

      (method, argument) = PropertyComparisonMethodHelper.GetMethodAndArgument("EndsWith() ");
      Assert.True(method == PropertyComparisonMethod.EndsWith, "Parsed method correctly");
      Assert.True(argument == null, "No argument correctly returned as null"); 
    }
  }

  public class FilePropertyMethodHelperTests
  {
    [Fact]
    public void TestFromString()
    {
      Assert.Throws<Exception>(() => FilePropertyHelper.FromString(""));
      Assert.Throws<Exception>(() => FilePropertyHelper.FromString("blah"));
      Assert.True(FilePropertyHelper.FromString("Name") == FileProperty.Name);
      Assert.True(FilePropertyHelper.FromString("extension") == FileProperty.Extension);
      Assert.True(FilePropertyHelper.FromString("Extension") == FileProperty.Extension);
    }
  }
}
