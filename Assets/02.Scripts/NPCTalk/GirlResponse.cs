using UnityEngine;

public enum Emotion
{
    neutral,
    smile,
    happy,
    blush,
    ecstasy,
    strong_ecstasy,
    bored,
    suspicious,
    disgust,
    strong_disgust,
    surprised,
    crying,
    

    // 특수 상황
    injured,
    glowing_eyes,
}

[System.Serializable]
public class EmotionSprite
{
    public Emotion emotion;
    public Sprite sprite;
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
