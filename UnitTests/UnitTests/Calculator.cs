namespace UnitTests
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public double[] SolveQuadraticEquation(double a, double b,double c)
        {
            List<double> result = new List<double>();

            double discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                throw new Exception("Discriminant is negativ. Quadratic has no real solution.");
            }
            else if(discriminant == 0) 
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
    }
}