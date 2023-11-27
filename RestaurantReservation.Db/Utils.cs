namespace RestaurantReservation.Db;

public static class Utils
{
    public static bool HasAnyNullOrEmptyFields(this object myObject)
    {
        foreach (var propertyInfo in myObject.GetType().GetProperties())
        {
            if (propertyInfo.GetValue(myObject) is null)
            {
                return true;
            }

            if (propertyInfo.PropertyType == typeof(string))
            {
                var value = (string)propertyInfo.GetValue(myObject);
                if (string.IsNullOrEmpty(value))
                {
                    return true;
                }
            }
        }

        return false;
    }
}