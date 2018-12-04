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
    public static Item_ImgAttach instance;
	
    void Awake()
    {
        clueThumbnails.AddRange(GetComponentsInChildren<Image>() );
        instance = this;
	}
    public void Add_Img( Clue c)
    {
        clueThumbnails[num_clues].sprite = c.thumbnail;
        clueThumbnails[num_clues].gameObject.SetActive(true);
        currClue.SetActive(false);
        num_clues++;
    }

    public void Pop_Prefab(int index)
    {
		GlobalVars.Instance.inInventory = true;
        item_cnvs.SetActive(false);
        prefab_cam.SetActive(true);
		foreach (GameObject clue in GlobalVars.Instance.CollectedClues)
		{
			clue.transform.SetParent(prefab_cam.transform);
			clue.transform.localPosition = new Vector3(0, 0, 100);
		}
		if (index < GlobalVars.Instance.CollectedClues.Count)
		{
			currClue = GlobalVars.Instance.CollectedClues[index];
			currClue.SetActive(true);
			invDescription.text = GlobalVars.nameReplace(currClue.GetComponent<Clue>().description);
		}
	}

    public void BackToImgCanvas()
    {
		GlobalVars.Instance.inInventory = false;
		prefab_cam.SetActive(false);
        item_cnvs.SetActive(true);
		currClue.SetActive(false);
    }


}
