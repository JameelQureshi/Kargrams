using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBoxSelector : MonoBehaviour
{
    public GameObject[] boxes;


    // Start is called before the first frame update
    void Start()
    {
        GameObject box = Instantiate(boxes[Random.Range(0,boxes.Length)]);
        box.transform.SetParent(transform);
        box.transform.localPosition = Vector3.zero;
    }

}
