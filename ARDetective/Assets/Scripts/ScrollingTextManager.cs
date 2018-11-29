using UnityEngine;
using System.Collections;
using TMPro;

public class ScrollingTextManager : MonoBehaviour
{

    public Transform scrollImg;
    public float scrollSpeed = 10;
    public GameObject other_canvas;
    private RectTransform m_textRectTransform;
    private string sourceText;
    private string tempText;

    void Start()
    {
        StartCoroutine("ScrollUpdate");
    }

    private void Update()
    {
       if (scrollImg.localPosition.y >= 40)
        {
           StartCoroutine("EndCutScene");
        }
    }

    IEnumerator ScrollUpdate() {
        while (scrollImg.localPosition.y <= 40)
        {


            scrollImg.position += new Vector3(0f,3f, 0f);



            yield return new WaitForSecondsRealtime(.1f);
        }
    }

    IEnumerator EndCutScene()
    {
        yield return new WaitForSecondsRealtime(5f);
        GameObject CC = GameObject.Find("Cutscene_Canvas");
        

        other_canvas.SetActive(true);     

    
        CC.SetActive(false);


    }
    // Use this for initialization

}