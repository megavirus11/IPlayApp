using System.Collections.Generic;
using Newtonsoft.Json;

namespace IPlayApp.Models
{
    public class Init
    {
        [JsonProperty(PropertyName = "MenuServer")]
        public string MenuServer { get; set; }

        [JsonProperty(PropertyName = "ModuleServer")]
        public string ModuleServer { get; set; }

        [JsonProperty(PropertyName = "MenuItems")]
        public List<Menu> MenuItems { get; set; }
    }

    public class Menu
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "Color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "Module")]
        public string Module { get; set; }

        [JsonProperty(PropertyName = "Event")]
        public string Event { get; set; }

        [JsonProperty(PropertyName = "ChildItems")]
        public List<Menu> ChildItems { get; set; }

        [JsonProperty(PropertyName = "PlayerList")]
        public List<Player> PlayerList { get; set; }
    }

    public class Player
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Module")]
        public string Module { get; set; }

        [JsonProperty(PropertyName = "Event")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "Identifier")]
        public string Identifier { get; set; }
    }
}