using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }
  public class FA
  {
    
    public bool? Run(State InitialState, IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s) // цикл по всем символам 
        {
            current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
            if (current == null)              // если его нет, возвращаем признак ошибки
                return null;
            // иначе переходим к следующему
        }
        return current.IsAcceptState;         // результат true если в конце финальное состояние 
    }
  }

  class FA1 : FA
{
    public static State q0 = new State()
    {
        Name = "q0",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State q1 = new State()
    {
        Name = "q1",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State q2 = new State()
    {
        Name = "q2",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public State q3 = new State()
    {
        Name = "q2",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public FA1()
    {
        q0.Transitions['0'] = q1;
        q0.Transitions['1'] = q0;
        q1.Transitions['1'] = q2;
        q1.Transitions['0'] = q3;
        q2.Transitions['0'] = q3;
        q2.Transitions['1'] = q2;
        q3.Transitions['1'] = q3;
        q3.Transitions['0'] = q3;
    }
    public bool? Run(IEnumerable<char> s)=>base.Run(q0, s);
}

  class FA2 : FA
{
    public static State q0 = new State()
    {
        Name = "q0",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State q1 = new State()
    {
        Name = "q1",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State q2 = new State()
    {
        Name = "q2",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State q3 = new State()
    {
        Name = "q2",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public FA2()
    {
        q0.Transitions['0'] = q1;
        q0.Transitions['1'] = q2;
        q1.Transitions['1'] = q3;
        q1.Transitions['0'] = q0;
        q2.Transitions['1'] = q0;
        q2.Transitions['0'] = q3;
        q3.Transitions['1'] = q1;
        q3.Transitions['0'] = q2;

    }
    public bool? Run(IEnumerable<char> s) => base.Run(q0, s);
}
  
  class FA3 : FA
{
    public static State q0 = new State()
    {
        Name = "q0",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State q1 = new State()
    {
        Name = "q1",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State q2 = new State()
    {
        Name = "q2",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public FA3()
    {
        q0.Transitions['0'] = q0;
        q0.Transitions['1'] = q1;
        q1.Transitions['1'] = q2;
        q1.Transitions['0']= q0;
        q2.Transitions['1'] = q2;
        q2.Transitions['0'] = q2;

    }
    public bool? Run(IEnumerable<char> s) => base.Run(q0, s);
}

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
