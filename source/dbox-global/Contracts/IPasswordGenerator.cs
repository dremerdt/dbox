namespace dbox_global.Contracts
{
    public interface IPasswordGenerator
    {
        string Generate(int length, bool setLastGeneratedPassword);

        int DefaultPasswordLength { get; }

        string LastGeneratedPassword { get; }
    }
}