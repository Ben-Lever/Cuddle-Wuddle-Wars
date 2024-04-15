using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipFollowMouse : MonoBehaviour
{
    private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void LateUpdate()
    {
        Vector2 position;
        // Convert the mouse position to World Space if the Canvas is set to Screen Space - Camera
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera && canvas.worldCamera != null)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, Input.mousePosition, canvas.worldCamera, out Vector3 worldPoint);
            rectTransform.position = worldPoint;
        }
        else // For Screen Space - Overlay and World Space without a camera
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
            rectTransform.localPosition = position;
        }
    }
}
