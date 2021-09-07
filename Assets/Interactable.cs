using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Interactable : MonoBehaviour
{
    public string Name;
	public string Text;
    public GameObject InteractableObject;
    private GameObject Dialog;
    private TextMeshProUGUI TitleBox;
    private TextMeshProUGUI TextBox;
    // Start is called before the first frame update
    void Start()
    {
        Dialog = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        TitleBox = Dialog.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextBox = Dialog.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        Dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectedTextBox(){
        Dialog.SetActive(true);
        TitleBox.text = Name;
        TextBox.text = Text;
    }

    public void OnSelectedCilinderAnimation(){
        var startpos = InteractableObject.transform.position;
        var firstpos = startpos - new Vector3(0, 1, 0);
        var secondpos = firstpos - new Vector3(0, 0, -10);
        var thirdpos = secondpos - new Vector3(0, 3, 0);
        InteractableObject.transform.DOMove(firstpos, 1f);
        InteractableObject.transform.DOMove(secondpos, 0.5f).SetDelay(1f);
        InteractableObject.transform.DOMove(thirdpos, 0.5f).SetDelay(1.5f);
    }
}
