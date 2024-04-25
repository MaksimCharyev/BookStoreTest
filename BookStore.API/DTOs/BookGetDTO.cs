namespace BookStore.API.DTOs
{
    public record BookGetDTO(Guid Id, string Tittle, string Description, decimal? Price);
}
