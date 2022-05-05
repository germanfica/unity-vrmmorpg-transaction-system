using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    public GameObject extraOptions;

    // Start is called before the first frame update
    void Start()
    {
        
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
