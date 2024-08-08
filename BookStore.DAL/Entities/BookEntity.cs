namespace DAL.Entities;

public class BookEntity
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string Description { get; set; } = String.Empty;
    
    public int Price { get; set; }
}