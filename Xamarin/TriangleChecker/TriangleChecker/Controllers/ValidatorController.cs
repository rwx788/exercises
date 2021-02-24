using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TriangleChecker.Controllers
{
    public enum TriangleTypes { Equilateral, Isosceles, Scalene, None }

    class ValidatorController
    {
        public static Enum GetTriangleType(int sideA, int sideB, int sideC) 
        {
            if(sideA + sideB <= sideC || sideB + sideC <= sideA || sideC + sideA <= sideB)
                return TriangleTypes.None;

            if (sideA == sideB && sideB == sideC && sideC == sideA)
                return TriangleTypes.Equilateral;

            if (sideA == sideB || sideB == sideC || sideC == sideA)
                return TriangleTypes.Isosceles;

            return TriangleTypes.Scalene;
        }
    }
}
