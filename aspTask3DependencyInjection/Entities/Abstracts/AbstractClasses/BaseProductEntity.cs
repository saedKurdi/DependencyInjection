using aspTask3DependencyInjection.Entities.Abstracts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace aspTask3DependencyInjection.Entities.Abstracts.AbstractClasses
{
    public abstract class BaseProductEntity : IId, IProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required for product !")]
        [MinLength(3,ErrorMessage = "Name's minimum length must be 3 !")]
        [MaxLength(15,ErrorMessage = "Name's maximum length must be 15 !")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Discount is required !")]
        [Range(0,100,ErrorMessage = "Discount must be around 0 and 100 !")]
        public int Discount { get; set; }
        [Required(ErrorMessage = "Price is required !")]
        [Range(1,50,ErrorMessage ="Price must be around 1 and 50 !")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Correct Image path required !")]
        public string ImagePath { get; set; }

        // parametric constructor :
        protected BaseProductEntity(int id ,string name,string description,int discount,int price,string imgPath)
        {
            Id = id;
            Name = name;
            Description = description;
            Discount = discount;
            Price = price;
            ImagePath = imgPath;
        }

        // default constructor :  
        protected BaseProductEntity() { }

        // other methods : 
        public int GetDiscountedPrice() => (Price - ((Price * Discount) / 100));
    }
}
