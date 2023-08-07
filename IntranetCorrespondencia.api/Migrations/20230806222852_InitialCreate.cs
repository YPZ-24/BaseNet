using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntranetCorrespondencia.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 8, 6, 22, 28, 52, 507, DateTimeKind.Utc).AddTicks(1098)),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 8, 6, 22, 28, 52, 507, DateTimeKind.Utc).AddTicks(1907))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
