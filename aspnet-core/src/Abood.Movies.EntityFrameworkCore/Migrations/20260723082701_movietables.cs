using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abood.Movies.Migrations
{
    /// <inheritdoc />
    public partial class movietables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Movies_MovieId",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Rentals",
                newName: "AppRentals");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "AppMovies");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "AppDirectors");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "AppCustomers");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_MovieId",
                table: "AppRentals",
                newName: "IX_AppRentals_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CustomerId",
                table: "AppRentals",
                newName: "IX_AppRentals_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_DirectorId",
                table: "AppMovies",
                newName: "IX_AppMovies_DirectorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AppMovies",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppDirectors",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AppCustomers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AppCustomers",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppCustomers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRentals",
                table: "AppRentals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMovies",
                table: "AppMovies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppDirectors",
                table: "AppDirectors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMovies_AppDirectors_DirectorId",
                table: "AppMovies",
                column: "DirectorId",
                principalTable: "AppDirectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRentals_AppCustomers_CustomerId",
                table: "AppRentals",
                column: "CustomerId",
                principalTable: "AppCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRentals_AppMovies_MovieId",
                table: "AppRentals",
                column: "MovieId",
                principalTable: "AppMovies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMovies_AppDirectors_DirectorId",
                table: "AppMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRentals_AppCustomers_CustomerId",
                table: "AppRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRentals_AppMovies_MovieId",
                table: "AppRentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRentals",
                table: "AppRentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMovies",
                table: "AppMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppDirectors",
                table: "AppDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers");

            migrationBuilder.RenameTable(
                name: "AppRentals",
                newName: "Rentals");

            migrationBuilder.RenameTable(
                name: "AppMovies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "AppDirectors",
                newName: "Directors");

            migrationBuilder.RenameTable(
                name: "AppCustomers",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_AppRentals_MovieId",
                table: "Rentals",
                newName: "IX_Rentals_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_AppRentals_CustomerId",
                table: "Rentals",
                newName: "IX_Rentals_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_AppMovies_DirectorId",
                table: "Movies",
                newName: "IX_Movies_DirectorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Directors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Movies_MovieId",
                table: "Rentals",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
