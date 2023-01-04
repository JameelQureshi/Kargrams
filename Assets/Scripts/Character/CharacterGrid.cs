using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterGrid : MonoBehaviour
{
    public RectTransform refImage;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 vector2 = refImage.rect.size;
        float SpaceAvl = vector2.x - 200;
        float size = (SpaceAvl / 3) - 68;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(size,size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
