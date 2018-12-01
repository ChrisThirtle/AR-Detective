using UnityEngine;
using System.Collections;
using TMPro;

public class ScrollingTextManager : MonoBehaviour
{

    public Transform scrollImg;
    public float scrollSpeed = 10;
    private float stepsize;
    public GameObject other_canvas;
    private string sourceText;
    private string tempText;

    void Start()
    {
        stepsize = Screen.height*0.01f;
        StartCoroutine("ScrollUpdate");
    }

    private Vector3 target = new Vector3(0f,968f,0f);
    IEnumerator ScrollUpdate() {
        while (scrollImg.localPosition.y <= 968f)
        {
            scrollImg.transform.localPosition += new Vector3(0f,stepsize,0f);

            yield return new WaitForSecondsRealtime(.13f);
        }
        StartCoroutine("EndCutScene");
    }

    IEnumerator EndCutScene()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        GameObject CC = GameObject.Find("Cutscene_Canvas");
        

        other_canvas.SetActive(true);     

    
        CC.SetActive(false);


    }
    // Use this for initialization

}