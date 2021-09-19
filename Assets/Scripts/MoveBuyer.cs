using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBuyer : MonoBehaviour
{
    public float speed = 1f;
    private Animator anim;
    public Vector3  direction = new Vector3(0.03f, 0.36f, -1f);
    public GameObject Union;
    public GameObject buyer;
    public GameObject products;
    private List<GameObject> selectedProducts = new List<GameObject>();

    public bool selectedcheck = false;
    private bool pointcheck = true;

     
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);


        if (transform.position == direction)
        {
            anim.SetBool("isRunning", false);
            UnionCreate();
        }
    }

    void UnionCreate()
    {
        if (pointcheck)
        {
            AllProducts();

            List<int> randomList = new List<int>();
            for (; randomList.Count < 3;)
            {
                var random = Random.Range(0, AllProducts().Length);
                if (!randomList.Contains(random))
                {
                    randomList.Add(random);
                    selectedProducts.Add(AllProducts()[random]);
                }
            }
            randomList.Clear();

            StartCoroutine(SelectedBuyer());
        }
        pointcheck = false;
    }

     IEnumerator SelectedBuyer()
    {
        var union = Instantiate(Union, buyer.transform).gameObject;

        for (int i = 0, j = 0; i <= selectedProducts.Count & j < union.transform.childCount; i++, j++)
        {
            var item = Instantiate(selectedProducts[i]);
            var unionChild = union.transform.GetChild(j);
            item.transform.position = unionChild.transform.position;
            Destroy(item, 5);
        }
        Destroy(union, 5);
        yield return new WaitForSeconds(5);
        selectedcheck = true;
    }

    public GameObject[] AllProducts()
    {
        GameObject[] allproducts = new GameObject[products.transform.childCount];
        int i = 0;
        foreach (Transform child in products.transform)
        {
            allproducts[i] = child.gameObject;
            i += 1;
        }
        return allproducts;
    }

}
