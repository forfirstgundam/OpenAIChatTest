using UnityEngine;

public class AffectionSystem : MonoBehaviour
{
    public static AffectionSystem Instance;

    private int _affection;

    public int Affection => _affection;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeAffection(int delta)
    {
        _affection += delta;
        Debug.Log($"[Affection] 현재 호감도: {_affection}");

        CheckForTriggers(); // 엔딩 트리거 조건 확인
    }

    private void CheckForTriggers()
    {
        if (_affection <= -100)
        {
            Debug.Log("엔딩1");
        }
        else if (_affection >= 100)
        {
            Debug.Log("엔딩2");
        }
    }
}