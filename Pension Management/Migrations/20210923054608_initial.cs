using Microsoft.EntityFrameworkCore.Migrations;

namespace Pension_Management.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pensioners",
                columns: table => new
                {
                    AadharNo = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PensionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryEarned = table.Column<double>(type: "float", nullable: false),
                    Allowances = table.Column<double>(type: "float", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    BankType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PensionAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensioners", x => x.AadharNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pensioners");
        }
    }
}
