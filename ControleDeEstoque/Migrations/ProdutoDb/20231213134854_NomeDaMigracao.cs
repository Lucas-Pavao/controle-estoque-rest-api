using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeEstoque.Migrations.ProdutoDb
{
    /// <inheritdoc />
    public partial class NomeDaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_user = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    preco = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_produto");
        }
    }
}
