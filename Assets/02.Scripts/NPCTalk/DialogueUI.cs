using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Extensions;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private List<EmotionSprite> _emotionSprites;
    [SerializeField] private List<LocationSprite> _locationSprites;
    [SerializeField] private TextMeshProUGUI _speakerTextUI;
    [SerializeField] private TextMeshProUGUI _speechTextUI;
    [SerializeField] private Image _characterStandingUI;
    [SerializeField] private Image _backgroundUI;

    [SerializeField] private TMP_InputField _inputFieldTextUI;
    private Dictionary<Emotion, Sprite> _spriteDict;
    private Dictionary<Location, Sprite> _locationDict;

    private void Awake()
    {
        _spriteDict = new Dictionary<Emotion, Sprite>();
        foreach (var entry in _emotionSprites)
        {
            _spriteDict[entry.emotion] = entry.sprite;
        }
        _locationDict = new Dictionary<Location, Sprite>();
        foreach (var entry in _locationSprites)
        {
            _locationDict[entry.location] = entry.sprite;
        }
    }

    public async void OnSendButtonClicked()
    {
        var input = _inputFieldTextUI.text;
        if (string.IsNullOrWhiteSpace(input)) return;

        SetInputLock(true);

        var response = await DialogueManager.Instance.SendDialogue(input);

        _speakerTextUI.text = "미나";
        _speechTextUI.text = response.ReplyMessage;

        // 스탠딩cg 수정
        if (System.Enum.TryParse(response.Emotion, ignoreCase: true, out Emotion emotion))
        {
            SetEmotion(emotion);
        }
        else
        {
            Debug.LogWarning($"[Emotion] 파싱 실패: {response.Emotion}");
            SetEmotion(Emotion.neutral);
        }

        // 배경cg 수정
        if (System.Enum.TryParse(response.Location, ignoreCase: true, out Location location))
        {
            SetLocation(location);
        }
        else
        {
            Debug.LogWarning($"[Location] 파싱 실패: {response.Location}");
            SetLocation(Location.hallway);
        }

        SetInputLock(false);

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

    public void SetLocation(Location location)
    {
        if (_locationDict.TryGetValue(location, out Sprite sprite))
        {
            _backgroundUI.sprite = sprite;
        }
        else
        {
            Debug.LogWarning($"[Location] Sprite not found for emotion: {location}");
        }
    }

    private void SetInputLock(bool isLocked)
    {
        _inputFieldTextUI.SetActive(!isLocked);
    }

}
