namespace AirlineManagementSystem.Models;

public class Promotion
{
    public string PromoCode { get; set; }
    public double DiscountPercentage { get; set; }
    public DateTime ValidityStartDate { get; set; }
    public DateTime ValidityEndDate { get; set; }
    public int MaxUses { get; set; }
    public int CurrentUseCount { get; set; }
    public string ApplicableFareClass { get; set; }
    public bool ActiveStatus { get; set; }
}