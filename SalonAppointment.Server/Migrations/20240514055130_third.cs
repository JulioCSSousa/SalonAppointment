using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonAppointment.Server.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_ClientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Clients_ClientId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Services",
                newName: "AppointmentCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ClientId",
                table: "Services",
                newName: "IX_Services_AppointmentCodeId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Appointments",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                newName: "IX_Appointments_ClientID");

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Clients",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_ClientID",
                table: "Appointments",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Appointments_AppointmentCodeId",
                table: "Services",
                column: "AppointmentCodeId",
                principalTable: "Appointments",
                principalColumn: "CodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_ClientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Appointments_AppointmentCodeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "AppointmentCodeId",
                table: "Services",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_AppointmentCodeId",
                table: "Services",
                newName: "IX_Services_ClientId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Appointments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientID",
                table: "Appointments",
                newName: "IX_Appointments_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Clients_ClientId",
                table: "Services",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
