namespace Interplayers.Domain.ValueObjects
{
    public class SystemMessageCode
    {
        public readonly string Code;

        public SystemMessageCode(string code)
        {
            this.Code = code;
        }

        public override int GetHashCode() => Code.GetHashCode();

        public override bool Equals(object obj)
        {
            var code = obj as SystemMessageCode;
            if(code != null) return Code.Equals(code.Code);
            return false;
        }
    }
}