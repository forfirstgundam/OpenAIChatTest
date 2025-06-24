using System.Collections.Generic;
using UnityEngine;
using OpenAI.Chat;
using OpenAI.Models;
using OpenAI;

public class PromptInit : MonoBehaviour
{
    public static OpenAIClient DialogueAPI;
    public static OpenAIClient CGAPI;
    public static OpenAIClient StoryAPI;
    private List<Message> _conversationHistory;

    private void Awake()
    {
        DialogueAPI = new OpenAIClient(API_KEY.OPENAI_API_KEY);
        CGAPI = new OpenAIClient(API_KEY.   );
        StoryAPI = new OpenAIClient(API_KEY.OPENAI_API_KEY);
        _conversationHistory = new List<Message>();
    }
}
