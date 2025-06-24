using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebText : MonoBehaviour
{
    public Text MyTextUI;
    private void Start()
    {
        StartCoroutine(GetText());
    }

    private IEnumerator GetText()
    {
        // GET : 주소?키1=값1&키2=값2...
        string url = "https://openapi.naver.com/v1/search/news.json?query=디지몬&display=30";
        UnityWebRequest www = UnityWebRequest.Get(url);

        www.SetRequestHeader("X-Naver-Client-Id", "diJPemRaKQ3RNQTchsO8");
        www.SetRequestHeader("X-Naver-Client-Secret", "JzIXbB0Mst");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            MyTextUI.text = www.downloadHandler.text;
        }
    }
}
