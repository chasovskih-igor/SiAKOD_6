﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SiAKOD_6
{
    public class State
    {
        public Place LeftCoast { get; set; }
        public Place RightCoast { get; set; }
        public Place Boat { get; set; }
        public BoatPosition Pos { get; set; }

        public State(Place lc, Place rc, Place boat, BoatPosition pos)
        {
            LeftCoast = lc;
            RightCoast = rc;
            Boat = boat;
            Pos = pos;
        }
        public State()
        {
            LeftCoast = new Place(3, 3);
            RightCoast = new Place();
            Boat = new Place();
            Pos = BoatPosition.Left;
        }
        public override string ToString()
        {
            return LeftCoast.ToString() + ' ' + Boat.ToString() + ' ' + RightCoast.ToString() + ' ' + Pos;
        }
        public bool IsLose()
        {
            if (Pos == BoatPosition.ToRight || Pos == BoatPosition.ToLeft)
            {
                return LeftCoast.IsMore() || RightCoast.IsMore() || (Boat.EaterCount == 0 && Boat.ManCount == 0);
            }
            else return false;
        }
        public void Load(int man, int eater)
        {
            if (Pos == BoatPosition.Left)
            {
                Boat.GetFrom(LeftCoast, man, eater);
                Pos = BoatPosition.ToRight;
            }
            if (Pos == BoatPosition.Right)
            {
                Boat.GetFrom(RightCoast, man, eater);
                Pos = BoatPosition.ToLeft;
            }
        }
        public void Unload()
        {
            if (Pos == BoatPosition.ToLeft)
            {
                LeftCoast.ManCount += Boat.ManCount;
                LeftCoast.EaterCount += Boat.EaterCount;
                Boat.ManCount = 0;
                Boat.EaterCount = 0;
                Pos = BoatPosition.Left;
            }
            else if (Pos == BoatPosition.ToRight)
            {
                RightCoast.ManCount += Boat.ManCount;
                RightCoast.EaterCount += Boat.EaterCount;
                Boat.ManCount = 0;
                Boat.EaterCount = 0;
                Pos = BoatPosition.Right;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            State objAsPart = obj as State;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public bool Equals(State obj)
        {
            return obj.RightCoast.Equals(RightCoast) && obj.LeftCoast.Equals(LeftCoast) && obj.Boat.Equals(Boat) && obj.Pos == Pos;
        }
        public List<State> NextStates()
        {
            List<State> states = new List<State>();
            if (Pos == BoatPosition.ToRight || Pos == BoatPosition.ToLeft)
            {
                State s = new State(LeftCoast.Clone(), RightCoast.Clone(), Boat.Clone(), Pos);
                s.Unload();
                states.Add(s);
            }
            else
            {
                State s;
                for (int i = 0; i < 3; i++)
                {
                    s = new State(LeftCoast.Clone(), RightCoast.Clone(), Boat.Clone(), Pos);
                    s.Load(i, 2 - i);
                    if (!s.IsLose())
                        states.Add(s);
                }
                s = new State(LeftCoast.Clone(), RightCoast.Clone(), Boat.Clone(), Pos);
                s.Load(1, 0);
                if (!s.IsLose())
                    states.Add(s);
                s = new State(LeftCoast.Clone(), RightCoast.Clone(), Boat.Clone(), Pos);
                s.Load(0, 1);
                if (!s.IsLose())
                    states.Add(s);
            }
            return states;
        }

        public override int GetHashCode()
        {
            String s = LeftCoast.GetHashCode().ToString() + RightCoast.GetHashCode().ToString() + Boat.GetHashCode().ToString() + ((int)Pos).ToString();
            return Int32.Parse(s);
        }
    }
}
