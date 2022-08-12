using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoWorking.Migrations
{
    public partial class classroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classroom_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_PlaceId",
                table: "Classroom",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classroom");
        }
    }
}
