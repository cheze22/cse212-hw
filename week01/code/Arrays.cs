using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Initialize a new array of doubles with the size provided by the 'length' parameter.
        // 2. Create a for loop that iterates from 0 up to 'length - 1'.
        // 3. Inside the loop, calculate the multiple by multiplying 'number' by (current index + 1).
        // 4. Assign the calculated multiple to the corresponding index in the array.
        // 5. Return the completed array of multiples.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// {1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3, the result is {7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Calculate the starting index of the portion that needs to move to the front (data.Count - amount).
        // 2. Use GetRange to extract the elements from the split point to the end of the list.
        // 3. Use GetRange to extract the elements from the beginning of the list to the split point.
        // 4. Clear the original data list to prepare for re-assembly.
        // 5. Use AddRange to add the back portion (the rotated elements) to the empty list first.
        // 6. Use AddRange to add the front portion (the remaining elements) back into the list.

        if (data.Count == 0) return;

        // Use modulo to ensure amount doesn't exceed list size, though the prompt says it is in range.
        int rotationAmount = amount % data.Count;
        if (rotationAmount == 0) return;

        int splitPoint = data.Count - rotationAmount;

        // Slice the list into two parts
        List<int> backPart = data.GetRange(splitPoint, rotationAmount);
        List<int> frontPart = data.GetRange(0, splitPoint);

        // Rebuild the original list
        data.Clear();
        data.AddRange(backPart);
        data.AddRange(frontPart);
    }
}