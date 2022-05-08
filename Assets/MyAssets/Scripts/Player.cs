using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player localPlayer;

    [Header("Id")]
    [SerializeField] string _id = "";
    public string id
    {
        get { return _id; }
        set { _id = value; }
    }

    [Header("Text")]
    public Text nameText;

    [Header("Level")]
    [SerializeField] long _level = 0;
    public long level
    {
        get { return _level; }
        set { _level = value; }
    }

    [Header("Health")]
    [SerializeField] long _health = 0;
    public long health
    {
        get { return _health; }
        set { _health = value; }
    }

    [Header("Experience")]
    [SerializeField] long _experience = 0;
    public long experience
    {
        get { return _experience; }
        set { _experience = value; }
    }

    // some meta info
    [HideInInspector] public string accountId = "";

    // Use Awake to initialize variables or states before the application starts
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTexts();
    }

    public void OnStartLocalPlayer()
    {
        // set singleton
        localPlayer = this;
    }

    protected void UpdateTexts()
    {
        if (nameText != null) nameText.text = name;
    }
}