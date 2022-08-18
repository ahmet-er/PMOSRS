using Microsoft.EntityFrameworkCore.Migrations;

namespace PMOSRS.Data.Core.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_SRSses_t_SRSStates_StateId",
                table: "t_SRSses");

            migrationBuilder.DropForeignKey(
                name: "FK_t_SRSses_t_TIDs_TIDId",
                table: "t_SRSses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_SRSses",
                table: "t_SRSses");

            migrationBuilder.RenameTable(
                name: "t_SRSses",
                newName: "t_SRSs");

            migrationBuilder.RenameIndex(
                name: "IX_t_SRSses_TIDId",
                table: "t_SRSs",
                newName: "IX_t_SRSs_TIDId");

            migrationBuilder.RenameIndex(
                name: "IX_t_SRSses_StateId",
                table: "t_SRSs",
                newName: "IX_t_SRSs_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_SRSs",
                table: "t_SRSs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_SRSs_t_SRSStates_StateId",
                table: "t_SRSs",
                column: "StateId",
                principalTable: "t_SRSStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_SRSs_t_TIDs_TIDId",
                table: "t_SRSs",
                column: "TIDId",
                principalTable: "t_TIDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_SRSs_t_SRSStates_StateId",
                table: "t_SRSs");

            migrationBuilder.DropForeignKey(
                name: "FK_t_SRSs_t_TIDs_TIDId",
                table: "t_SRSs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_SRSs",
                table: "t_SRSs");

            migrationBuilder.RenameTable(
                name: "t_SRSs",
                newName: "t_SRSses");

            migrationBuilder.RenameIndex(
                name: "IX_t_SRSs_TIDId",
                table: "t_SRSses",
                newName: "IX_t_SRSses_TIDId");

            migrationBuilder.RenameIndex(
                name: "IX_t_SRSs_StateId",
                table: "t_SRSses",
                newName: "IX_t_SRSses_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_SRSses",
                table: "t_SRSses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_SRSses_t_SRSStates_StateId",
                table: "t_SRSses",
                column: "StateId",
                principalTable: "t_SRSStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_SRSses_t_TIDs_TIDId",
                table: "t_SRSses",
                column: "TIDId",
                principalTable: "t_TIDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
