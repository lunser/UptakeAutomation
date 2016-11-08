using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationFramework
{
    public class DataProcessor
    {
        public static bool VerifyValuesMatch(IEnumerable<string> expectedValues, IEnumerable<string> actualValues)
        {
            if (actualValues == null)
            {
                throw new ArgumentNullException(nameof(actualValues));
            }
            var result = expectedValues.Count(item => actualValues.Any(val => val.Contains(item)));
            return result == actualValues.Count();
        }
    }
}
