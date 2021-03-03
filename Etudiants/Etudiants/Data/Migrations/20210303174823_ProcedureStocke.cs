using Microsoft.EntityFrameworkCore.Migrations;

namespace Etudiants.Data.Migrations
{
    public partial class ProcedureStocke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var request = @"Create Procedure UserList as Begin Select * From AspNetUsers End";
            migrationBuilder.Sql(request);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var request = @"Ceate Procedure UserLis";
            migrationBuilder.Sql(request);
        }
    }
}
