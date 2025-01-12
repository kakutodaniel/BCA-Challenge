namespace Auction.Application.Error
{
    public record ErrorResponse(Dictionary<string, List<string>> Errors);
}
