namespace SignalRServer.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string FunctionCall { get; set; }
        public string Status { get; set; }
    }
}
