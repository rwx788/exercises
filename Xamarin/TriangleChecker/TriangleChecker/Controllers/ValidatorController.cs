using System;
using System.Globalization;

namespace TriangleChecker.Controllers
{
    public enum TriangleTypes { Equilateral, Isosceles, Scalene, None }


    public class ValidatorController
    {
        /// <summary>Method evaluates if there is a triangle by given
        /// length sides. If it the case, type of the triangle is returned.
        /// Following types are supported: Equilateral, Isosceles, Scalene.
        /// <example>For example:
        /// <code>
        ///    Enum type = ValidatorController.GetTriangleType((UInt32)a, (UInt32)b, (UInt32)c);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="sideA">Integer value whic denotes length of the side A.</param>
        /// <param name="sideB">Integer value whic denotes length of the side B.</param>
        /// <param name="sideC">Integer value whic denotes length of the side C.</param>
        /// <returns>
        /// Enum one of the values of <c>TriangleTypes</c> enum.
        /// </returns>
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

        /// <summary>Method tries to parse input string and return corresponding 
        /// unsigned integer value. Zero is returned in case given string cannot be parsed.
        /// See documentation for <c>UInt32.TryParse</c>.
        /// <example>For example:
        /// <code>
        ///    ValidatorController.ParseInput("777");
        /// </code>
        /// results in <c>UInt32</c> value 777.
        /// </example>
        /// </summary>
        /// <param name="input">Input string, which we try to parse to unsigned integer.</param>
        public static UInt32 ParseInput(string input)
        {

            UInt32 number;
            bool result = UInt32.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out number);
 
            return result ? number : 0;
        }
    }
}
