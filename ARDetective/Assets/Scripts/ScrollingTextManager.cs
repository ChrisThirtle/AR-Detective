using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Vuforia;
using UnityEngine.SceneManagement;

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
		scroller.verticalScrollbar.value= 0.5f;
        if (SceneManager.GetActiveScene().name == "Credits")
        {  
            AudioSource src = GameObject.FindObjectOfType<AudioSource>();

            //win
            if (GlobalVars.Instance.FinalScore > 2.1f)
            {
                textTarget.text = "\t<b>VICTORY!</b>\n\n Justice has been served this day. Your evidence has placed {4} behind bars and {0} may now rest in peace.";
                src.clip = Resources.Load<AudioClip>("Dee_Yan-Key_-_03_-_Vienna_Jazz.mp3");
            }
            else//lose
            {
                textTarget.text = "\t<b>DEFEAT!</b>\n\n Your conclusions let the real killer, {4}, get away! {0}'s murder case goes forever unsolved...";
                src.clip = Resources.Load<AudioClip>("Dee_Yan-Key_-_02_-_Unknown_Lovers_Blues.mp3");
                
            }
            src.Play();
        }
        textTarget.text = GlobalVars.nameReplace(textTarget.text);
    }
	void Update()
	{
		scroller.velocity = new Vector2(0f, 10f*scrollSpeed);
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

        if (SceneManager.GetActiveScene().name == "investigationScene") ARCam.SetActive(true);
        else SceneManager.LoadSceneAsync("Menu");
    }
    // Use this for initialization

}