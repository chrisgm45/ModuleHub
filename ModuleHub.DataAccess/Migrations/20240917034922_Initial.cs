using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleHub.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunicationNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommunicationClientId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationNodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    InputsCounter = table.Column<int>(type: "INTEGER", nullable: false),
                    OutputsCounter = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    DataSourceType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModbusNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RecordSource = table.Column<int>(type: "INTEGER", nullable: false),
                    RecordToRead = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModbusNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModbusNodes_CommunicationNodes_Id",
                        column: x => x.Id,
                        principalTable: "CommunicationNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OPCNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddressLabel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPCNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPCNodes_CommunicationNodes_Id",
                        column: x => x.Id,
                        principalTable: "CommunicationNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddressIp = table.Column<string>(type: "TEXT", nullable: false),
                    ConnectionPort = table.Column<string>(type: "TEXT", nullable: false),
                    DataSourceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationClients_DataSources_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "DataSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationClients_DataSourceId",
                table: "CommunicationClients",
                column: "DataSourceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunicationClients");

            migrationBuilder.DropTable(
                name: "ModbusNodes");

            migrationBuilder.DropTable(
                name: "OPCNodes");

            migrationBuilder.DropTable(
                name: "DataSources");

            migrationBuilder.DropTable(
                name: "CommunicationNodes");
        }
    }
}
