using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationFramework
{
    public class DataProcessor
    {
        public static bool IsValuePresentInList(IEnumerable<string> expectedVal, IEnumerable<string> actualValues)
        {
            if (actualValues == null)
            {
                throw new ArgumentNullException(nameof(actualValues));
            }
            bool result = false;
            foreach (var item in expectedVal)
            {
                result = actualValues.Any(val => val.Contains(item));
            }

            var foundNotFound = result ? "Present" : "Absent";
            Console.WriteLine($@"Look for value '{expectedVal}'	:	{foundNotFound}");
            return result;
        }
    }
}
