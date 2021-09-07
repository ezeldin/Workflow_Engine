using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstStepId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StepTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    StepTypeId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_StepTypes_StepTypeId",
                        column: x => x.StepTypeId,
                        principalTable: "StepTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    CurrentStepId = table.Column<int>(type: "int", nullable: true),
                    NextStepId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actions_Steps_CurrentStepId",
                        column: x => x.CurrentStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_Steps_NextStepId",
                        column: x => x.NextStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    CurrentStepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessInstances_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessInstances_Steps_CurrentStepId",
                        column: x => x.CurrentStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessInstanceId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionsHistory_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionsHistory_ProcessInstances_ProcessInstanceId",
                        column: x => x.ProcessInstanceId,
                        principalTable: "ProcessInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    ProcessInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_ProcessInstances_ProcessInstanceId",
                        column: x => x.ProcessInstanceId,
                        principalTable: "ProcessInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActionTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "Submit", "Submit" },
                    { 2, "Approve", "Approve" },
                    { 3, "Return", "Return" },
                    { 4, "Reject", "Reject" },
                    { 5, "UnderReview", "Under Review" },
                    { 6, "ApproveForSubmission", "Approve For Submission" },
                    { 7, "RecommendForApproval", "Recommend For Approval" },
                    { 8, "RecommendForRejection", "Recommend for rejection" }
                });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "Id", "FirstStepId", "Name", "Order" },
                values: new object[] { 1, 100, "", (short)0 });

            migrationBuilder.InsertData(
                table: "RequestTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Claim Request" },
                    { 3, "Cancel Bill Request" },
                    { 2, "Modify Bill Request" }
                });

            migrationBuilder.InsertData(
                table: "StepTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 3, "Approved", "Approved" },
                    { 4, "Rejected", "Rejected" },
                    { 5, "Canceled", "Canceled" },
                    { 6, "Assessor", "Assessor" },
                    { 7, "Endorser", "Endorser" },
                    { 8, "Approver", "Approver" },
                    { 9, "Initiator", "Initiator" },
                    { 10, "CommitteeReview", "Committee Review" },
                    { 1, "Draft", "Draft" },
                    { 2, "InProgress", "InProgress" }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "Name", "Order", "ProcessId", "StepTypeId" },
                values: new object[,]
                {
                    { 104, "", (short)0, 1, 3 },
                    { 105, "", (short)0, 1, 4 },
                    { 106, "", (short)0, 1, 5 },
                    { 101, "", (short)0, 1, 6 },
                    { 102, "", (short)0, 1, 7 },
                    { 103, "", (short)0, 1, 8 },
                    { 100, "", (short)0, 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "ActionTypeId", "CurrentStepId", "Name", "NextStepId", "Order" },
                values: new object[,]
                {
                    { 203, 4, 101, "", 105, (short)0 },
                    { 202, 2, 101, "", 102, (short)0 },
                    { 205, 8, 101, "", 102, (short)0 },
                    { 207, 4, 102, "", 105, (short)0 },
                    { 206, 2, 102, "", 103, (short)0 },
                    { 209, 8, 102, "", 103, (short)0 },
                    { 210, 2, 103, "", 104, (short)0 },
                    { 211, 4, 103, "", 105, (short)0 },
                    { 201, 1, 100, "", 101, (short)0 },
                    { 204, 3, 101, "", 100, (short)0 },
                    { 208, 3, 102, "", 100, (short)0 },
                    { 212, 3, 103, "", 100, (short)0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ActionTypeId",
                table: "Actions",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CurrentStepId",
                table: "Actions",
                column: "CurrentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_NextStepId",
                table: "Actions",
                column: "NextStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionsHistory_ActionId",
                table: "ActionsHistory",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionsHistory_ProcessInstanceId",
                table: "ActionsHistory",
                column: "ProcessInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessInstances_CurrentStepId",
                table: "ProcessInstances",
                column: "CurrentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessInstances_ProcessId",
                table: "ProcessInstances",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProcessInstanceId",
                table: "Requests",
                column: "ProcessInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ProcessId",
                table: "Steps",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_StepTypeId",
                table: "Steps",
                column: "StepTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionsHistory");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "ProcessInstances");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "StepTypes");
        }
    }
}
