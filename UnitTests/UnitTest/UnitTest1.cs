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

        [Fact]
        public void SolveSystemOfLinearEquations()
        {
            double[,] array = { { 0,2,1,4},{1,1,2,6},{2,1,1,7} };
            var result = _calculator.GaussElimination(array);
            double[] expected = { 2.2, 1.4, 1.2 };
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public void HasInfiniteSolutions()
        {
            double[,] array = { { 1,1,1, 3 }, { 2, 4, 1, 8 }, { 6, 10, 4, 22 } };
            _calculator.GaussElimination(array);
            var result = _calculator.CheckForInfinitySolutions(array);
            var expected = true;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HasNoSolutions()
        {
            double[,] array = { { 1, 1, -1, 2 }, { 2, 3, -1, 0 }, { 3, 4, -2, 1 } };
            _calculator.GaussElimination(array);
            var result = _calculator.CheckForNoSolutions(array);
            var expected = true;
            Assert.Equal(expected, result);
        }
    }
}