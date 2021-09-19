using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickRecever : MonoBehaviour, IPointerClickHandler
{
    private bool select = false;
    private GameObject product;

    public void OnPointerClick(PointerEventData eventData)
    {
        product = eventData.rawPointerPress;
        select = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(select)
        {
            var img = product.GetComponent<Image>();
            img.color = new Color(1, 1, 1, 0.5f);


        }
    }
}
