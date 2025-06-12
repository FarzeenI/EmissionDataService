using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmissionDataRecordService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmissionDataRecords",
                columns: table => new
                {
                    Material_Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso_Country_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Material_Hierarchy_Model_Node_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material_Hierarchy_Parent_Hierarchy_Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source_Create_Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Logical_Deletion_Indicator = table.Column<bool>(type: "bit", nullable: false),
                    Production_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Transport_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Energy_Use_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Eol_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Cartridges_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Consumables_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Paper_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Total_Rounded_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Total_Lower_Bounds_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Total_Upper_Bounds_KgCO2 = table.Column<double>(type: "float", nullable: false),
                    Source_System_Update_Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Insert_Gmt_Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionDataRecords", x => new { x.Material_Number, x.Iso_Country_Code });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmissionDataRecords");
        }
    }
}
