using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class textController : MonoBehaviour, IPointerDownHandler
{
    public GameObject uiText;
    public List<GameObject> textList;

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (GameObject text in textList)
        {
            text.SetActive(false);
        }
        uiText.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject text in textList)
        {
            text.SetActive(false);
        }
        uiText.SetActive(false);
    }

    public void tutoP2()
    {
        Debug.Log("Connard");
        uiText.SetActive(true);
        textList[0].SetActive(true);
    }
}
