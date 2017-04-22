using System;

namespace library
{
  public class Operation
  {
    public MatchType MatchOn { get; set; }

    public string Testy()
    {
      return string.Empty;        
    }
  }

  public enum MatchType
  {
    Filename
  }
}
