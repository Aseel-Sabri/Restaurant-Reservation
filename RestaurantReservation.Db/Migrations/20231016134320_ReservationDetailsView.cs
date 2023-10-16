using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                CREATE OR ALTER VIEW vw_ReservationDetails
				AS 
				SELECT  
					rsrv.ReservationId AS ReservationId,
					rsrv.TableId AS TableId,
					c.CustomerId AS CustomerId, 
					c.FirstName + ' ' + c.LastName AS CustomerName,
					c.Email AS CustomerEmail,
					c.PhoneNumber AS CustomerPhoneNumber,
					rst.RestaurantId As RestaurantId,
					rst.[Name] AS RestaurantName,
					rst.[Address] AS RestaurantAddress,
					rst.OpeningHours AS OpeningHours,
					rst.PhoneNumber AS RestaurantPhoneNumber
				FROM Reservations rsrv 
				LEFT JOIN Customers c ON  c.CustomerId = rsrv.CustomerId
				LEFT JOIN Restaurants rst ON rsrv.RestaurantId = rst.RestaurantId
                "
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP VIEW vw_ReservationDetails");
        }
    }
}
