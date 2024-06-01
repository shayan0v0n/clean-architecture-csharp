using CleanArchitectureTemplate.Domain.Enums;
using System;
using System.ComponentModel;
using System.Globalization;
namespace CleanArchitectureTemplate.Domain.DomainServiceResult
{
    public class 
        DomainServiceRespondResult<TAggregate> : IDomainServiceRespondResult<TAggregate>
    {
        public TAggregate Result { get; set; }
        public ResultStatus Status { get; set; }
        public object Message { get; set; } = "NotExecuted";

        public void SetResult(TAggregate result, ResultStatus status, Messages message)
        {
            Result = result;
            Status = status;
            Message = message.GetDescription();
        }
        public void SetResult(ResultStatus status, Messages message)
        {
            Status = status;
            Message = message.GetDescription();
        }
        public void SetResult(TAggregate result, ResultStatus status, string message)
        {
            Result = result;
            Status = status;
            Message = message;
        }

        public void SetBoolResult(TAggregate result)
        {
            var input = Convert.ToBoolean(result);
            if (input)
            {
                Result = result;
                Status = ResultStatus.Success;
                Message = Messages.Ok.GetDescription();
            }
            else
            {
                Result = result;
                Status = ResultStatus.Error;
                Message = Messages.Error.GetDescription();
            }
        }

    }

    public static class EnumExtension
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string description = null;

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (descriptionAttributes.Length > 0)
                        {
                            description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                        }

                        break;
                    }
                }
            }

            return description;
        }
    }

}
