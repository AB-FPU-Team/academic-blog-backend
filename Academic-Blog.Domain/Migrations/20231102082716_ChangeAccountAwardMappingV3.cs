using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academic_Blog.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAccountAwardMappingV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAwardMapping_Account_AccountId",
                table: "AccountAwardMapping");

            migrationBuilder.DropIndex(
                name: "IX_AccountAwardMapping_AccountId",
                table: "AccountAwardMapping");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountAwardMapping");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "AccountAwardMapping",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountAwardMapping_AccountId",
                table: "AccountAwardMapping",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAwardMapping_Account_AccountId",
                table: "AccountAwardMapping",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
