using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonsAndDragonsMonsterManualCSharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmourClass = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitDice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenseType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonsterAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DamageDice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterAction_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterAction_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonsterImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterImage_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonsterSense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenseRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: false),
                    SenseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterSense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterSense_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterSense_Sense_SenseId",
                        column: x => x.SenseId,
                        principalTable: "Sense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterAction_ActionId",
                table: "MonsterAction",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterAction_MonsterId",
                table: "MonsterAction",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterImage_MonsterId",
                table: "MonsterImage",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSense_MonsterId",
                table: "MonsterSense",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSense_SenseId",
                table: "MonsterSense",
                column: "SenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterAction");

            migrationBuilder.DropTable(
                name: "MonsterImage");

            migrationBuilder.DropTable(
                name: "MonsterSense");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Monster");

            migrationBuilder.DropTable(
                name: "Sense");
        }
    }
}
