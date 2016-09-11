using System;
namespace DialogSample
{
    public class Payload
    {
        public Payload(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; }

        public string Message { get; }
    }
}
