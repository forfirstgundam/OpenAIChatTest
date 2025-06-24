using UnityEngine;

public enum Emotion
{
    Neutral,
    Happy,
    Sad,
    Angry,
    Scared,
    Surprised,
    Disgusted,
    Confused,
    Affectionate,
    Yandere
}

public class DialogueLine
{
    public string Speaker { get; }
    public string Message { get; }

    public DialogueLine(string speaker, string message)
    {
        Speaker = speaker;
        Message = message;
    }
}

public class GirlResponse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
