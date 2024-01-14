using WordFinder.Application.Features.Matrix;

namespace WordFinder.Application.Features.WordFinder
{
    public class WordFinder
    {
        private readonly IEnumerable<string> _matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }
        private bool FindInDirection(char[,] matrix, string word, int row, int column, int rowDelta, int columnDelta)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 1; i < word.Length; i++)
            {
                int newRow = row + i * rowDelta;
                int newColumn = column + i * columnDelta;

                if (rowDelta == 1)
                    if (newRow < 0 || newRow >= rows || matrix[newRow, newColumn] != word[i])
                        return false;
                
                if (columnDelta == 1)
                    if (newColumn < 0 || newColumn >= columns || matrix[newRow, newColumn] != word[i])
                        return false;
            }

            return true;
        }
        private int Find(string word, char[,] letterMatrix)
        {
            int rows = letterMatrix.GetLength(0);
            int columns = letterMatrix.GetLength(1);
            int counter = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (letterMatrix[i, j] == word[0])
                    {
                        if ((rows - i > word.Length) && FindInDirection(letterMatrix, word, i, j, 1, 0))// vertical search
                            counter++;

                        if ((columns - i > word.Length) && FindInDirection(letterMatrix, word, i, j, 0, 1))// horizontal search
                            counter++;
                    }
                }
            }
            return counter;
        }
        private IEnumerable<string> GetMoreRepeatedWords(Dictionary<string, int> results, int top)
        {
            var sortedWords = results.OrderByDescending(x => x.Value);
            var topWords = sortedWords.Take(top);
            return topWords.Select(x => x.Key).ToArray();

        }
        public IEnumerable<string> Find(IEnumerable<string> words, int top)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            char[,] letterMatrix = MatrixCreator.CreateMatrixFromStringArray(_matrix);

            foreach (string word in words)
            {
                int count = Find(word.ToUpper(), letterMatrix);
                if (count > 0)
                    results.Add(word.ToUpper(), count);
            }
            return GetMoreRepeatedWords(results, top);
        }
    }
}
