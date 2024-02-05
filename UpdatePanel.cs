using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePanel : MonoBehaviour
{
    public Canvas canvas;
    public GameObject OpenButton;

    public RectTransform Panel;

    public float CanvasWidth;

    public void Start()
    {
        CanvasWidth = canvas.gameObject.GetComponent<RectTransform>().rect.width;
    }

    public void OpenPanel()
    {
        Panel.anchoredPosition = new Vector2(0, 0); 
        OpenButton.SetActive(false);
    }

    public void ClosePanel()
    {
        Panel.anchoredPosition = new Vector2(CanvasWidth, 0);
        OpenButton.SetActive(true);
    }
}
