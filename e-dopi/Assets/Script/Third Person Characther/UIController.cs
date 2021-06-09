using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIController : Singleton<UIController>
{
    public GameObject joystick;
    public GameObject interactionButton;
    public GameObject imageGO;

    private float fadeOutDuration = 1;
    private Image image;

    public void CoroutineExecuter(string coroutineName, GameObject uIElement)
    {
        StartCoroutine(coroutineName, uIElement);
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
        Image objectToHideImage = objectToHide.GetComponent<Image>();

        objectToHide.SetActive(true);
        objectToHideImage.DOFade(1, fadeOutDuration);
    }
}
