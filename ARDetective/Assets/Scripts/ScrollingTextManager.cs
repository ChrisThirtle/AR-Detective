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

    private Vector2 currVelocity;
    void Start()
    {
        stepsize = Screen.height*0.01f * scrollSpeed;
		scroller.verticalScrollbar.value= 0.5f;
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            textTarget.alpha = 0.2f;
            currVelocity = Vector2.zero;
            AudioSource src = GameObject.FindObjectOfType<AudioSource>();

            //win
            if (GlobalVars.Instance.FinalScore > 2.1f)
            {
                textTarget.text = "<b>VICTORY!</b>\n\n Justice has been served this day. Your evidence has placed {4} behind bars and {0} may now rest in peace.";
                src.clip = Resources.Load<AudioClip>("Dee_Yan-Key_-_03_-_Vienna_Jazz");
                src.time = 5f;//adjusted playback positions to suit duration of credits
            }
            else//lose
            {
                textTarget.text = "<b>DEFEAT!</b>\n\n Your conclusions let the real killer, {4}, get away! The murder of {0} goes forever unsolved...";
                src.clip = Resources.Load<AudioClip>("Dee_Yan-Key_-_02_-_Unknown_Lovers_Blues");
                src.time = 2.48f;
            }
            StartCoroutine(playBGMUponLoad(src));
            StartCoroutine("fadeTextIn");
        }
        else
        {
            currVelocity = new Vector2(0f, 10f * scrollSpeed);
        }
        textTarget.text = GlobalVars.nameReplace(textTarget.text);
    }
	void Update()
	{
        scroller.velocity = currVelocity;
		if (scrollImg.localPosition.y > textTarget.bounds.size.y)
		{
			StartCoroutine("EndCutScene");
		}
	}

    IEnumerator playBGMUponLoad(AudioSource src)
    {
        yield return new WaitWhile(() => { return src.clip.loadState == AudioDataLoadState.Loading; });
        src.Play();
        currVelocity = new Vector2(0f, 10f * scrollSpeed);
    }

    IEnumerator fadeTextIn()
    {
        while(textTarget.alpha < 1f)
        {
            textTarget.alpha += 0.1f;
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }

	IEnumerator EndCutScene()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        GameObject CC = GameObject.Find("Cutscene_Canvas");
        

        if(other_canvas != null)
            other_canvas.SetActive(true);     
        
    
        CC.SetActive(false);

        if (SceneManager.GetActiveScene().name == "investigationScene") ARCam.SetActive(true);
        else SceneManager.LoadSceneAsync("Menu");
    }

}