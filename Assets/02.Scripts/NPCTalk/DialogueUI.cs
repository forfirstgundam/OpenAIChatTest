using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speakerTextUI;
    [SerializeField] private TextMeshProUGUI _speechTextUI;
    [SerializeField] private Image _characterStandingUI;

    [SerializeField] private TMP_InputField _inputFieldTextUI;

    public async void OnSendButtonClicked()
    {
        var input = _inputFieldTextUI.text;
        if (string.IsNullOrWhiteSpace(input)) return;

        var response = await DialogueManager.Instance.SendDialogue(input);

        _speakerTextUI.text = "미나";
        _speechTextUI.text = response.ReplyMessage;

        _inputFieldTextUI.text = "";
    }
}
