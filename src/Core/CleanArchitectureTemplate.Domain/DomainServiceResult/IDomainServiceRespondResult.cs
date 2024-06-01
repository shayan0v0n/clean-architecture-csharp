


using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Domain.DomainServiceResult
{
    public interface IDomainServiceRespondResult<TAggregate>
    {
        TAggregate Result { get; set; }
        ResultStatus Status { get; set; }
        object Message { get; set; }
        void SetResult(TAggregate result, ResultStatus status, Messages message);
        void SetBoolResult(TAggregate result);

    }
}
