using Interplayers.Domain.ValueObjects;

namespace Interplayers.Domain.Messages
{
    public interface ISystemMessage
    {
        SystemMessageCode MessageCode { get; }
    }
}