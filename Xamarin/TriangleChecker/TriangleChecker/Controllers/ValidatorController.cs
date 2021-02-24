using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TriangleChecker.Controllers
{
    public enum TriangleTypes { Equilateral, Isosceles, Scalene, None }

    public class ValidatorController
    {
        public static Enum GetTriangleType(Int32 sideA, Int32 sideB, Int32 sideC) 
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
