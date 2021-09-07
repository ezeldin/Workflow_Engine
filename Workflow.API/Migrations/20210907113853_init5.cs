using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.API.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Steps_NextStepId",
                table: "Actions");

            migrationBuilder.AlterColumn<int>(
                name: "NextStepId",
                table: "Actions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Steps_NextStepId",
                table: "Actions",
                column: "NextStepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Steps_NextStepId",
                table: "Actions");

            migrationBuilder.AlterColumn<int>(
                name: "NextStepId",
                table: "Actions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Steps_NextStepId",
                table: "Actions",
                column: "NextStepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
