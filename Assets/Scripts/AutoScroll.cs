using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public Vector2 scrollPosition = Vector2.zero;
    public Scrollbar scroll;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    void OnGUI()
    {
        // An absolute-positioned example: We make a scrollview that has a really large client
        // rect and put it in a small rect on the screen.
        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, 100, 100), scrollPosition, new Rect(0, 0, 1020, 1080));

        // Make four buttons - one in each corner. The coordinate system is defined
        // by the last parameter to BeginScrollView.
        //GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
        //GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
        //GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
        //GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");

        // End the scroll view that we began above.
        GUI.EndScrollView();
    }
    public void data()
    {
        scroll.value = Mathf.Infinity;
    }
    public void SomeEvent()
    {
        // Force the scrollbar to the bottom position.
        scrollPosition.y = Mathf.Infinity;
    }
}
