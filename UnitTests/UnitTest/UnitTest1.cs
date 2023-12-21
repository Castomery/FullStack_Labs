using UnitTests;

namespace UnitTest
{
    public class UnitTest1
    {
        private Calculator _calculator = new Calculator();
        [Fact]
        public void SolveQuadraticEquationWirhTwoSolutions()
        {
            double a = 4;
            double b = 26;
            double c = 12;
            var result = _calculator.SolveQuadraticEquation(a, b, c);

            double[] expected = {-6,-0.5};
            Assert.Equivalent(expected, result);
        }
        [Fact]
        public void SolveQuadraticEquationWirhOneSolution()
        {
            double a = 1;
            double b = 2;
            double c = 1;
            var result = _calculator.SolveQuadraticEquation(a, b, c);
            double[] expected = {-1};
            Assert.Equal(expected, result);
        }
        [Fact]
        public void SolveQuadraticEquationWirhNoSolutions()
        {
            double a = 1;
            double b = 2;
            double c = 5;
            Assert.Throws<Exception>(() => _calculator.SolveQuadraticEquation(a, b, c));
        }
    }
}