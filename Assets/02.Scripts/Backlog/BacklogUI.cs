using System.Collections.Generic;
using UnityEngine;

public class BacklogUI : MonoBehaviour
{
    [SerializeField] private GameObject _backlogHolder;
    [SerializeField] private Transform _backlogSlotLocation;
    [SerializeField] private BacklogSlotUI _backlogSlotPrefab;

    private bool _backlogOn = false;
    private List<DialogueLine> _dialogueLines = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // 백로그 키기
            BacklogToggle();
        }
    }

    private void BacklogToggle()
    {
        _backlogOn = !_backlogOn;
        _backlogHolder.SetActive(_backlogOn);

        if (_backlogOn)
        {
            RefreshBacklogUI();
        }
    }

    public void AddToBacklog(string speaker, string message)
    {
        _dialogueLines.Add(new DialogueLine(speaker, message));
    }

    private void RefreshBacklogUI()
    {
        foreach (Transform child in _backlogSlotLocation)
        {
            Destroy(child.gameObject);
        }

        foreach (var line in _dialogueLines)
        {
            var slot = Instantiate(_backlogSlotPrefab, _backlogSlotLocation);
            slot.Set(line.Speaker, line.Message);
        }
    }
}
