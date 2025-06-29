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

    [JsonProperty("Location")]
    public string Location { get; set; }

    [JsonProperty("AffectionDelta")]
    public int AffectionDelta { get; set; }
}
