using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class updateModelsPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "Clinics",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "Appointments",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "DoctorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clinics",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "AppointmentID");
        }
    }
}
