using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestApiClient : MonoBehaviour
{
    // singleton for easier access
    public static RestApiClient singleton;
    // public delegate int HttpResponse<T>(T body);
    public delegate void HttpResponse<T>(T body); // HTTP response, including a typed response body (which may be `null` if one was not returned)
    // api url
    public string serverUrl;
    // apis
    private const string AccountApiName = "accounts";
    private const string ItemApiName = "items";
    private const string PlayerCharacterApiName = "player_characters";

    [Serializable]
    class PlayerCharacter
    {
        public string id;
        public string name;
        public int level;
        public int health;
        public int experience;
    }

    [Serializable]
    class PlayerCharacterGroup
    {
        public PlayerCharacter[] group; // The variable name must be: group. Because of the GetAllRequest IEnumerator return value.
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetPlayerCharacter("c22a5113-e2c8-4bc0-94eb-24e6eea5b6d0"));
        StartCoroutine(GetAllPlayerCharacters());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // return a value from a coroutine
    // http://answers.unity.com/answers/1248539/view.html
    IEnumerator GetPlayerCharacter(string id)
    {
        PlayerCharacter playerBody = new PlayerCharacter();

        // https://docs.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings#string-interpolation
        // Request and wait for the desired player character body.
        yield return GetRequest<PlayerCharacter>($"{serverUrl}/{PlayerCharacterApiName}/{id}", (body) =>
        {
            playerBody = body;
        });

        Debug.Log($":\nGetPlayerCharacter with id {id}: {JsonUtility.ToJson(playerBody)}");
    }

    IEnumerator GetAllPlayerCharacters()
    {
        PlayerCharacterGroup playerCharacterGroup = new PlayerCharacterGroup();

        // Request and wait for the desired player character body.
        yield return GetAllRequest<PlayerCharacterGroup>($"{serverUrl}/{PlayerCharacterApiName}", (body) =>
        {
            playerCharacterGroup = body;
        });
        Debug.Log(":\nGetAllPlayerCharacters: " + JsonUtility.ToJson(playerCharacterGroup));
    }

    #region Http methods
    // https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Get.html
    // https://docs.unity3d.com/2020.3/Documentation/Manual/Coroutines.html
    // It�s best to use coroutines if you need to deal with long asynchronous operations, such as waiting for HTTP transfers,
    // asset loads, or file I/O to complete.
    private IEnumerator GetRequest<T>(string uri, HttpResponse<T> callback)
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
                    Debug.LogError($"{pages[page]}: Error: {webRequest.error} \nuri: {uri}");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError($"{pages[page]}: HTTP Error: {webRequest.error} \nuri: {uri}");
                    break;
                case UnityWebRequest.Result.Success:
                    // https://docs.unity3d.com/Manual/JSONSerialization.html
                    Debug.Log("Json: " + webRequest.downloadHandler.text);
                    callback(JsonUtility.FromJson<T>(webRequest.downloadHandler.text)); // response body
                    break;
            }
        }
    }
    private IEnumerator GetAllRequest<T>(string uri, HttpResponse<T> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            Debug.Log("uri: " + uri);

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError($"{pages[page]}: Error: {webRequest.error} \nuri: {uri}");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError($"{pages[page]}: HTTP Error: {webRequest.error} \nuri: {uri}");
                    break;
                case UnityWebRequest.Result.Success:
                    // https://docs.unity3d.com/Manual/JSONSerialization.html
                    //JSON must represent an object type
                    //http://answers.unity.com/answers/1503085/view.html
                    callback(JsonUtility.FromJson<T>($"{{\"group\":{webRequest.downloadHandler.text}}}")); // response body
                    break;
            }
        }
    }
    #endregion
}
