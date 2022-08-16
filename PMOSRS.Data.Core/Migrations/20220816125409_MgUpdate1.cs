using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMOSRS.Data.Core.Migrations
{
    public partial class MgUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Authorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Authorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    RefId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    FileTypeId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    TableTypeId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_IsDeletedEnums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_IsDeletedEnums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_SRSStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_SRSStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_TIDStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_TIDStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_TSs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_TSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_TSs_t_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "t_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_AuthorityRoleMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    AuthoryId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_AuthorityRoleMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_AuthorityRoleMaps_t_Authorities_AuthoryId",
                        column: x => x.AuthoryId,
                        principalTable: "t_Authorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_AuthorityRoleMaps_t_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "t_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_ProjectUserMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ProjectUserMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_ProjectUserMaps_t_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "t_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_ProjectUserMaps_t_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "t_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_RoleUserMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_RoleUserMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_RoleUserMaps_t_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "t_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_RoleUserMaps_t_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "t_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_TIDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TSId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    WorkItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RelScope = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_TIDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_TIDs_t_TIDStates_StateId",
                        column: x => x.StateId,
                        principalTable: "t_TIDStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_TIDs_t_TSs_TSId",
                        column: x => x.TSId,
                        principalTable: "t_TSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_SRSses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TIDId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    WorkItemCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RelScope = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UpdateUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_SRSses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_SRSses_t_SRSStates_StateId",
                        column: x => x.StateId,
                        principalTable: "t_SRSStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_SRSses_t_TIDs_TIDId",
                        column: x => x.TIDId,
                        principalTable: "t_TIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_AuthorityRoleMaps_AuthoryId",
                table: "t_AuthorityRoleMaps",
                column: "AuthoryId");

            migrationBuilder.CreateIndex(
                name: "IX_t_AuthorityRoleMaps_RoleId",
                table: "t_AuthorityRoleMaps",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_t_ProjectUserMaps_ProjectId",
                table: "t_ProjectUserMaps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_t_ProjectUserMaps_UserId",
                table: "t_ProjectUserMaps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_t_RoleUserMaps_RoleId",
                table: "t_RoleUserMaps",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_t_RoleUserMaps_UserId",
                table: "t_RoleUserMaps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_t_SRSses_StateId",
                table: "t_SRSses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_t_SRSses_TIDId",
                table: "t_SRSses",
                column: "TIDId");

            migrationBuilder.CreateIndex(
                name: "IX_t_TIDs_StateId",
                table: "t_TIDs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_t_TIDs_TSId",
                table: "t_TIDs",
                column: "TSId");

            migrationBuilder.CreateIndex(
                name: "IX_t_TSs_ProjectId",
                table: "t_TSs",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_AuthorityRoleMaps");

            migrationBuilder.DropTable(
                name: "t_Files");

            migrationBuilder.DropTable(
                name: "t_IsDeletedEnums");

            migrationBuilder.DropTable(
                name: "t_ProjectUserMaps");

            migrationBuilder.DropTable(
                name: "t_RoleUserMaps");

            migrationBuilder.DropTable(
                name: "t_Settings");

            migrationBuilder.DropTable(
                name: "t_SRSses");

            migrationBuilder.DropTable(
                name: "t_Authorities");

            migrationBuilder.DropTable(
                name: "t_Roles");

            migrationBuilder.DropTable(
                name: "t_Users");

            migrationBuilder.DropTable(
                name: "t_SRSStates");

            migrationBuilder.DropTable(
                name: "t_TIDs");

            migrationBuilder.DropTable(
                name: "t_TIDStates");

            migrationBuilder.DropTable(
                name: "t_TSs");

            migrationBuilder.DropTable(
                name: "t_Projects");
        }
    }
}
