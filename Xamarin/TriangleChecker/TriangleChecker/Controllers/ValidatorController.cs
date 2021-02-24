using System;

namespace TriangleChecker.Controllers
{
    public enum TriangleTypes { Equilateral, Isosceles, Scalene, None }

    public class ValidatorController
    {
        public static Enum GetTriangleType(UInt32 sideA, UInt32 sideB, UInt32 sideC)
        {
            if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideC + sideA <= sideB)
                return TriangleTypes.None;

            if (sideA == sideB && sideB == sideC && sideC == sideA)
                return TriangleTypes.Equilateral;

            if (sideA == sideB || sideB == sideC || sideC == sideA)
                return TriangleTypes.Isosceles;

            return TriangleTypes.Scalene;
        }
    }
}
