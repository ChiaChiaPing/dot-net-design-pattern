using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TestCode
{
    public class FallsIllEventArgs
    {
        public string Address;
    }

    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void CatchACold()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs { Address = "Hello world address" });
        }

    }


}
