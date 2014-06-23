namespace SponsorPortal.TestDataBuilders
{
    public abstract class TestDataBuilder<TEntity>
    {
        public abstract TEntity Build();
    }
}
