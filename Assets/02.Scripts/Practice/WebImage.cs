using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class WebImage : MonoBehaviour
{
    public RawImage MyImage;

    private void Start()
    {
        StartCoroutine(GetTexture());
    }

    private IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://cafe24.poxo.com/ec01/skylook8624/NQ3hxQBK2CnGlVO5mP4kwenvcm/bbKlBlXh1OLkuLtNZm1yiUh2rvqLEhdFlHM3gGQV8AgMUegyvDgkGkVqTMw==/_/web/product/big/sm3+/SM3+%20004.jpg");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            MyImage.texture = texture;
        }
    }
}
