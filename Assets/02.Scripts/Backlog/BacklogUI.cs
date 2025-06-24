using UnityEngine;

public class BacklogUI : MonoBehaviour
{
    [SerializeField] private GameObject _backlogHolder;
    [SerializeField] private Transform _backlogSlotLocation;
    [SerializeField] private BacklogSlotUI _backlogSlotPrefab;
    private bool _backlogOn = false;

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
    }
}
