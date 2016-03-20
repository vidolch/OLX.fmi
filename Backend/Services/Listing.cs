namespace Backend.Services
{
    using System;
    using System.Collections.Generic;

    public static class Listing
    {
        public static int IndexOf<T>(this IEnumerable<T> items, string valueToLookFor, string field)
        {
            if (items == null) throw new ArgumentNullException("items");

            int retVal = 0;
            foreach (var item in items)
            {
                if ((item.GetType().GetProperty(field).GetValue(item, null).ToString() == valueToLookFor))
                {
                    return retVal;
                }

                retVal++;
            }
            return -1;
        }
    }
}
