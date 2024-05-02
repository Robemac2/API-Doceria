using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Doceria.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBancoComTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingrediente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    unidade = table.Column<string>(type: "varchar(24)", nullable: false),
                    preco = table.Column<decimal>(type: "money", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingrediente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    totalPedido = table.Column<decimal>(type: "money", nullable: false),
                    cliente = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    dataPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "receita",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tempoDePreparo = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    preco = table.Column<decimal>(type: "money", nullable: false),
                    rendimento = table.Column<int>(type: "integer", nullable: false),
                    precoUnitario = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    senha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tipoUsuario = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historico_ingrediente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ingredienteId = table.Column<int>(type: "integer", nullable: false),
                    preco = table.Column<decimal>(type: "money", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    unidade = table.Column<string>(type: "varchar(24)", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historico_ingrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_historico_ingrediente_ingrediente_ingredienteId",
                        column: x => x.ingredienteId,
                        principalTable: "ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido_receita",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pedidoId = table.Column<int>(type: "integer", nullable: false),
                    receitaId = table.Column<int>(type: "integer", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_receita", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_receita_pedido_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_receita_receita_receitaId",
                        column: x => x.receitaId,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receita_ingrediente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    receitaId = table.Column<int>(type: "integer", nullable: false),
                    ingredienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita_ingrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_receita_ingrediente_ingrediente_ingredienteId",
                        column: x => x.ingredienteId,
                        principalTable: "ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receita_ingrediente_receita_receitaId",
                        column: x => x.receitaId,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historico_ingrediente_ingredienteId",
                table: "historico_ingrediente",
                column: "ingredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_receita_pedidoId",
                table: "pedido_receita",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_receita_receitaId",
                table: "pedido_receita",
                column: "receitaId");

            migrationBuilder.CreateIndex(
                name: "IX_receita_ingrediente_ingredienteId",
                table: "receita_ingrediente",
                column: "ingredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_receita_ingrediente_receitaId",
                table: "receita_ingrediente",
                column: "receitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historico_ingrediente");

            migrationBuilder.DropTable(
                name: "pedido_receita");

            migrationBuilder.DropTable(
                name: "receita_ingrediente");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "ingrediente");

            migrationBuilder.DropTable(
                name: "receita");
        }
    }
}
