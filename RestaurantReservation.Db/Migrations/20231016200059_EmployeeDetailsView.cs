using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(
		        @"
				CREATE OR ALTER VIEW vw_EmployeeDetails
				AS
				SELECT 
					e.EmployeeId AS EmployeeId,
					e.FirstName + ' ' + e.LastName AS EmployeeName,
					e.Position AS Position,
					r.RestaurantId AS RestaurantId,
					r.[Name] AS RestaurantName,
					r.Address AS RestaurantAddress,
					r.PhoneNumber AS RestaurantPhoneNumber,
					r.OpeningHours AS OpeningHours
				FROM Employees e
				JOIN Restaurants r ON e.RestaurantId = r.RestaurantId
                "
	        );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP VIEW vw_EmployeeDetails");
        }
    }
}
