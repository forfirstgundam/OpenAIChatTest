using TMPro;
using UnityEngine;

public class BacklogSlotUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI SpeakerTextUI;
    [SerializeField] private TextMeshProUGUI SpeechTextUI;

    public void Set(string speaker, string message)
    {
        SpeakerTextUI.text = speaker;
        SpeechTextUI.text = message;
    }
}
