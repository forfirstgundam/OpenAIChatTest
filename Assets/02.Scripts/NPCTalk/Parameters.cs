using UnityEngine;
using System;

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

[Serializable]
public class EmotionSprite
{
    public Emotion emotion;
    public Sprite sprite;
}

public enum Location
{
    hallway,
    classroom,
    gym,
    rooftop,
    schoolyard,
    school_outdoor,
    councilroom,
}


[Serializable]
public class LocationSprite
{
    public Location location;
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

public class Parameters : MonoBehaviour
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
