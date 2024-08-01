using aspTask3DependencyInjection.Entities.Abstracts.AbstractClasses;

namespace aspTask3DependencyInjection.Entities.Concretes
{
    public class FastFood : BaseProductEntity
    {
        public double Ccal { get; set; }

        // parametric constructor : 
        public FastFood(int id,string name, string descpription, int discount, int price, string imgPath,double calory) :base(id,name,descpription, discount, price,imgPath)
        {
            Ccal = calory;
        }

        // default constructor : 
        public FastFood() : base() { }
    }
}
