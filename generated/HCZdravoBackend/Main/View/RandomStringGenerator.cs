using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.View
{
    public class RandomStringGenerator
    {
        public string RandomString { get; set; }
        
        public int Length { get; set; }
        public RandomStringGenerator(int length)
        {
            Length = length;
            StringBuilder randomStringBuilder = new StringBuilder();
            Random randomGenerator = new Random();

            char _letter;

            for (int i = 0; i < Length; i++)
            {
                double randomFloat = randomGenerator.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * randomFloat));
                _letter = Convert.ToChar(shift + 65);
                randomStringBuilder.Append(_letter);
            }
            int _randomNumber;

            _randomNumber = randomGenerator.Next(1000, 10000);
            randomStringBuilder.Append(_randomNumber);

            RandomString = randomStringBuilder.ToString();
        }
    }
}
