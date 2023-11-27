using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantTotalRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(
		        @"
				CREATE OR ALTER FUNCTION fn_RestaurantTotalRevenue(@RestaurantId INT)
				RETURNS DECIMAL(18,2) 
				AS
				BEGIN
					DECLARE @Revenue DECIMAL(18,2);
					SELECT @Revenue = SUM(o.TotalAmount)
					FROM Restaurants rst
					LEFT JOIN Reservations rsrv ON rst.RestaurantId = rsrv.RestaurantId
					LEFT JOIN Orders o ON rsrv.ReservationId = o.ReservationId
					WHERE rst.RestaurantId = @RestaurantId;

					RETURN @Revenue;
				END
                "
	        );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP FUNCTION fn_RestaurantTotalRevenue");
        }
    }
}
