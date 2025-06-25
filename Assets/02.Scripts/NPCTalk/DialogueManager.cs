using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenAI.Chat;
using OpenAI.Models;
using OpenAI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public BacklogUI backlogUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public async Task<NPCResponse> SendDialogue(string userInput)
    {
        var messages = PromptAPIs.Instance.DialogueHistory;

        // 1. 유저 입력 메시지 추가
        messages.Add(new Message(Role.User, userInput));

        // 2. 요청 생성
        var chatRequest = new ChatRequest(messages, Model.GPT4o);

        // 3. GPT 요청 및 NPCResponse 파싱
        var (npcResponse, response) = await PromptAPIs.Instance.DialogueAPI.ChatEndpoint
            .GetCompletionAsync<NPCResponse>(chatRequest);

        // 4. GPT 메시지 추출 및 저장
        var gptMessage = response.FirstChoice.Message;
        messages.Add(gptMessage);

        // 4-1. 호감도 반영
        AffectionSystem.Instance.ChangeAffection(npcResponse.AffectionDelta);

        // 5. 백로그 저장
        backlogUI.AddToBacklog("당신", userInput);
        backlogUI.AddToBacklog("미나", npcResponse.ReplyMessage);

        Debug.Log(gptMessage);

        return npcResponse;
    }
}
