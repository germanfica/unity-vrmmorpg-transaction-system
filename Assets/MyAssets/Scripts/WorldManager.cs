using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject playerPrefab;
    public List<string> characters = new List<string>();

    // Use Awake to initialize variables or states before the application starts
    void Awake()
    {
        // Player 1
        // d586a816-30eb-44a0-b21b-3a3be932ddcb
        // b7810c13-f634-4420-9c0b-3cce0151285a

        
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (string character in characters)
        {
            // Load player characters
            Debug.Log("character id: " + character);
            Debug.Log("player prefab: " + playerPrefab.name);
            StartCoroutine(RestApiClient.singleton.CharacterLoad(character, playerPrefab, (go) => {

                Debug.Log("Name: " + go.name);
            }));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
