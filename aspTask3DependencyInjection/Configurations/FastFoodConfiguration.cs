using aspTask3DependencyInjection.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aspTask3DependencyInjection.Configurations
{
    public class FastFoodConfiguration : IEntityTypeConfiguration<FastFood>
    {
        public void Configure(EntityTypeBuilder<FastFood> builder)
        {
            // adding 'PrimaryKey' for 'FastFood' :
            builder.HasKey(f => f.Id).HasName("PK_FastFoods_Id");

            // adding 'UniqueKey' for 'FastFood' :
            builder.HasIndex(f => f.Name).IsUnique().HasDatabaseName("UK_FastFoods_Name");

            // adding 'CheckConstraint' for 'FastFood' Name : 
            builder.HasCheckConstraint("CK_FastFoods_Name","LEN(Name) BETWEEN 3 AND 15");

            // adding 'CheckConstraint' for 'FastFood' Price : 
            builder.HasCheckConstraint("CK_FastFoods_Price","Price BETWEEN 1 AND 50");

            // adding 'Required' for Price : 
            builder.Property(f => f.Price).IsRequired();

            // adding 'CheckConstraint' for 'FastFood' Discount : 
            builder.HasCheckConstraint("CK_FastFoods_Discount","Discount BETWEEN 0 AND 100");

            // adding default value for Discount : 
            builder.Property(f => f.Discount).HasDefaultValue(0);

            // adding default value for ImagePath :
            builder.Property(f => f.ImagePath).HasDefaultValue(null);

            // seed data :
            builder.HasData(
                new FastFood(1, "Burger", "Delicious beef burger", 5, 12, "images/burger.jpg", 300),
                new FastFood(2, "Pizza", "Cheesy pizza", 20, 30, "images/pizza.jpeg", 400),
                new FastFood(3, "Fries", "Crispy Fries", 4, 4, "images/fries.jpeg",100),
                new FastFood(4, "Lahmacun", "Turkish Pizza", 6, 4, "images/lahmacun.jpeg", 200),
                new FastFood(5, "Doner", "Turkish Donerrr", 0, 3, "images/doner.jpeg", 300)
            );
        }
    }
}
