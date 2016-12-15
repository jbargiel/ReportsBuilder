namespace Schwab.Report.Data
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T message);
        T Deserialize<T>(string source);
    }
}
