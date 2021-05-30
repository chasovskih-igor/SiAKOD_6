using System;
using System.Collections.Generic;

namespace SiAKOD_6
{
    class Program
    {
        static void Main(string[] args)
        {

            List<State> s = Search.Solution(new State(new Place(3, 3), new Place(0, 0), new Place(0, 0), BoatPosition.Left), new State(new Place(0, 0), new Place(3, 3), new Place(0, 0), BoatPosition.Right));
            foreach (State t in s)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
