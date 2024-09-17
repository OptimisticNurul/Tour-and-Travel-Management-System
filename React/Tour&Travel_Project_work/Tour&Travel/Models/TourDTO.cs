public class TourDTO
{
    public int TourId { get; set; }
    public string TourName { get; set; }
    public string Destination { get; set; }
    public int Duration { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string Description { get; set; }
    public decimal TotalAmount { get; set; }
    public int TourPackageId { get; set; }
    public List<TourImageDTO> TourImages { get; set; }
    public List<TourAvailabilityDTO> TourAvailabilities { get; set; }
}

public class TourImageDTO
{
    public string Picture { get; set; }
}

public class TourAvailabilityDTO
{
    public int AvailableSlots { get; set; }
}
