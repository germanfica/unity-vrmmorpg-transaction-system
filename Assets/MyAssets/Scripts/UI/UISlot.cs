using com.germanfica.vrmmorpg.entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public GameObject extraOptions;
    public Text itemText;
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        if(item != null) itemText.text = item.data.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowExtraOptions() {
        if (extraOptions.activeSelf) {
            extraOptions.SetActive(false);
        }
        else {
            extraOptions.SetActive(true);
        }
    }
}
