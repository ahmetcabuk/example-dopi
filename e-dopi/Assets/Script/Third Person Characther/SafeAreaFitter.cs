using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaFitter : MonoBehaviour
{
    private Vector2 _lastSafeAreaSize = Vector2.zero;

    private void Awake()
    {
        UpdateSafeArea();
    }

#if UNITY_EDITOR
    private void FixedUpdate()
    {
        UpdateSafeArea();
    }
#endif 

    private void UpdateSafeArea()
    {
        var safeArea = Screen.safeArea;

        if (_lastSafeAreaSize != safeArea.size)
        {
            var rectTransform = GetComponent<RectTransform>();
            var anchorMin = safeArea.position;
            _lastSafeAreaSize = safeArea.size;
            var anchorMax = anchorMin + _lastSafeAreaSize;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}