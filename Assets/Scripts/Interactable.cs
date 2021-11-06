using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

public class Interactable : XRSimpleInteractable
{
    public string Name;
	public string Text;
    public GameObject ZoomObject;
    private GameObject Dialog;
    private TextMeshProUGUI TitleBox;
    private TextMeshProUGUI TextBox;
    private RawImage ImageUI;
    public Texture Image;
    public bool useImage;
    // Start is called before the first frame update
    void Start()
    {
        Dialog = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        TitleBox = Dialog.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextBox = Dialog.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        ImageUI = Dialog.transform.GetChild(2).GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectedText(){
        TitleBox.text = Name;
        TextBox.text = Text;
        ImageUI.texture = Image;
        ImageUI.gameObject.SetActive(useImage);
        if (GameObject.Find("newChipLayer") != null)
            Destroy(GameObject.Find("newChipLayer"));
    }

    public void OnSelectedZoomAnimation(){
        OnSelectedText();
        GameObject newChipLayer = Instantiate(ZoomObject);
        newChipLayer.name = "newChipLayer";
        newChipLayer.transform.DOMove(new  Vector3(-1.33f, 1.1f, -3.6f), 0.5f);
        newChipLayer.transform.DORotate(new Vector3(0, 3, 0), 0.25f).SetLoops(-1, LoopType.Incremental);
        Destroy(newChipLayer.GetComponent<XRSimpleInteractable>());
        Destroy(newChipLayer.GetComponent<QOutline>());
    }

    public void OnSelectedCilinderAnimation(){
        var startpos = transform.position;
        var firstpos = startpos - new Vector3(0, 1, 0);
        var secondpos = firstpos - new Vector3(0, 0, -10);
        var thirdpos = secondpos - new Vector3(0, 3, 0);
        transform.DOMove(firstpos, 1f);
        transform.DOMove(secondpos, 0.5f).SetDelay(1f);
        transform.DOMove(thirdpos, 0.5f).SetDelay(1.5f);
    }
}
