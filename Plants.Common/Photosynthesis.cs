namespace Plants.Common
{
    public class Photosynthesis
    {
        public double Execute(double sunlight, double water, double co2)
        {
            return (sunlight * 0.5 + water * 0.3 + co2 * 0.2);
        }
    }
}
