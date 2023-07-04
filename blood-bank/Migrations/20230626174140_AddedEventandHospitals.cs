using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventandHospitals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDatas",
                columns: table => new
                {
                    DonorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDatas", x => x.DonorID);
                });

            migrationBuilder.CreateTable(
                name: "EventDescs",
                columns: table => new
                {
                    EventName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BloodCollected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDescs", x => x.EventName);
                });

            migrationBuilder.CreateTable(
                name: "HospitalDatas",
                columns: table => new
                {
                    HospitalName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Opositive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Onegative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apositive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anegative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bpositive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bnegative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ABpositive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ABnegative = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalDatas", x => x.HospitalName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDatas");

            migrationBuilder.DropTable(
                name: "EventDescs");

            migrationBuilder.DropTable(
                name: "HospitalDatas");
        }
    }
}
