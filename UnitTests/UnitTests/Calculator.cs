namespace UnitTests
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public double[] SolveQuadraticEquation(double a, double b, double c)
        {
            List<double> result = new List<double>();

            double discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                throw new Exception("Discriminant is negativ. Quadratic has no real solution.");
            }
            else if (discriminant == 0)
            {
                result.Add(-b / (2 * a));
                return result.ToArray();
            }
            else
            {
                result.Add((-b + Math.Sqrt(discriminant)) / (2 * a));
                result.Add((-b - Math.Sqrt(discriminant)) / (2 * a));
            }
            Array.Sort(result.ToArray());
            return result.ToArray();
        }

        public double[] GaussElimination(double[,] arr)
        {
            List<double> result = new List<double>();
            int j, k = 0, c;

            int length = arr.GetLength(0);

            // Performing elementary operations
            for (int i = 0; i < length; i++)
            {
                if (arr[i, i] == 0)
                {
                    c = 1;
                    while ((i + c) < length && arr[i + c, i] == 0)
                        c++;
                    if ((i + c) == length)
                    {
                        break;
                    }
                    for (j = i, k = 0; k <= length; k++)
                    {
                        double temp = arr[j, k];
                        arr[j, k] = arr[j + c, k];
                        arr[j + c, k] = temp;
                    }
                }

                for (j = 0; j < length; j++)
                {

                    if (i != j)
                    {
                        double p = arr[j, i] / arr[i, i];

                        for (k = 0; k <= length; k++)
                            arr[j, k] = arr[j, k] - (arr[i, k]) * p;
                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                result.Add(arr[i, length] / arr[i, i]);
            }

            return result.ToArray();
        }

        public bool CheckForInfinitySolutions(double[,] a)
        {
            int i, j;
            double sum;

            for (i = 0; i < a.GetLength(0); i++)
            {
                sum = 0;
                for (j = 0; j < a.GetLength(0); j++)
                    sum = sum + a[i, j];
                if (sum == a[i, j])
                    return true;
            }
            return false;
        }

        public bool CheckForNoSolutions(double[,] a)
        {
            int length = a.GetLength(0);
            if (a[length-1,length-1] == 0 && a[length-1,length] != 0)
            {
                return true;
            }
            return false;
        }
    }
}