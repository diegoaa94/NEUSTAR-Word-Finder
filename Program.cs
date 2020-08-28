using System;

class Program
{
    public static bool findWord(char[,] matrix, string wordToFind)
    {
        return findWordHorizontally(matrix, wordToFind) || findWordVertically(matrix, wordToFind);
    }

    private static bool findWordHorizontally(char[,] matrix, string wordToFind)
    {
        bool wordExists = false;
        string horizontalWord = "";

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                horizontalWord += matrix[i, j];
            }

            if (isContained(wordToFind, horizontalWord))
            {
                wordExists = true;
                break;
            }

            horizontalWord = "";
        }

        return wordExists;
    }

    private static bool findWordVertically(char[,] matrix, string wordToFind)
    {
        bool wordExists = false;
        string verticalWord = "";

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                verticalWord += matrix[j, i];
            }

            if (isContained(wordToFind, verticalWord))
            {
                wordExists = true;
                break;
            }

            verticalWord = "";
        }

        return wordExists;
    }

    static bool isContained(string word1, string word2)
    {

        bool isContained = false;

        for (int i = 0; i <= word2.Length - word1.Length; i++)
        {
            int j;

            for (j = 0; j < word1.Length; j++)
            {
                if (word1[j] != word2[i + j])
                {
                    break;
                }
            }
            if (j == word1.Length)
            {
                isContained = true;
                break;
            }
        }

        return isContained;
    }

    static void Main(string[] args)
    {
        char[,] matrix = {
            {'c', 'a', 't', 'a'},
            {'a', 'c', 'c', 't'},
            {'t', 'a', 'r', 't'},
        };

        string wordToFind = "cat";

        bool result = findWord(matrix, wordToFind);

        Console.WriteLine("Result: " + result);
    }
}