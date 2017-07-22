using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWebService.Migrations
{
    public partial class moveemailfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ContactInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ContactInfo");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAccounts",
                nullable: true);
        }
    }
}
