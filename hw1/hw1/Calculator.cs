namespace hw1
{
    public class Calculator
    {
        public static int Calculate(Operations operation, int val1, int val2)
        {
            var result = operation switch
            {
                Operations.Plus => val1 + val2,
                Operations.Minus => val1 - val2,
                Operations.Multiply => val1 * val2,
                Operations.Divide => val1 / val2,
                _ => 0
            };
            

            return result;
        }
    }
}