using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UserManagementApplication.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    useridx = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    username = table.Column<string>(maxLength: 50, nullable: false),
                    userid = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(maxLength: 256, nullable: false),
                    nickname = table.Column<string>(maxLength: 100, nullable: false),
                    publicyn = table.Column<bool>(nullable: false),
                    modifydate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    registdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.useridx);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
