using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tree.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsGood = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkAttributeId = table.Column<int>(type: "int", nullable: false),
                    FkAttributeParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelAttributes_Attributes_FkAttributeId",
                        column: x => x.FkAttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelAttributes_Attributes_FkAttributeParentId",
                        column: x => x.FkAttributeParentId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelAttributes_FkAttributeId",
                table: "RelAttributes",
                column: "FkAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_RelAttributes_FkAttributeParentId",
                table: "RelAttributes",
                column: "FkAttributeParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelAttributes");

            migrationBuilder.DropTable(
                name: "Attributes");
        }
    }
}
