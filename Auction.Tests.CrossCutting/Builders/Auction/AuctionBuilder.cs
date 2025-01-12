namespace Auction.Tests.CrossCutting.Builders.Auction
{
    public class AuctionBuilder
    {
        private int _id;
        private bool _active;

        public AuctionBuilder()
        {
            _id = 1;
            _active = true;
        }

        public AuctionBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public AuctionBuilder WithActive(bool active)
        {
            _active = active;
            return this;
        }

        public Domain.Auction Build()
        {
            return new Domain.Auction(_id, _active);
        }
    }
}
