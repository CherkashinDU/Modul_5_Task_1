using System;

namespace HTTPClient.Models
{
    public class UserCreateResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
