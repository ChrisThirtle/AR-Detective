using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Canvas : MonoBehaviour {
    
    public GameObject other_canvas;

    public void Chng_Canvas()
    {
        //       GameObject CC = GameObject.Find("Canvas");
        //       CC.SetActive(false);
        other_canvas.SetActive(!other_canvas.activeSelf);
    }
}
