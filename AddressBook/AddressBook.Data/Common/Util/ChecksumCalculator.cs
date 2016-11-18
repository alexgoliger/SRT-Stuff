using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Common.Util
{
  public class ChecksumCalculator
  {
    private const int MODULUS = 10;
    public int Number { get; }

    public ChecksumCalculator(int number)
    {
      Number = Math.Abs(number);
    }

    public int CalculateChecksum()
    {
      int sum = CalculateSumOfDigits();
      int finalDigitInSum = sum % MODULUS; // to get the final digit modulo MODULUS
      int finalDigit = (MODULUS - finalDigitInSum) % MODULUS;
      return MODULUS * Number + finalDigit;
    }

    public int ReverseChecksum()
    {
      return Number / MODULUS;
    }

    private int CalculateSumOfDigits()
    {
      int sum = 0;
      int number = Number;
      while (number > 0)
      {
        sum += number % MODULUS;
        number /= MODULUS;
      }

      return sum;
    }
  }
}
