using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCode
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Momento1
    {
        public Token Token;
        public Momento1(Token token)
        {
            this.Token = token;
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Momento1 AddToken(int value)
        {
            var token = new Token(value);
            Tokens.Add(token);
            return new Momento1(token);
        }

        public Momento1 AddToken(Token token)
        {
            Tokens.Add(token);
            return new Momento1(token);

        }

        public void Revert(Momento1 m)
        {
            var index = Tokens.FindIndex(t => t.Equals(m.Token));
            Tokens = Tokens.GetRange(0, index - 0 + 1);
            
        }

        public override string ToString()
        {
            var context = Tokens[Tokens.Count-1]?.Value.ToString();
            return context;
        }
    }
}
