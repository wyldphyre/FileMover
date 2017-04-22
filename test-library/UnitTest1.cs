using System;
using library;
using Xunit;

namespace test_library
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      Assert.NotEqual(null, new Operation().Testy());
    }
  }
}
