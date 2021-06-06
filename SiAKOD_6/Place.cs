using System;
using System.Collections.Generic;
using System.Text;

namespace SiAKOD_6
{
    public class Place
    {
        public int EaterCount { get; set; }
        public int ManCount { get; set; }
        public Place(int man, int eater)
        {
            EaterCount = eater;
            ManCount = man;
        }
        public Place()
        {
            EaterCount = 0;
            ManCount = 0;
        }

        public void GetFrom(Place place, int m, int e)
        {
            if (place.EaterCount >= e)
            {
                EaterCount += e;
                place.EaterCount -= e;
            }
            else
            {
                EaterCount += place.EaterCount;
                place.EaterCount = 0;
            }
            if (place.ManCount >= m)
            {
                ManCount += m;
                place.ManCount -= m;
            }
            else
            {
                ManCount += place.ManCount;
                place.ManCount = 0;
            }
        }
        public bool IsMore()
        {
            if (EaterCount == 0 || ManCount == 0) return false;
            return (EaterCount != ManCount);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Place objAsPart = obj as Place;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(Place obj)
        {
            return obj.EaterCount == EaterCount && obj.ManCount == ManCount;
        }
        public Place Clone()
        {
            return new Place(ManCount, EaterCount);
        }
        public override string ToString()
        {
            String s = "";
            for (int i = 0; i < EaterCount; i++)
            {
                s += "e";
            }
            for (int i = 0; i < ManCount; i++)
            {
                s += "m";
            }
            if (s.Length == 0)
            {
                return "_";
            }
            return s;
        }

        public override int GetHashCode()
        {
            return Int32.Parse(ManCount.ToString()+EaterCount.ToString());
        }
    }
}
