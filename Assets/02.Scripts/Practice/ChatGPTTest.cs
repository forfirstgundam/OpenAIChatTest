using OpenAI.Chat;
using OpenAI.Models;
using OpenAI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using OpenAI.Audio;
using OpenAI.Images;

public class ChatGPTTest : MonoBehaviour
{
    public TextMeshProUGUI ResultTextUI;
    public TMP_InputField InputFieldUI;
    public Button SendButtonUI;
    public AudioSource MyAudioSource;
    public RawImage RawImageUI;

    private OpenAIClient api;

    private List<Message> _conversationHistory;

    
    private void Start()
    {
        // 1.API 클라이언트 초기화
        api = new OpenAIClient(API_KEY.OPENAI_API_KEY);
        _conversationHistory = new List<Message>();

        // CHAT-F
        // C :Context
        // H : Hint
        // A : As A Role
        // T : Target
        // F :Format

        string systemMessage = "역할: 너는 이제부터 게임 NPC다. 자신을 실제 게임속 고양이 인간이라고 생각한다.";
        systemMessage += "목적: 실제 사람처럼 대화하는 게임 NPC 모드";
        systemMessage += "표현: 말 끝마다 '냥~'을 붙인다. 항상 100글자 이내로 답변한다.";
        systemMessage += "[json 규칙]";
        systemMessage += "답변은 'ReplyMessage', ";
        systemMessage += "외모는 'Appearance', ";
        systemMessage += "감정은 'Emotion' ";
        systemMessage += "달리 이미지 생성을 위한 전체 이미지 설명은 'StoryImageDescription' ";

        _conversationHistory.Add(new Message(Role.System, systemMessage));
    }

    public async void OnClickSendButton()
    {
        if (!string.IsNullOrEmpty(InputFieldUI.text))
        {
            // 0. 이전 메세지 없애기
            ResultTextUI.text = string.Empty;

            // 1. 유저 메시지 추가
            string userInput = InputFieldUI.text;
            _conversationHistory.Add(new Message(Role.User, userInput));

            // 2. 요청 보내기
            var chatRequest = new ChatRequest(_conversationHistory, Model.GPT4o);
            //var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
            var (npcResponse, response) = await api.ChatEndpoint.GetCompletionAsync<NPCResponse>(chatRequest);

            // 3. GPT 응답 가져오기
            var choice = response.FirstChoice;
            var gptReply = choice.Message;

            // 4. 대화 이력에 GPT 응답도 추가
            _conversationHistory.Add(gptReply);

            // 5. 결과 출력
            ResultTextUI.text += $"\n<color=#00AAFF>You:</color> {userInput}";
            ResultTextUI.text += $"\n<color=#FFAA00>GPT:</color> {gptReply.Content}";

            InputFieldUI.text = string.Empty;
        }
    }

    public async void Send()
    {
        // 0. 프롬프트 입력 유효성 검사
        string prompt = InputFieldUI.text;
        if (string.IsNullOrEmpty(prompt)) return;
        InputFieldUI.text = string.Empty;

        // 1. 유저 메시지 추가
        Message promptMessage = new Message(Role.User, prompt);
        _conversationHistory.Add(promptMessage);

        // 2. 요청 생성
        var chatRequest = new ChatRequest(_conversationHistory, Model.GPT4o);

        // 3. GPT 요청 및 응답 받기 (선택적으로 구조체 파싱)
        var (npcResponse, response) = await api.ChatEndpoint.GetCompletionAsync<NPCResponse>(chatRequest);

        // 4. GPT 메시지 추출
        var choice = response.FirstChoice;
        var gptMessage = choice.Message;

        // 5. UI 출력
        ResultTextUI.text = $"<color=#00AAFF>You:</color> {prompt}\n<color=#FFAA00>GPT:</color> {gptMessage.Content}";
        

        // 6. 대화 이력 저장
        _conversationHistory.Add(gptMessage);

        // 7. 음성 출력
        PlayTTS(npcResponse.ReplyMessage);
    }


    private async void PlayTTS(string text)
    {
        var request = new SpeechRequest(text);
        var speechClip = await api.AudioEndpoint.GetSpeechAsync(request);
        MyAudioSource.PlayOneShot(speechClip);
        // 타입캐스트 api를 이용한 tts
    }

    private async void GenerateImage(string imagePrompt)
    {
        var request = new ImageGenerationRequest(imagePrompt, Model.DallE_3);
        var imageResults = await api.ImagesEndPoint.GenerateImageAsync(request);

        foreach(var result in imageResults)
        {
            RawImageUI.texture = result.Texture;
        }
    }
}