using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Matrix size is N*N\nEnter N: ");

            try {
                int N = int.Parse(Console.ReadLine());
                int[,] originalMatrix = new int[N, N];
                Random rand = new Random();

                Console.WriteLine("\nOriginal Matrix:");
                for (int i = 0; i < originalMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < originalMatrix.GetLength(1); j++)
                    {
                        originalMatrix[i, j] = rand.Next(-100, 100);
                    }
                }
                for (int i = 0; i < originalMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < originalMatrix.GetLength(1); j++)
                    {
                        Console.Write(originalMatrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                int[,] newMatrix = new int[N, N];
                int x = 0, y = 0;

                for (int i = 0; i < originalMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < originalMatrix.GetLength(1); j++)
                    {
                        if (originalMatrix[i, j] >= 0)
                        {
                            newMatrix[x, y] = originalMatrix[i, j];
                            y++;
                        }
                        if (y == N)
                        {
                            y = 0;
                            x++;
                        }
                    }
                }

                for (int i = 0; i < originalMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < originalMatrix.GetLength(1); j++)
                    {
                        if (originalMatrix[i, j] < 0)
                        {
                            newMatrix[x, y] = originalMatrix[i, j];
                            y++;
                        }
                        if (y == N)
                        {
                            y = 0;
                            x++;
                        }
                    }
                }

                Console.WriteLine("\n\nNew Matrix:");
                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        Console.Write(newMatrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("N entered incorrectly!");
            }
            
        }
    }
}
