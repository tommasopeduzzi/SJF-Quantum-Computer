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
    [Multiline]
	public string Text;
    public GameObject ZoomObject;
    private GameObject Dialog;
    private TextMeshProUGUI TitleBox;
    private TextMeshProUGUI TextBox;
    private RawImage ImageUI;
    public Transform SpawnPoint;
    public Texture Image;
    public bool useImage;
    public bool IsWindow;
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
        if (!IsWindow)
        {
            OnSelectedText();
            Debug.Log("test");
            GameObject newChipLayer = Instantiate(ZoomObject);
            newChipLayer.name = "newChipLayer";
            //newChipLayer.transform.DOMove(new  Vector3(-.891f, 1.93f, 2.109f), 0.5f);
            newChipLayer.transform.DOMove(SpawnPoint.transform.position, 0.5f);
            newChipLayer.transform.DORotate(new Vector3(0, 3, 0), 0.25f).SetLoops(-1, LoopType.Incremental);
            Destroy(newChipLayer.GetComponent<XRSimpleInteractable>());
            Destroy(newChipLayer.GetComponent<QOutline>());
        }
        else
        {
            this.gameObject.SetActive(false);
        }
       
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
