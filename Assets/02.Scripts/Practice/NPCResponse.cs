using Newtonsoft.Json;
using UnityEngine;

public class NPCResponse
{
    [JsonProperty("ReplyMessage")]
    public string ReplyMessage { get; set; }

    [JsonProperty("Appearance")]
    public string Appearance { get; set; }

    [JsonProperty("Emotion")]
    public string Emotion { get; set; }
}
