using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactRecord.Infrastructure.Migrations
{
    public partial class CreateContactRecordDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cr");

            migrationBuilder.CreateSequence(
                name: "contact_record_hilo",
                schema: "cr",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "ContactRecord",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    ProfileImagePath = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber_PersonalNumber = table.Column<string>(nullable: true),
                    PhoneNumber_WorkNumber = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_Number = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRecord", x => x.Id);
                    table.UniqueConstraint("AK_ContactRecord_Email", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactRecord",
                schema: "cr");

            migrationBuilder.DropSequence(
                name: "contact_record_hilo",
                schema: "cr");
        }
    }
}
