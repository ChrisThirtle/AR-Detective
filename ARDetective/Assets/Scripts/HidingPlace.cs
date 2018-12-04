using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour {

    // Use this for initialization
    private GameObject HPmodel;
    public Clue clueModel;

    void Start () {
        HPmodel = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        //workaround to better debug in Unity Editor
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            OnMouseDown();
        }
	}

    void OnMouseDown()
    {
        // transform hiding place into object item
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.DetachChildren();
        Destroy(this.gameObject);
    }
}
