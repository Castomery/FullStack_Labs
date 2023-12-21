namespace UnitTest
{
    public class UnitTest1
    {
        private Calculator _calculator;
        [Fact]
        public void SolveQuadraticEquationWirhTwoSolutions()
        {
            double a = 4;
            double b = 26;
            double c = 12;
            var result = _calculator.SolveQuadraticEquation(a, b, c);

            double[] expected = {-6,-0.5};
            Assert.Equal(expected, result);
        }

        public void SolveQuadraticEquationWirhOneSolution()
        {
            double a = 1;
            double b = 2;
            double c = 1;
            var result = _calculator.SolveQuadraticEquation(a, b, c);
            double[] expected = {-1};
            Assert.Equal(expected, result);
        }

        public void SolveQuadraticEquationWirhNoSolutions()
        {
            double a = 1;
            double b = 2;
            double c = 5;
            var result = _calculator.SolveQuadraticEquation(a,b,c);
            string expected = "Discriminant is negativ. Quadratic has no real solution.";
            Assert.Equal(expected, result);
        }
    }
}