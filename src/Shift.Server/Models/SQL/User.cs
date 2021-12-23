namespace Shift.Server.Models
{
    public class User
    {
        [Newtonsoft.Json.JsonProperty("admin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Admin { get; set; }

        [Newtonsoft.Json.JsonProperty("canTrain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? CanTrain { get; set; }

        [Newtonsoft.Json.JsonProperty("feryvUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FeryvUser FeryvUser { get; set; }

        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [Newtonsoft.Json.JsonProperty("shifts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<object> Shifts { get; set; }

        [Newtonsoft.Json.JsonProperty("verified", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Verified { get; set; }

    }


}