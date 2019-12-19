using System;
using System.Threading;

namespace simpleEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Metronome m = new Metronome();
            Metronome m2 = new Metronome();
            Listener l = new Listener();
            l.Subscribe(m);
            l.Subscribe(m2);

            m.Start();
            m2.Start2();
        }


        public class Metronome
        {
            public event TickHandler Tick;
            public delegate void TickHandler(Metronome m, TimeOfTick e);

            public void Start()
            {
                int count = 0;
                while (count < 4)
                {
                    Thread.Sleep(1000);
                    if (Tick != null)
                    {
                        TimeOfTick TOT = new TimeOfTick();
                        TOT.Time = DateTime.Now;
                        Tick(this, TOT);
                    }
                    count++;
                }
            }

            public void Start2()
            {
                int count = 0;
                while (count < 4)
                {
                    Thread.Sleep(1000);
                    if (Tick != null)
                    {
                        TimeOfTick TOT = new TimeOfTick();
                        TOT.Time = DateTime.Now.AddYears(10);
                        Tick(this, TOT);
                    }
                    count++;
                }
            }
        }


        public class Listener
        {
            public void Subscribe(Metronome m)
            {
                m.Tick += new Metronome.TickHandler(HeardIt);
            }

            private void HeardIt(Metronome m, TimeOfTick e)
            {
                Console.WriteLine("HEARD IT AT {0}", e.Time);
            }

        }

        public class TimeOfTick : EventArgs
        {
            private DateTime TimeNow;
            public DateTime Time
            {
                set
                {
                    TimeNow = value;
                }
                get
                {
                    return this.TimeNow;
                }
            }
        }
    }
}
