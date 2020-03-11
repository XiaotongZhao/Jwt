namespace Infrastructure.Common.Token
{
    public class TokenResult
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}
