namespace CleanArch.Domain;

public class Movie
{
    public int MovieId { get; set; }
    public string MovieName { get; set; } = string.Empty;
    public decimal RentalCost { get; set; }
    public int RentalDuration { get; set; }
    
    //Many to many relationships
    public IList<MovieRental> MovieRentals { get; set; }

    
}