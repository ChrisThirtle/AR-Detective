using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Generic functions for buttons in one place for ease of reuse.
/// </summary>
public class ButtonFxns: MonoBehaviour {
    [Tooltip("The text component *belonging to the button* that toggles the menu's visibility")]
    public Text showHideBtn;

    private Canvas parent;

    void Start()
    {
        parent = this.transform.parent.gameObject.GetComponent<Canvas>();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private bool isHidden = false;
    private RectTransform rectT;
    public void ShowOrHideMenu(GameObject menuPanel)
    {
        rectT = menuPanel.GetComponent<RectTransform>();
        StopAllCoroutines();
        StartCoroutine("translate", !isHidden);
    }

    IEnumerator translate(bool willHide)
    {
        float translationStep = Screen.width * 0.01f; //s.t. the speed is the same across devices
        if (willHide)
        {
            //right edge of rect, scaled
            while (rectT.localPosition.x + rectT.rect.width > 0)
            {
                rectT.Translate(-translationStep, 0f,0f);
                yield return new WaitForSecondsRealtime(0.05f);
            }
            isHidden = true;
        }
        else
        {   //left edge
            while (rectT.localPosition.x < 0)
            {
                rectT.Translate(translationStep, 0f, 0f);
                yield return new WaitForSecondsRealtime(0.05f);
            }
            isHidden = false;
        }

        showHideBtn.text = isHidden ? "<i>>></i>" : "<i><<</i>";
    }
}
