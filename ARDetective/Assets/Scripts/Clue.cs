using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This script is to be attached to any GameObject
/// that is considered a "clue" i.e. a 3D model of a murder weapon.
/// </summary>
public class Clue : MonoBehaviour {
    [Range(0f, 1f),Tooltip("The relative value of a clue with respect to the investigation")]
    public float weight;
    [Tooltip("Description format string")]//this shows a message when you hover over the variable in Unity Inspector, can double as comments
    public string description;
    public Sprite thumbnail;

	/*public vars are modifiable in Unity's Inspector window, private vars need to be explicitly marked [SerializeField]
      if you want to change them via inspector. Use [System.Nonserialized] to hide public vars from Inspector.
      The [Range(min,max)] tag limits a value sent in via Unity to the specified range. Just use a property if you need it clamped internally as well.*/

	// Use this for initialization, If a class doesn't need Unity methods like these, we should uninherit from MonoBehaviour to save on overhead.
	void Start() {
        this.gameObject.AddComponent<BoxCollider>();
	}

	// Update is called once per frame
	void Update() { }
	
    void OnMouseDown()
    {
        print("clicked clue:" + name);//debug
        GlobalVars.Instance.CollectedClues.Add(this.gameObject);
        Item_ImgAttach.instance.Add_Img(this);
        this.gameObject.SetActive(false);
    }
}
