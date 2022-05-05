using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FantasyGear.VR {
    public class AlertDialog : MonoBehaviour
    {
        public Text alertText;

        public virtual void SetText(string text)
        {
            alertText.text = text;
        }
    }
}
