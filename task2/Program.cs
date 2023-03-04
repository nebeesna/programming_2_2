using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    /*
    Продемонструвати прикладами можливості перевантажених у класах Matrix та Vector операторів та методів.
    */

    class Matrix
    {
        private int[,] array;
        private int m;
        private int n;
        private static Random random = new Random();

        public Matrix()
        {
            m = 0;
            n = 0;
            array = new int[m, n];
        }
        public Matrix(Matrix other)
        {
            m = other.m;
            n = other.n;
            array = other.array;
        }
        public Matrix(int[,] arr)
        {
            m = arr.GetLength(0);
            n = arr.GetLength(1);
            array = arr;
        }
        public Matrix(int a, int b)
        {
            m = a;
            n = b;
            array = new int[m, n];
        }
        public int M
        {
            get { return m; }
        }
        public int N
        {
            get { return n; }
        }
        public int[,] Array
        {
            get { return array; }
        }
        static private int GetRandomNumbers(int min, int max)
        {
            return random.Next(min, max);
        }
        public void SetRandomValues()
        {
            for (int i = 0; i < this.m; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    this.array[i, j] = GetRandomNumbers(-100, 100);
                }
            }
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str += array[i, j] + "\t";
                }
                str += "\n";
            }
            return str;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Matrix)
            {
                Matrix otherMatrix = (Matrix)obj;
                if (this.m == otherMatrix.m && this.n == otherMatrix.n)
                {
                    for (int i = 0; i < this.m; i++)
                        for (int j = 0; j < this.n; j++)
                            if (this.array[i, j] != otherMatrix.array[i, j])
                                return false;
                    return true;
                }
                else return false;
            }
            else return false;
        }
        static public bool operator ==(Matrix other, Matrix another)
        {
            return other.Equals(another);
        }
        static public bool operator !=(Matrix other, Matrix another)
        {
            return !other.Equals(another);
        }
        static public Matrix operator +(Matrix other, Matrix another)
        {
            if (other.m == another.m && other.n == another.n)
            {
                Matrix result = new Matrix(other.m, other.n);
                for (int i = 0; i < result.m; i++)
                    for (int j = 0; j < result.n; j++)
                        result.array[i, j] = other.array[i, j] + another.array[i, j];
                return result;
            }
            else
                throw new InvalidOperationException("invalid matrixes sizes");
        }
        static public Matrix operator -(Matrix other, Matrix another)
        {
            if (other.m == another.m && other.n == another.n)
            {
                Matrix result = new Matrix(other.m, other.n);
                for (int i = 0; i < result.m; i++)
                    for (int j = 0; j < result.n; j++)
                        result.array[i, j] = other.array[i, j] - another.array[i, j];
                return result;
            }
            else
                throw new InvalidOperationException("invalid matrixes sizes");
        }
        static public Matrix operator *(Matrix other, int num)
        {
            Matrix result = new Matrix(other.m, other.n);
            for (int i = 0; i < result.m; i++)
                for (int j = 0; j < result.n; j++)
                    result.array[i, j] = other.array[i, j] * num;
            return result;
        }
        static public Matrix operator *(int num, Matrix other)
        {
            return other * num;
        }
        static public Matrix operator *(Matrix other, Matrix another)
        {
            if (other.m == another.n)
            {
                Matrix result = new Matrix(other.m, another.n);
                for (int i = 0; i < other.m; i++)
                    for (int j = 0; j < another.n; j++)
                        for (int k = 0; k < other.n; k++)
                            result.array[i,j] += other.array[i,k] * another.array[k,j];
                return result;
            }
            else
                throw new InvalidOperationException("invalid matrixes sizes");
        }
        static public Matrix operator *(Matrix other, Vector another)
        {
            if (other.n == 1 && other.m == another.K)
            {
                Matrix resultMatrix = new Matrix(another.K, another.K);
                for (int i = 0; i < resultMatrix.m; i++)
                    for (int j = 0; j < resultMatrix.m; j++)
                        resultMatrix[i, j] = other[i, 0] * another[j];
                return resultMatrix;
            }
            else if (other.n == another.K)
            {
                Matrix resultMatrix = new Matrix(other.m, 1);
                for (int i = 0; i < other.m; i++)               
                {
                    for (int j = 0; j < other.n; j++)
                        resultMatrix[i, 0] += other[i, j] * another[j];
                }
                return resultMatrix;
            }
            else throw new InvalidOperationException("invalid sizes");
        }
        public int this[int x, int y]
        {
            get { return array[x, y]; }
            set { array[x, y] = value; }
        }
    }
    class Vector
    {
        private int[] array;
        private int k;
        private static Random random = new Random();

        public Vector()
        {
            k = 0;
            array = new int[k];
        }
        public Vector(Vector other)
        {
            k = other.k;
            array = other.array;
        }
        public Vector(int[] arr)
        {
            k = arr.Length;
            array = arr;
        }
        public Vector(int a)
        {
            k = a;
            array = new int[k];
        }
        public int K
        {
            get { return k; }
        }
        public int[] Array
        {
            get { return array; }
        }
        private static int GetRandomNumbers(int min, int max)
        {
            return random.Next(min, max);
        }
        public void SetRandomValues()
        {
            for (int i = 0; i < this.k; i++)
            {
                this.array[i] = GetRandomNumbers(-100, 100);
            }
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < k; i++)
            {
                str += array[i] + "\t";
            }
            str += "\n";
            return str;
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Vector)
            {
                Vector otherMatrix = (Vector)obj;
                if (this.k == otherMatrix.k)
                {
                    for (int i = 0; i < this.k; i++)
                        if (this.array[i] != otherMatrix.array[i])
                            return false;
                    return true;
                }
                else return false;
            }
            else return false;
        }
        static public bool operator ==(Vector other, Vector another)
        {
            return other.Equals(another);
        }
        static public bool operator !=(Vector other, Vector another)
        {
            return !other.Equals(another);
        }
        static public Vector operator +(Vector other, Vector another)
        {
            if (other.k == another.k)
            {
                Vector result = new Vector(other.k);
                for (int i = 0; i < result.k; i++)
                {
                    result.array[i] = other.array[i] + another.array[i];
                }
                return result;
            }
            else
                throw new InvalidOperationException("invalid vector's sizes");
        }
        static public Vector operator -(Vector other, Vector another)
        {
            if (other.k == another.k)
            {
                Vector result = new Vector(other.k);
                for (int i = 0; i < result.k; i++)
                {
                    result.array[i] = other.array[i] - another.array[i];
                }
                return result;
            }
            else
                throw new InvalidOperationException("invalid matrixes sizes");
        }
        static public Vector operator *(Vector other, int num)
        {
            Vector result = new Vector(other.k);
            for (int i = 0; i < result.k; i++)
            {
                result.array[i] = other.array[i] * num;
            }
            return result;
        }
        static public Vector operator *(int num, Vector other)
        {
            return other * num;
        }
        static public Matrix operator *(Vector other, Matrix another)
        {
            return another * other;
        }
        public int this[int x]
        {
            get { return array[x];}
            set { array[x] = value;}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matrix():");
            Matrix matrix0 = new Matrix();
            Console.WriteLine(matrix0);

            Console.WriteLine("Matrix([,]arr):");
            int[,] arr1 = { { 1, 4, 6 }, { 7, 8, 9 } };
            Matrix matrix1 = new Matrix(arr1);
            Console.WriteLine(matrix1);

            Console.WriteLine("Matrix(matr):");
            Matrix matrix2 = new Matrix(arr1);
            Console.WriteLine(matrix2);

            Console.WriteLine(matrix1.GetHashCode());
            Console.WriteLine(matrix2.GetHashCode());



            Console.WriteLine("Matrix(a,b):");
            Matrix matrix3 = new Matrix(2,3);
            Console.WriteLine(matrix3);
            matrix3.SetRandomValues();

            Console.WriteLine("Set random values:");
            Console.WriteLine(matrix3);
            Console.WriteLine("matrix3[0,1] = 2");
            matrix3[0, 1] = 2;
            Console.WriteLine(matrix3);

            Console.WriteLine("Get Hash Code:");
            Console.WriteLine($"Matrix 1: { matrix1.GetHashCode()}");
            Console.WriteLine($"Matrix 2: { matrix2.GetHashCode()}");

            Console.WriteLine("\nEquals:");
            Console.WriteLine($"Matrix1 == Matrix2: {matrix1 == matrix2}");
            Console.WriteLine($"Matrix2 == Matrix3: {matrix2 == matrix3}");

            Console.WriteLine("\nMatrix1 + Matrix3:");
            Console.WriteLine(matrix1+matrix3);

            Console.WriteLine("\nMatrix1 - Matrix3:");
            Console.WriteLine(matrix1-matrix3);

            Console.WriteLine("\nMatrix1 * 6:");
            Console.WriteLine(matrix1*6);
            Console.WriteLine("\n6 * Matrix1:");
            Console.WriteLine(6 * matrix1);

            Matrix matrix4 = new Matrix(3, 2);
            matrix4.SetRandomValues();
            Console.WriteLine(matrix4);
            Console.WriteLine("\nMatrix4 * matrix3:");
            Console.WriteLine(matrix4 * matrix3);


            Console.WriteLine("Vector():");
            Vector vector0 = new Vector();
            Console.WriteLine(vector0);

            Console.WriteLine("Vector([,]arr):");
            int[] arr2 = {2,6,7};
            Vector vec1 = new Vector(arr2);
            Console.WriteLine(vec1);

            Console.WriteLine("Vector(arr):");
            Vector vec2 = new Vector(vec1);
            Console.WriteLine(vec2);

            Console.WriteLine("Vector(a):");
            Vector vec3 = new Vector(3);
            Console.WriteLine(vec3);
            vec3.SetRandomValues();
            Console.WriteLine("Set random values:");
            Console.WriteLine(vec3);
            Console.WriteLine("vec3[2] = 3");
            vec3[2] = 3;

            Console.WriteLine("Get Hash Code:");
            Console.WriteLine($"Vector 1: { vec1.GetHashCode()}");
            Console.WriteLine($"Vector 2: { vec2.GetHashCode()}");

            Console.WriteLine("\nEquals:");
            Console.WriteLine($"Vector1 == Vector2: {vec1 == vec2}");
            Console.WriteLine($"Vector2 == Vector3: {vec2 == vec3}");

            Console.WriteLine("\nVector1 + Vector3:");
            Console.WriteLine(vec1+vec3);

            Console.WriteLine("\nVector1 - Vector3:");
            Console.WriteLine(vec1-vec3);

            Console.WriteLine("\nVector1 * 6:");
            Console.WriteLine(vec1 * 6);
            Console.WriteLine("\n6 * Vector1:");
            Console.WriteLine(6 * vec1);

            Matrix matrix5 = new Matrix(3, 1);
            matrix5.SetRandomValues();
            Console.WriteLine("Matrix5:");
            Console.WriteLine(matrix5);
            Console.WriteLine("Vector3 * Matrix5:");
            Console.WriteLine(vec3 * matrix5);
            Console.WriteLine("\nMatrix5 * Vector3:");
            Console.WriteLine(matrix5 * vec3);

            Vector vec4 = new Vector(2);
            vec4.SetRandomValues();
            Console.WriteLine(vec4);

            Console.WriteLine("Matrix4 * Vector4:");
            Console.WriteLine(matrix4 * vec4);
            
            Console.WriteLine("\nVector4 * Matrix3:");
            Console.WriteLine(vec4 * matrix3);


        }
    }
}
