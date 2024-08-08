namespace BookStore.BLL.DTO;

public abstract class BookDto
{
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public int Price { get; set; }
}