using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Vuforia;

public class ScrollingTextManager : MonoBehaviour
{
	
    public Transform scrollImg;
	public TextMeshProUGUI textTarget;
	public ScrollRect scroller;
    public float scrollSpeed = 10;
    private float stepsize;
    public GameObject other_canvas;
    private string sourceText;
    private string tempText;
    public GameObject ARCam;

    void Start()
    {
        stepsize = Screen.height*0.01f * scrollSpeed;
		textTarget.text = GlobalVars.nameReplace(textTarget.text);
		scroller.verticalScrollbar.value= 0.5f;

	}
	void Update()
	{
		scroller.velocity = new Vector2(100f, 100f);
		if (scrollImg.localPosition.y > textTarget.bounds.size.y)
		{
			StartCoroutine("EndCutScene");
		}
	}
	/*
    private Vector3 target = new Vector3(0f,968f,0f);
    IEnumerator ScrollUpdate() {
		
		
		while (scrollImg.localPosition.y <= textTarget.bounds.size.y)
        {
            scrollImg.transform.localPosition += new Vector3(0f,stepsize*10,0f);

            yield return new WaitForSecondsRealtime(.13f);
        }
		StartCoroutine("EndCutScene");
		
	}

	*/
	IEnumerator EndCutScene()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        GameObject CC = GameObject.Find("Cutscene_Canvas");
        

        other_canvas.SetActive(true);     
        
    
        CC.SetActive(false);
        ARCam.SetActive(true);
    }
    // Use this for initialization

}