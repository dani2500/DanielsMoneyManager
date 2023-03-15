using System.Text.Json.Serialization;

namespace DanielsMoneyManagerApi.Models
{
    public class User
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }

        public string User_Email { get; set; }

        [JsonIgnore]
        public string User_Password { get; set; }
    }
}
