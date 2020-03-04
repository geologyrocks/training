using System;
using System.Collections.Generic;
using System.Text;

namespace ImprovedPatternMatching
{
    public class TuplePatternsDemo
    {
        enum State { Off, Running, Paused }
        enum Transition { TurnOn, Pause, Resume, TurnOff }

        public static void DoDemo()
        {
            Console.WriteLine("\nTuplePatternsDemo");
            Console.WriteLine("------------------------------------------------------");

            DoDemo1();
            DoDemo2();
        }

        private static void DoDemo1()
        { 
            DoStateTransition1(State.Off, Transition.TurnOn);       // New state: Running
            DoStateTransition1(State.Off, Transition.Pause);        // New state: Off (i.e. same as before)
            DoStateTransition1(State.Off, Transition.Resume);       // New state: Off (i.e. same as before)
            DoStateTransition1(State.Off, Transition.TurnOff);      // New state: Off (i.e. same as before)

            DoStateTransition1(State.Running, Transition.TurnOn);   // New state: Running (i.e. same as before)
            DoStateTransition1(State.Running, Transition.Pause);    // New state: Paused
            DoStateTransition1(State.Running, Transition.Resume);   // New state: Running (i.e. same as before)
            DoStateTransition1(State.Running, Transition.TurnOff);  // New state: Off

            DoStateTransition1(State.Paused, Transition.TurnOn);    // New state: Paused (i.e. same as before)
            DoStateTransition1(State.Paused, Transition.Pause);     // New state: Paused (i.e. same as before)
            DoStateTransition1(State.Paused, Transition.Resume);    // New state: Running
            DoStateTransition1(State.Paused, Transition.TurnOff);   // New state: Paused (i.e. same as before)
        }

        private static void DoDemo2()
        {
            DoStateTransition2(State.Off, Transition.TurnOn);       // New state: Running
            DoStateTransition2(State.Off, Transition.Pause);        // New state: Off (i.e. same as before)
            DoStateTransition2(State.Off, Transition.Resume);       // New state: Off (i.e. same as before)
            DoStateTransition2(State.Off, Transition.TurnOff);      // New state: Off (i.e. same as before)

            DoStateTransition2(State.Running, Transition.TurnOn);   // New state: Running (i.e. same as before)
            DoStateTransition2(State.Running, Transition.Pause);    // New state: Paused
            DoStateTransition2(State.Running, Transition.Resume);   // New state: Running (i.e. same as before)
            DoStateTransition2(State.Running, Transition.TurnOff);  // New state: Off

            DoStateTransition2(State.Paused, Transition.TurnOn);    // New state: Paused (i.e. same as before)
            DoStateTransition2(State.Paused, Transition.Pause);     // New state: Paused (i.e. same as before)
            DoStateTransition2(State.Paused, Transition.Resume);    // New state: Running
            DoStateTransition2(State.Paused, Transition.TurnOff);   // New state: Paused (i.e. same as before)
        }

        private static void DoStateTransition1(State initialState, Transition transition)
        {
            State newState;
            switch (initialState, transition)
            {
                case (State.Off, Transition.TurnOn):
                    newState = State.Running;
                    break;
                case (State.Running, Transition.TurnOff):
                    newState = State.Off;
                    break;
                case (State.Running, Transition.Pause):
                    newState = State.Paused;
                    break;
                case (State.Paused, Transition.Resume):
                    newState = State.Running;
                    break;
                default:
                    newState = initialState;
                    break;
            }
            Console.WriteLine($"Was {initialState}, trans {transition}, now {newState}");
        }

        private static void DoStateTransition2(State initialState, Transition transition)
        {
            State newState = (initialState, transition) switch
            {
                (State.Off, Transition.TurnOn) => State.Running,
                (State.Running, Transition.TurnOff) => State.Off,
                (State.Running, Transition.Pause) => State.Paused,
                (State.Paused, Transition.Resume) => State.Running,
                _ => initialState
            };
            Console.WriteLine($"Was {initialState}, trans {transition}, now {newState}");
        }
    }
}
