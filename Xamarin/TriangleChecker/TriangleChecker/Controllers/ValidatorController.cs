using System;

namespace TriangleChecker.Controllers
{
    public enum TriangleTypes { Equilateral, Isosceles, Scalene, None }

    public class ValidatorController
    {
        public static Enum GetTriangleType(UInt32 sideA, UInt32 sideB, UInt32 sideC)
        {
            var uint64_sideA = Convert.ToUInt64(sideA);
            var uint64_sideB = Convert.ToUInt64(sideB);
            var uint64_sideC = Convert.ToUInt64(sideC);

            if ((uint64_sideA + uint64_sideB).CompareTo(uint64_sideC) <= 0 ||
                (uint64_sideB + uint64_sideC).CompareTo(uint64_sideA) <= 0 ||
                (uint64_sideC + uint64_sideA).CompareTo(uint64_sideB) <= 0)
            {
                return TriangleTypes.None;
            }

            if (sideA == sideB && sideB == sideC && sideC == sideA)
                return TriangleTypes.Equilateral;

            if (sideA == sideB || sideB == sideC || sideC == sideA)
                return TriangleTypes.Isosceles;

            return TriangleTypes.Scalene;
        }
    }
}
