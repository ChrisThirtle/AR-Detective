using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Canvas : MonoBehaviour {

    public GameObject other_canvas;

    public void Chng_Canvas()
    {
        //       GameObject CC = GameObject.Find("Canvas");
        other_canvas.SetActive(true);
 //       CC.SetActive(false);
    }
}
