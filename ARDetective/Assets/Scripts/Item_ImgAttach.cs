using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_ImgAttach : MonoBehaviour {

    private List<Image> clueThumbnails = new List<Image>();
    private int num_clues;
    
    void Start()
    {
        clueThumbnails.AddRange(GetComponentsInChildren<Image>() );
    }
    public void Add_Img( Clue c)
    {
        clueThumbnails[num_clues].sprite = c.thumbnail;
        clueThumbnails[num_clues].gameObject.SetActive(true);
    }


}
