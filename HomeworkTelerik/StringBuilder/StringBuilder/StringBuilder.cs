namespace StringBuilder
{
    public static class StringBuilder
    {
        public static string SubstringTwo(this string input, int index, int length)
        {
            if (index < 0 || index > input.Length)
                return "Index must be over 0 and smaller than the count of letters.";
            else if (length < 0 || length > input.Length + index)
                return "Length must be over 0 and smaller than the count of letters.";
            else
            {
                char[] inputArray = input.ToCharArray();
                char[] result = new char[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = inputArray[index+i];
                }
                return new string(result);
            }
        }
    }
}
