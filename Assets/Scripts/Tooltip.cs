using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public Text headerTxt;
    public Text contentTxt;
    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = ""){
        if(string.IsNullOrEmpty(header))
        {
            headerTxt.gameObject.SetActive(false);
        }else{
            headerTxt.gameObject.SetActive(true);
            headerTxt.text = header;
        }

        contentTxt.text = content;

        int headerLength = headerTxt.text.Length;
        int contentLenth = contentTxt.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLenth > characterWrapLimit)? true : false;


    }

    private void Update(){

        if(Application.isEditor){
            int headerLength = headerTxt.text.Length;
            int contentLenth = contentTxt.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLenth > characterWrapLimit)? true : false;

        }
        
        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivoty = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivoty);

        transform.position = position;
    }
}
