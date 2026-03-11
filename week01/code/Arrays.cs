public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // Step 1: Create a new array of doubles with size equal to 'length'.
        // Step 2: Loop from 1 to 'length' (inclusive) using index i.
        // Step 3: At each position (i-1) in the array, store number * i.
        //         This gives us: number*1, number*2, ..., number*length
        //         which are the first 'length' multiples of 'number'.
        // Step 4: Return the filled array.

        double[] result = new double[length];
        for (int i = 1; i <= length; i++)
        {
            result[i - 1] = number * i;
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // Step 1: Find the split index: data.Count - amount.
        //         Elements from this index to the end are the ones that "wrap around" to the front.
        //         Example: {1,2,3,4,5,6,7,8,9}, amount=3 → split at index 6 → tail = {7,8,9}
        // Step 2: Extract the tail portion (last 'amount' elements) using GetRange.
        // Step 3: Remove those elements from the end of the list using RemoveRange.
        // Step 4: Insert the extracted tail at the beginning of the list using InsertRange.

        int splitIndex = data.Count - amount;
        List<int> tail = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, tail);
    }
}
