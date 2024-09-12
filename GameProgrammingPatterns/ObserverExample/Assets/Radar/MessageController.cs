using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageController : MonoBehaviour
{

    TextMeshProUGUI message;
    void Start()
    {
        message = this.GetComponent<TextMeshProUGUI>();
        message.enabled = false;
    }

    public void DisplayMessage(GameObject go) {
        message.text = "You picked up an item named "+ go.name;
        message.enabled = true;
        Invoke(nameof(TurnOffAfterSeconds), 2f);
    }

    void TurnOffAfterSeconds() { }
}
