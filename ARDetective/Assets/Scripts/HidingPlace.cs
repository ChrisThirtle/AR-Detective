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
		
	}

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {

                hit.collider.enabled = false;
                // transform hiding place into object item
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.DetachChildren();
                Destroy(this.gameObject);
            }
        }
    }
}
