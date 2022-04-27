using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestApiClient : MonoBehaviour
{
    // singleton for easier access
    public static RestApiClient singleton;

    // api url
    public string serverUrl;

    // Start is called before the first frame update
    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest(serverUrl));

        // A non-existing page.
        StartCoroutine(GetRequest("https://error.html"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Get.html
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
