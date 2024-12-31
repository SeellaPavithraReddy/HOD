using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HODPoc.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hod7",
                columns: table => new
                {
                    hodId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    school = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hod7", x => x.hodId);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Teacher7",
                columns: table => new
                {
                    tId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    tName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hodId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher7", x => x.tId);
                    table.ForeignKey(
                        name: "FK_Teacher7_Hod7_hodId",
                        column: x => x.hodId,
                        principalTable: "Hod7",
                        principalColumn: "hodId");
                });

            migrationBuilder.CreateTable(
                name: "HodStudent7",
                columns: table => new
                {
                    sId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    sname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    add = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sclass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeachertId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    hodId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HodStudent7", x => x.sId);
                    table.ForeignKey(
                        name: "FK_HodStudent7_Hod7_hodId",
                        column: x => x.hodId,
                        principalTable: "Hod7",
                        principalColumn: "hodId");
                    table.ForeignKey(
                        name: "FK_HodStudent7_Teacher7_TeachertId",
                        column: x => x.TeachertId,
                        principalTable: "Teacher7",
                        principalColumn: "tId");
                });

            migrationBuilder.CreateTable(
                name: "Subject7",
                columns: table => new
                {
                    suId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    science = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    social = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    english = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telugu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hindi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeachertId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    hodId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject7", x => x.suId);
                    table.ForeignKey(
                        name: "FK_Subject7_Hod7_hodId",
                        column: x => x.hodId,
                        principalTable: "Hod7",
                        principalColumn: "hodId");
                    table.ForeignKey(
                        name: "FK_Subject7_Teacher7_TeachertId",
                        column: x => x.TeachertId,
                        principalTable: "Teacher7",
                        principalColumn: "tId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    SubjectssuId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    studentssId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.SubjectssuId, x.studentssId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_HodStudent7_studentssId",
                        column: x => x.studentssId,
                        principalTable: "HodStudent7",
                        principalColumn: "sId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject7_SubjectssuId",
                        column: x => x.SubjectssuId,
                        principalTable: "Subject7",
                        principalColumn: "suId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HodStudent7_hodId",
                table: "HodStudent7",
                column: "hodId");

            migrationBuilder.CreateIndex(
                name: "IX_HodStudent7_TeachertId",
                table: "HodStudent7",
                column: "TeachertId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_studentssId",
                table: "StudentSubject",
                column: "studentssId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject7_hodId",
                table: "Subject7",
                column: "hodId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject7_TeachertId",
                table: "Subject7",
                column: "TeachertId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher7_hodId",
                table: "Teacher7",
                column: "hodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "HodStudent7");

            migrationBuilder.DropTable(
                name: "Subject7");

            migrationBuilder.DropTable(
                name: "Teacher7");

            migrationBuilder.DropTable(
                name: "Hod7");
        }
    }
}
