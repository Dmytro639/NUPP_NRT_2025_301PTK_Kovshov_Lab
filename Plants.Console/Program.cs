using Plants.Common;

class Program
{
    static void Main()
    {
        Plant oak = new Plant("Дуб", "Дерево", "Ліс");
        Plant rose = new Plant("Троянда", "Кущ", "Сад");

        oak.Grow();
        oak.PerformPhotosynthesis(sunlight: 8, water: 5, co2: 3);

        rose.Grow();
        rose.PerformPhotosynthesis(sunlight: 6, water: 4, co2: 2);
    }
}
