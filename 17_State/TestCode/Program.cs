using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Stateless;

namespace TestCode
{
       

    class Program
    {

        // dictionay' Intialization 可以直接設置[key]=value
        private static Dictionary<State1, List<(Trigger, State1)>> rules = new Dictionary<State1, List<(Trigger, State1)>>()
        {
            [State1.OffHook] = new List<(Trigger, State1)>
            {
                (Trigger.CallDialed,State1.Connecting)
            },
            [State1.Connecting] = new List<(Trigger, State1)>
            {
                (Trigger.HangUp, State1.OffHook),
                (Trigger.CallConnected,State1.Connected)
            },
            [State1.Connected] = new List<(Trigger, State1)>
            {
                (Trigger.LeftMessages, State1.OffHook),
                (Trigger.HangUp,State1.OffHook),
                (Trigger.PlaceOnHold,State1.OnHold)
            },
            [State1.OnHold] = new List<(Trigger, State1)>
            {
                (Trigger.TakeOffHold, State1.Connected),
                (Trigger.HangUp,State1.OffHook)
            },

        };

        



        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // Classic Implementation.
            var sw = new Switch();
            sw.On();
            sw.Off();
            sw.Off();


            // Handmade State Machine
            /*
            var state = State1.OffHook;
            while (true){

                Console.WriteLine(state);

                // print the trigger of that ancttion
                for (var i = 0; i < rules[state].Count; i++)
                {
                    var (t, _) = rules[state][i];
                    Console.WriteLine($"{i} - {t}");
                }

                var input = int.Parse(Console.ReadLine());

                var (_, next_state) = rules[state][input];
                state = next_state;


            }*/

            // Switch State Machine
            /*
            var st = State2.Locked;
            var entry = new StringBuilder();
            var code = "1234";
            Console.WriteLine("Locked");
            while (true)
            {
                switch (st)
                {
                    case State2.Locked:

                        entry.Append(Console.ReadKey().KeyChar); // 營造出一種功能就是美輸入一個字就會去檢查是否符合code 的開端,一但不是 直接跳Failed, 一但是 跳Unlocked
                        if (code == entry.ToString())
                        {
                            st = State2.Unlocked;
                            break; // case 內可以有condition 也可以下break;
                        }

                        if (!code.StartsWith(entry.ToString()))
                        {
                            st = State2.Failed;
                            break;
                        }
                        break;
                    case State2.Failed:
                        Console.CursorLeft = 0; // override the work in current line in console.
                        Console.WriteLine("FAILED");
                        entry.Clear();
                        st = State2.Locked;
                        break;
                    case State2.Unlocked:
                        Console.CursorLeft = 0;
                        Console.WriteLine("UnLocked");
                        return;
                }
            }*/

            // Stateless - State Machine
            var stateMachine = new StateMachine<Health,Activity>(Health.Good);
            stateMachine.Configure(Health.Good)
                .Permit(Activity.UnProtectedSex, Health.Bad)
                .PermitIf(Activity.UnProtectedSex, Health.Bad, () => true);

            



        }
    }
}
