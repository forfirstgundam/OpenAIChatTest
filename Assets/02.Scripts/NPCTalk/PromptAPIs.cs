using System.Collections.Generic;
using UnityEngine;
using OpenAI.Chat;
using OpenAI.Models;
using OpenAI;

public class PromptAPIs : MonoBehaviour
{
    public static PromptAPIs Instance;
    public OpenAIClient DialogueAPI;
    public OpenAIClient CGAPI;
    public OpenAIClient StoryAPI;

    public List<Message> DialogueHistory = new List<Message>();
    public List<Message> CGHistory = new List<Message>();
    public List<Message> StoryHistory = new List<Message>();

    private void Awake()
    {
        Instance = this;

        DialogueAPI = new OpenAIClient(API_KEY.OPENAI_API_KEY);
        CGAPI = new OpenAIClient(API_KEY.OPENAI_API_KEY);
        StoryAPI = new OpenAIClient(API_KEY.OPENAI_API_KEY);

        // 최초 prompt 넣어두기
    }
}
