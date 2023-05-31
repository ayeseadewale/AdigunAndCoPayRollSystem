using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdigunAndCoPayRollSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadreLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadreLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadreLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_CadreLevel_CadreLevelId",
                        column: x => x.CadreLevelId,
                        principalTable: "CadreLevel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadreLevelId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_CadreLevel_CadreLevelId",
                        column: x => x.CadreLevelId,
                        principalTable: "CadreLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PayrollComponentAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadreLevelId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    PayrollComponentId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollComponentAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollComponentAssignment_CadreLevel_CadreLevelId",
                        column: x => x.CadreLevelId,
                        principalTable: "CadreLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayrollComponentAssignment_PayrollComponent_PayrollComponentId",
                        column: x => x.PayrollComponentId,
                        principalTable: "PayrollComponent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayrollComponentAssignment_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PayrollStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadreLevelId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    EarningComponentIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeductionComponentIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollStructure_CadreLevel_CadreLevelId",
                        column: x => x.CadreLevelId,
                        principalTable: "CadreLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayrollStructure_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CadreLevelId",
                table: "Employee",
                column: "CadreLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollComponentAssignment_CadreLevelId",
                table: "PayrollComponentAssignment",
                column: "CadreLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollComponentAssignment_PayrollComponentId",
                table: "PayrollComponentAssignment",
                column: "PayrollComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollComponentAssignment_PositionId",
                table: "PayrollComponentAssignment",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollStructure_CadreLevelId",
                table: "PayrollStructure",
                column: "CadreLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollStructure_PositionId",
                table: "PayrollStructure",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Position_CadreLevelId",
                table: "Position",
                column: "CadreLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PayrollComponentAssignment");

            migrationBuilder.DropTable(
                name: "PayrollStructure");

            migrationBuilder.DropTable(
                name: "PayrollComponent");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "CadreLevel");
        }
    }
}
