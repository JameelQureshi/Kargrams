using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingAutoScroll : MonoBehaviour
{
    public Scrollbar scroll;
    private float temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void func()
    {
        temp = (scroll.value)/10;
        Debug.Log("value " + scroll.value);
        Debug.Log("value " + scroll.value/10);
        //for (int i = 0; i < 10; i++)
        //{
        //    StartCoroutine(PushToBottom(temp));
        //}
        StartCoroutine(PushToBottom());
    }
    public IEnumerator PushToBottom()
    {
        if (scroll.value > 0)
        {
            
            yield return new WaitForSeconds(0.01f);
            Debug.Log("value " + scroll.value);
            scroll.value = scroll.value - temp;
            StartCoroutine(PushToBottom());
        }
    }
}
