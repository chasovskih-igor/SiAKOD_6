using System;
using System.Collections.Generic;
using System.Text;

namespace SiAKOD_6
{
    public class Search
    {
        public static List<State> CreatePath(Dictionary<State, State> find, State start, State end)
        {
            List<State> path = new List<State>();
            State s = end;
            path.Add(s);
            while (path[path.Count - 1] != start) { 
                bool x = find.ContainsKey(path[path.Count - 1]);
                State t = find[path[path.Count - 1]];
                path.Add(t);
            }
            path.Reverse();
            return path;
        }
        public static List<State> Solution(State start, State end)
        {
            List<State> find = new List<State>();
            List<State> wasSearch = new List<State>();
            Dictionary<State, State> pathToStart = new Dictionary<State, State>();
            find.Add(start);
            while (find.Count != 0)
            {
                State t = find[0];
                find.RemoveAt(0);
                wasSearch.Add(t);
                List<State> temp = t.NextStates();
                foreach (State s in temp)
                {

                    if (wasSearch.Contains(s))
                    {
                        continue;
                    }

                    if (!s.IsLose())
                    {
                        find.Add(s);
                        if (!pathToStart.ContainsKey(s))
                        pathToStart.Add(s, t);
                    }

                    if (s.Equals(end))
                    {
                        find = new List<State>();
                        break;
                    }
                }
            }
            return CreatePath(pathToStart, start, end);
        }

    }
}
