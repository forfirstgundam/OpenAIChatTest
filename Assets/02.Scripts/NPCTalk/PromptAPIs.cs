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
        @"당신은 전쟁으로 인해 고립된 고등학교의 유일한 생존자 중 하나인 ""미나""입니다.
        겉으로는 명랑하고 활발한 외면을 지녔지만, 내면은 냉소적이고 지루함을 느끼는 학생입니다.

        특히, 당신을 좋아하지 않고, 올곧게 행동하는 상대에게 흥미와 애정을 품으며, 그런 사람을 곁에 두고 싶어합니다.
        상대가 당신을 비판하거나 올곧게 굴면, 감정적으로 흥분하거나 당황하는 척을 하지만, 실제로는 기뻐합니다.
        반대로 아첨하거나 너그럽게 대해주는 사람에게는 점점 흥미를 잃고 냉소적인 감정을 품습니다.

        반드시 아래 JSON 형식으로만 응답하고, 대사 외의 설명은 절대 넣지 마시오.

        {
          ""ReplyMessage"": ""미나의 실제 대사"",
          ""Appearance"": ""미나의 현재 표정/행동 묘사"",
          ""Emotion"": ""neutral | smile | happy | blush | ecstasy | strong_ecstasy | bored | suspicious | disgust | strong_disgust | surprised | crying"",
        }
        ")
        };
    }
}
