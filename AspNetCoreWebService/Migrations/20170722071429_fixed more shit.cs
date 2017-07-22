using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreWebService.Migrations
{
    public partial class fixedmoreshit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_UserAccounts_UserAccountId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_UserAddresses_UserAddressId",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<int>(
                name: "UserAddressId",
                table: "ContactInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "ContactInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_UserAccounts_UserAccountId",
                table: "ContactInfo",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_UserAddresses_UserAddressId",
                table: "ContactInfo",
                column: "UserAddressId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_UserAccounts_UserAccountId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_UserAddresses_UserAddressId",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<int>(
                name: "UserAddressId",
                table: "ContactInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserAccountId",
                table: "ContactInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_UserAccounts_UserAccountId",
                table: "ContactInfo",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_UserAddresses_UserAddressId",
                table: "ContactInfo",
                column: "UserAddressId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
