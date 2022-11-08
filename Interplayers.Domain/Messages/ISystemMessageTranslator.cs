namespace Interplayers.Domain.Messages
{
    public interface ISystemMessageTranslator<T>
    {
        string GetDescription(T messageData);
    }
}