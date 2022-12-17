﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Types_TypeId",
                table: "Notes");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Types_TypeId",
                table: "Notes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Types_TypeId",
                table: "Notes");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Types_TypeId",
                table: "Notes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }
    }
}
