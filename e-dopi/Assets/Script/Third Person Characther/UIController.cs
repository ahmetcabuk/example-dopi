using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class UIController : Singleton<UIController>
{
    public GameObject joystick;
    public GameObject interactionButton;
    private List<GameObject> _uIElementsList = new List<GameObject>();
    private GameObject _safeArea;
    
    private float fadeOutDuration = 1;

    private void Awake()
    {
        if (transform.GetChild(0).gameObject.name == "SafeArea")
        {
            _safeArea = transform.GetChild(0).gameObject;
        }
        else
        {
            Debug.LogError("SafeArea not found - SafeArea have to be first child of Canvas and SafeArea GameObject name have to be 'SafeArea'.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OffUI();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnUI();
        }
    }

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

    [Button]
    public void OnUI()
    {
        foreach (var item in _uIElementsList)
        {
            item.SetActive(true);
        }

        _uIElementsList.Clear();
    }

    [Button]
    public void OffUI()
    {
        JoystickMovement.Instance.RestartInput();

        for (int i = 0; i < _safeArea.transform.childCount; i++)
        {
            if (_safeArea.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                _uIElementsList.Add(_safeArea.transform.GetChild(i).gameObject);
            }
        }

        foreach (var item in _uIElementsList)
        {
            item.SetActive(false);
        }
    }
}
