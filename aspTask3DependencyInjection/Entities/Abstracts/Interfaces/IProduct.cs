namespace aspTask3DependencyInjection.Entities.Abstracts.Interfaces
{
    public interface IProduct : IId
    {
        // public proeprties : 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
    }
}
