using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacter : MonoBehaviour
{
    public GameObject itemsButton; // this shows the items button
    public GameObject itemsPanel; // this shows the the items panel

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowItemsButton() {
        if (itemsButton.activeSelf)
        {
            itemsButton.SetActive(false);
            itemsPanel.SetActive(false);
        }
        else {
            itemsButton.SetActive(true);
        }
    }

    public void ShowItemsPanel()
    {
        if (itemsPanel.activeSelf)
        {
            itemsPanel.SetActive(false);
        }
        else
        {
            itemsPanel.SetActive(true);
        }
    }
}
