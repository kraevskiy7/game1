using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour

{
    public GameObject cellComtainer;
    public MoveBuyer buyer;
    public GameObject[] allProducts;

    void Start()
    {

        allProducts = buyer.AllProducts();
        for (int i = 0; i < cellComtainer.transform.GetChild(0).childCount; i++)
        {
            Transform cell = cellComtainer.transform.GetChild(0).GetChild(i);
            var img = cell.GetComponent<Image>();

            var product = buyer.AllProducts()[i];
            var productSprite = product.GetComponent<Image>();

            img.sprite = productSprite.sprite;

        }
    }


    void Update()
    {
        if (buyer.selectedcheck)
        {
            cellComtainer.SetActive(true);
        }

        else cellComtainer.SetActive(false);
    }

    public void Close()
    {
        buyer.selectedcheck = false;
    }


}
