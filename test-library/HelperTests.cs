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
}
