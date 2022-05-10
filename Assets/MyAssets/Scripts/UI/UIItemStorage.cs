using com.germanfica.vrmmorpg.entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemStorage : MonoBehaviour
{
    public GameObject panel;
    public GameObject containerPrefab;
    public UISlot slotPrefab;
    public GameObject container;

    public UISlot[] views;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateItems() {
        Player player = Player.localPlayer;
        if (player != null)
        {
            // only update the panel if it's active
            if (panel.activeSelf)
            {
                DestroyViews(); // 1st
                RefreshItems(player); //2nd
            }
            
        }
    }

    private void DestroyViews() {
        //destroy old views
        foreach (UISlot view in views)
        {
            Destroy(view.gameObject);
        }
    }

    private void RefreshItems(Player player) {
        // refresh all items
        int i = 0;
        views = new UISlot[player.itemStorage.Count];
        foreach (Item item in player.itemStorage)
        {
            views[i] = Instantiate(slotPrefab, container.transform);
            views[i].item = item;
            i++;
        }
    }
}
