namespace CleanArchitectureTemplate.Domain.DomainServiceResult
{
    public interface IDomainServiceResult<TAggregate>
    {
        TAggregate Result { get; set; }
        object Message { get; set; }
        bool Succeed { get; }
    }
}
