using System;

namespace DynamoDb.Contracts
{
    public class ReaderInputModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime AddedOn { get; set; }
        public InputType InputType { get; set; }
    }
}
