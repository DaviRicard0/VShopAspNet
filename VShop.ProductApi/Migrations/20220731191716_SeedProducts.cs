using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "Values('Lapís',3.99,'Lápis de Carbono',20,'LapisC.jpg',1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "Values('Caderno',10.99,'Caderno de Pano',10,'caderno.jpg',1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "Values('Borracha',1.99,'Borracha de elatano',5,'boRracha.jpg',1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId) " +
                "Values('Laterna',29.99,'Lanterna biodegradável',50,'lanter.jpg',2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
