using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private List<EmotionSprite> _emotionSprites;
    [SerializeField] private TextMeshProUGUI _speakerTextUI;
    [SerializeField] private TextMeshProUGUI _speechTextUI;
    [SerializeField] private Image _characterStandingUI;

    [SerializeField] private TMP_InputField _inputFieldTextUI;
    private Dictionary<Emotion, Sprite> _spriteDict;

    private void Awake()
    {
        _spriteDict = new Dictionary<Emotion, Sprite>();
        foreach (var entry in _emotionSprites)
        {
            _spriteDict[entry.emotion] = entry.sprite;
        }
    }

    public async void OnSendButtonClicked()
    {
        var input = _inputFieldTextUI.text;
        if (string.IsNullOrWhiteSpace(input)) return;

        var response = await DialogueManager.Instance.SendDialogue(input);

        _speakerTextUI.text = "미나";
        _speechTextUI.text = response.ReplyMessage;

        if (System.Enum.TryParse(response.Emotion, ignoreCase: true, out Emotion emotion))
        {
            SetEmotion(emotion);
        }
        else
        {
            Debug.LogWarning($"[Emotion] 파싱 실패: {response.Emotion}");
            SetEmotion(Emotion.neutral);
        }

        _inputFieldTextUI.text = "";
    }

    public void SetEmotion(Emotion emotion)
    {
        if (_spriteDict.TryGetValue(emotion, out Sprite sprite))
        {
            _characterStandingUI.sprite = sprite;
        }
        else
        {
            Debug.LogWarning($"[Emotion] Sprite not found for emotion: {emotion}");
        }
    }
}
