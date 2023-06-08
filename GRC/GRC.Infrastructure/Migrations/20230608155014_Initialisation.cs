using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganisationTable",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationTable", x => x.OrganisationId);
                });

            migrationBuilder.CreateTable(
                name: "JobTable",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTable", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobTable_OrganisationTable_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "OrganisationTable",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonneTable",
                columns: table => new
                {
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneTable", x => x.PersonneId);
                    table.ForeignKey(
                        name: "FK_PersonneTable_JobTable_JobId",
                        column: x => x.JobId,
                        principalTable: "JobTable",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTable_OrganisationId",
                table: "JobTable",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneTable_JobId",
                table: "PersonneTable",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonneTable");

            migrationBuilder.DropTable(
                name: "JobTable");

            migrationBuilder.DropTable(
                name: "OrganisationTable");
        }
    }
}
