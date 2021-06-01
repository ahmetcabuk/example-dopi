using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.Instance.ShowUIElement(UIController.Instance.interactionButton);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.Instance.CoroutineExecuter("HideUIElement",UIController.Instance.interactionButton);
        }
    }
}
