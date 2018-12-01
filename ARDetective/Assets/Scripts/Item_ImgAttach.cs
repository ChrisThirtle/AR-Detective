using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_ImgAttach : MonoBehaviour {

    private List<Image> clueThumbnails = new List<Image>();
    private int num_clues;
    public GameObject item_cnvs;
    public GameObject prefab_cam;

    void Start()
    {
        clueThumbnails.AddRange(GetComponentsInChildren<Image>() );
    }
    public void Add_Img( Clue c)
    {
        clueThumbnails[num_clues].sprite = c.thumbnail;
        clueThumbnails[num_clues].gameObject.SetActive(true);
    }

    public void Pop_Prefab()
    {
        item_cnvs.SetActive(false);
        prefab_cam.SetActive(true);


    }

    public void BackToImgCanvas()
    {
        prefab_cam.SetActive(false);
        item_cnvs.SetActive(true);
    }

}
