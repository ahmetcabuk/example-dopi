using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public GameObject joystick;
    public GameObject interactionButton;
    public GameObject imageGO;

    private float fadeOutDuration = 1;

    public void CoroutineExecuter(string coroutineName)
    {
        StartCoroutine(coroutineName, interactionButton);
    }

    public IEnumerator HideUIElement(GameObject objectToHide)
    {
        var objectToHideImage = objectToHide.GetComponent<Image>();

        objectToHideImage.DOFade(0, fadeOutDuration);

        yield return new WaitForSeconds(fadeOutDuration);

        objectToHide.SetActive(false);
    }

    public void ShowUIElement(GameObject objectToHide)
    {
        var objectToHideImage = objectToHide.GetComponent<Image>();

        objectToHide.SetActive(true);
        objectToHideImage.DOFade(1, fadeOutDuration);
    }

    //public void ShowUIElement(GameObject objectToHide)
    //{
    //    objectToHide.SetActive(true);
    //}
}
