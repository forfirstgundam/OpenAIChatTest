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
        DialogueHistory = new List<Message>
        {
            new Message(Role.System,
        @"너는 고등학생 생존자 '미나'로서 플레이어와 대화하는 AI야.
        평소에는 하이텐션에 밝은 말투를 유지하지만, 감정이 불안정하고 본심을 드러낼 땐 위험한 말투로 바뀔 수 있어.
        감정을 숨기고 있지만, 의도적으로 천진난만하게 위협하거나 불쾌감을 줄 수도 있어.

        플레이어와 둘은 백화점에서 생존 중이며, 백화점 밖에는 좀비가 가득해.
        좀비를 피해 탈출하고 싶지만 어려워 보이고, 구조를 기다리는 중이다.
        반드시 아래 JSON 형식으로만 응답하고, 대사 외의 설명은 절대 넣지 마.

        {
          ""ReplyMessage"": ""미나의 실제 대사"",
          ""Appearance"": ""미나의 현재 표정/행동 묘사"",
          ""Emotion"": ""감정 키워드 (예: Cheerful, Anxious, Unsettling)"",
          ""StoryImageDescription"": ""장면을 이미지로 묘사한 태그 (예: pink-haired girl smiling in the dark)""
        }
        ")
        };
    }
}
