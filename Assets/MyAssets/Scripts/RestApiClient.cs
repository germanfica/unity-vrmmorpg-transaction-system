using System;
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

    [Serializable]
    class PlayerCharacter
    {
        public string id;
        public string name;
        public int level;
        public int health;
        public int experience;
    }

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
    // https://docs.unity3d.com/2020.3/Documentation/Manual/Coroutines.html
    // It’s best to use coroutines if you need to deal with long asynchronous operations, such as waiting for HTTP transfers,
    // asset loads, or file I/O to complete.
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
                    // https://docs.unity3d.com/Manual/JSONSerialization.html
                    PlayerCharacter playerCharacter = new PlayerCharacter();
                    playerCharacter = JsonUtility.FromJson<PlayerCharacter>(webRequest.downloadHandler.text);

                    Debug.Log(pages[page] + ":\nReceived (player character object): " + JsonUtility.ToJson(playerCharacter));
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
