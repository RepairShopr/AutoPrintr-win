using Newtonsoft.Json;

namespace AutoPrintr
{
    public class CustomerPermission
    {
        public bool read    { get; set; }
        public bool write   { get; set; }
        public bool delete  { get; set; }
    }

    public class TicketPermission
    {
        public bool read    { get; set; }
        public bool write   { get; set; }
        public bool delete  { get; set; }
    }

    public class InvoicePermission
    {
        public bool read    { get; set; }
        public bool write   { get; set; }
        public bool delete  { get; set; }
    }

    public class Payment
    {
        public bool read    { get; set; }
        public bool write   { get; set; }
        public bool delete  { get; set; }
    }

    public class Permissions
    {
        public CustomerPermission   customer    { get; set; }
        public TicketPermission     ticket      { get; set; }
        public InvoicePermission    invoice     { get; set; }
        public Payment              payment     { get; set; }
    }

    public class Location
    {
        public string   name    { get; set; }
        public int      id      { get; set; }
    }

    public class LoginResponse
    {
        [JsonProperty("user_token")]                public string       UserToken               { get; set; }
        [JsonProperty("user_email")]                public string       UserEmail               { get; set; }
        [JsonProperty("user_name")]                 public string       UserName                { get; set; }
        [JsonProperty("user_id")]                   public int          UserId                  { get; set; }
        [JsonProperty("admin")]                     public bool         Admin                   { get; set; }
        [JsonProperty("can_use_app")]               public bool         CanUseApp               { get; set; }
        [JsonProperty("subdomain")]                 public string       Subdomain               { get; set; }
        [JsonProperty("default_location")]          public int          DefaulLocation          { get; set; }
        [JsonProperty("enable_multi_locations")]    public bool         EnableMultiLocations    { get; set; }
        [JsonProperty("locations_allowed")]         public Location[]   LocationsAllowed        { get; set; }
        [JsonProperty("permissions")]               public Permissions  Permissions             { get; set; }
    }

}

