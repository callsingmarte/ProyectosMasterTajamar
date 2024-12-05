namespace BlazorApp1.Data
{
    public class TestService
    {
        public Task<double> TestCalculationAsync(double a, double b) 
        {
            return Task.FromResult(a * b);
        }
    }
}
