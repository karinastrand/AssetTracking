

namespace AssetTracking;
 class Functions
{
    public static bool expirationDateWarning(DateTime date, int months)
    {
       
        DateTime expirationDate=date.AddMonths(months);
        return (DateTime.Today - expirationDate).TotalDays > 0;

    }


}
