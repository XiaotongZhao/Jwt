namespace Infrastructure.Common.SearchModels.Tools
{
    public abstract class BaseViewModel<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
