using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class mn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bqt4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bqt4", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cqt4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cqt4", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aqt4",
                columns: table => new
                {
                    id5 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bqtID1 = table.Column<int>(type: "int", nullable: true),
                    bqtID2 = table.Column<int>(type: "int", nullable: true),
                    lastID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aqt4", x => x.id5);
                    table.ForeignKey(
                        name: "FK_aqt4_bqt4_bqtID1",
                        column: x => x.bqtID1,
                        principalTable: "bqt4",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_aqt4_bqt4_bqtID2",
                        column: x => x.bqtID2,
                        principalTable: "bqt4",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "aqtcqt",
                columns: table => new
                {
                    aqtid5 = table.Column<int>(type: "int", nullable: false),
                    cqtid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aqtcqt", x => new { x.aqtid5, x.cqtid });
                    table.ForeignKey(
                        name: "FK_aqtcqt_aqt4_aqtid5",
                        column: x => x.aqtid5,
                        principalTable: "aqt4",
                        principalColumn: "id5",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aqtcqt_cqt4_cqtid",
                        column: x => x.cqtid,
                        principalTable: "cqt4",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "r",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aqtID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_r", x => x.id);
                    table.ForeignKey(
                        name: "FK_r_aqt4_aqtID",
                        column: x => x.aqtID,
                        principalTable: "aqt4",
                        principalColumn: "id5",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aqt4_bqtID1",
                table: "aqt4",
                column: "bqtID1");

            migrationBuilder.CreateIndex(
                name: "IX_aqt4_bqtID2",
                table: "aqt4",
                column: "bqtID2");

            migrationBuilder.CreateIndex(
                name: "IX_aqt4_lastID",
                table: "aqt4",
                column: "lastID");

            migrationBuilder.CreateIndex(
                name: "IX_aqtcqt_cqtid",
                table: "aqtcqt",
                column: "cqtid");

            migrationBuilder.CreateIndex(
                name: "IX_r_aqtID",
                table: "r",
                column: "aqtID");

            migrationBuilder.AddForeignKey(
                name: "FK_aqt4_r_lastID",
                table: "aqt4",
                column: "lastID",
                principalTable: "r",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aqt4_bqt4_bqtID1",
                table: "aqt4");

            migrationBuilder.DropForeignKey(
                name: "FK_aqt4_bqt4_bqtID2",
                table: "aqt4");

            migrationBuilder.DropForeignKey(
                name: "FK_aqt4_r_lastID",
                table: "aqt4");

            migrationBuilder.DropTable(
                name: "aqtcqt");

            migrationBuilder.DropTable(
                name: "cqt4");

            migrationBuilder.DropTable(
                name: "bqt4");

            migrationBuilder.DropTable(
                name: "r");

            migrationBuilder.DropTable(
                name: "aqt4");
        }
    }
}
