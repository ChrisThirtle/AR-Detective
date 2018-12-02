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
                GameObject hiding_object = (GameObject)Instantiate(clueModel.gameObject, this.transform.position, this.transform.rotation);
                this.transform.localScale = new Vector3(.25f, .25f, .25f);
                this.gameObject.SetActive(false);
            }
        }
    }
}
