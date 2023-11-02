using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academic_Blog.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAccountAwardMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_Award",
                table: "AccountAwardMapping");

            migrationBuilder.DropIndex(
                name: "IX_AccountAwardMapping_LecturerId",
                table: "AccountAwardMapping");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_AccountAwardMapping_LecturerId",
                table: "AccountAwardMapping",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_Award",
                table: "AccountAwardMapping",
                column: "LecturerId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
