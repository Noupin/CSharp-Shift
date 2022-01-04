namespace Shift.Server.Extensions
{
    public static class Base64StringExtension
    {
        public static void Add(this String a, string b)
        {
            a = $"{a};{b}";
        }
    }
}
