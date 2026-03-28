using System;

class Program
{
    const long MOD = 1000000007;

    struct Matrix
    {
        public long a, b, c, d;

        public Matrix(long a, long b, long c, long d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
    }

    static Matrix Multiply(Matrix x, Matrix y)
    {
        return new Matrix(
            (x.a * y.a + x.b * y.c) % MOD,
            (x.a * y.b + x.b * y.d) % MOD,
            (x.c * y.a + x.d * y.c) % MOD,
            (x.c * y.b + x.d * y.d) % MOD
        );
    }

    static Matrix Power(Matrix matrix, long n)
    {
        if (n == 1)
            return matrix;

        Matrix half = Power(matrix, n / 2);
        Matrix result = Multiply(half, half);

        if (n % 2 == 1)
            result = Multiply(result, matrix);

        return result;
    }

    public static void Main()
    {
        long n = long.Parse(Console.ReadLine()!);

        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }

        Matrix base_matrix = new Matrix(1, 1, 1, 0);
        Matrix result = Power(base_matrix, n);

        Console.WriteLine(result.b.ToString());
    }
}
