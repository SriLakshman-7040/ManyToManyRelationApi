using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WFM_Trail_Api.Migrations
{
    public partial class recreatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillMaps_Skills_SkillsSkillId",
                table: "SkillMaps");

            migrationBuilder.DropIndex(
                name: "IX_SkillMaps_SkillsSkillId",
                table: "SkillMaps");

            migrationBuilder.DropColumn(
                name: "SkillsSkillId",
                table: "SkillMaps");

            migrationBuilder.CreateIndex(
                name: "IX_SkillMaps_SkillId",
                table: "SkillMaps",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillMaps_Skills_SkillId",
                table: "SkillMaps",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillMaps_Skills_SkillId",
                table: "SkillMaps");

            migrationBuilder.DropIndex(
                name: "IX_SkillMaps_SkillId",
                table: "SkillMaps");

            migrationBuilder.AddColumn<int>(
                name: "SkillsSkillId",
                table: "SkillMaps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkillMaps_SkillsSkillId",
                table: "SkillMaps",
                column: "SkillsSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillMaps_Skills_SkillsSkillId",
                table: "SkillMaps",
                column: "SkillsSkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
