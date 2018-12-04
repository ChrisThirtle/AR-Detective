using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_ImgAttach : MonoBehaviour {

    private List<Image> clueThumbnails = new List<Image>();
    private int num_clues;
	private GameObject currClue;
	public GameObject item_cnvs;
    public GameObject prefab_cam;
	public Text invDescription;
    public GameObject thumbnailGroup;
    public static Item_ImgAttach instance;
	
    void Start()
    {
        clueThumbnails.AddRange(thumbnailGroup.GetComponentsInChildren<Image>() );
        thumbnailGroup.SetActive(false);
        instance = this;
	}
    public void Add_Img( Clue c)
    {
        thumbnailGroup.SetActive(true);
        clueThumbnails[num_clues].sprite = c.thumbnail;
        clueThumbnails[num_clues].gameObject.SetActive(true);
        c.gameObject.SetActive(false);
        num_clues++;
    }

    public void Pop_Prefab(int index)
    {
        item_cnvs.SetActive(false);
        prefab_cam.SetActive(true);
		if (index < GlobalVars.Instance.CollectedClues.Count)
		{
			currClue = GlobalVars.Instance.CollectedClues[index];
			invDescription.text = GlobalVars.nameReplace(currClue.GetComponent<Clue>().description);
		}
	}

    public void BackToImgCanvas()
    {
		GlobalVars.Instance.inInventory = false;
		prefab_cam.SetActive(false);
        item_cnvs.SetActive(true);
    }


}
