namespace CleanArch.Domain;

public class Rental
{
    public int RentalId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime RentalExpiry { get; set; }
    public decimal RentalCost { get; set; }
    
    //Map one to many relationship
    public ICollection<Member> Members { get; set; }
    public IList<MovieRental> MovieRentals { get; set; }
}