namespace WordFinder.Application.Features.Matrix
{
    public static class MatrixCreator
    {
        public static char[,] CreateMatrixFromStringArray(IEnumerable<string> values)
        {
            string[] namesToFind = values.ToArray();
            if (namesToFind == null || namesToFind.Length == 0)
                throw new ArgumentException("The Names array cannot be empty or null.");
         
            int stringLength = namesToFind[0].Length;
            char[,] charsMatrix = new char[namesToFind.Length, stringLength];

            for (int i = 0; i < namesToFind.Length; i++)
            {
                if (namesToFind[i].Length != stringLength)
                    throw new ArgumentException("The Items do not have the same size.");

               for (int j = 0; j < stringLength; j++)
                {
                    charsMatrix[i, j] = namesToFind[i][j];
                }
            }
            return charsMatrix;
        }
    }
}
