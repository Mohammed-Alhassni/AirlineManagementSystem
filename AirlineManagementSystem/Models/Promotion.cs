namespace AirlineManagementSystem.Models;

public class Promotion
{
    public string Promo_Code { get; set; }
    public double Discount_Percentage { get; set; }
    public DateTime Validity_Start_Date { get; set; }
    public DateTime Validity_End_Date { get; set; }
    public int Max_Uses { get; set; }
    public int Current_Use_Count { get; set; }
    public string Applicable_Fare_Class { get; set; }
    public bool Active_Status { get; set; }
}