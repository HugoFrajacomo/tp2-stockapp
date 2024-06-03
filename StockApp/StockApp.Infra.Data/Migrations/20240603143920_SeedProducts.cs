using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" + "VALUES('Caderno Espiral','caderno espiral 100 folhas', 7.45, 50, 'Caderno1.jpg', 1)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" + "VALUES('Estojo Escolar','Estojo de metal cinza', 12.50, 30, 'estojocinza.jpg', 2)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" + "VALUES('Calculadora CASIO','Calculadroa Casio Cientifica', 90.65, 12, 'calculadora.jpg', 3)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" + "VALUES('Borracha Hello Kitty','Borracha com Cheiro Hello Kitty', 9.99, 90, 'Borrachahk.jpg', 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
