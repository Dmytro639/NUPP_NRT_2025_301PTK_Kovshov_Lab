namespace Plants.Common
{
    public class Plant
    {
        public string Name { get; set; }
        public string Type { get; set; } 
        public string Habitat { get; set; } 
        public Photosynthesis PhotosynthesisProcess { get; set; }

        public Plant(string name, string type, string habitat)
        {
            Name = name;
            Type = type;
            Habitat = habitat;
            PhotosynthesisProcess = new Photosynthesis();
        }

        public void Grow()
        {
            Console.WriteLine($"{Name} росте у {Habitat} середовищі.");
        }

        public void PerformPhotosynthesis(double sunlight, double water, double co2)
        {
            double glucoseProduced = PhotosynthesisProcess.Execute(sunlight, water, co2);
            Console.WriteLine($"{Name} виробила {glucoseProduced:F2} одиниць глюкози.");
        }
    }
}
