using System;

namespace PlantsApp.Entities
{
    public class PlantCare
    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public string UserId { get; set; }
        public DateTime CareDate { get; set; }
        public string Notes { get; set; }
    }
}
