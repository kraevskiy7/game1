using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickRecever : MonoBehaviour, IPointerClickHandler
{
    private bool ready = false;
    private int select = 0;
    private GameObject product;

    public void OnPointerClick(PointerEventData eventData)
    {
        product = eventData.rawPointerPress;
        ready = true;
        select += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (select == 3)
            select = 1;

        if (ready)
        {
            if (select == 1)
            {
                var img = product.GetComponent<Image>();
                img.color = new Color(1, 1, 1, 0.5f);
            }
            else if (select == 2)
            {
                var img = product.GetComponent<Image>();
                img.color = new Color(1, 1, 1, 1);
            }

        }

    }
}
