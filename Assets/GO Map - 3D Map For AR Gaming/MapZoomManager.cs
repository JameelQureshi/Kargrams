using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZoomManager : MonoBehaviour
{
    public GoMap.GOMap map;

    public void ZoomPlus()
    {
        map.zoomLevel++;
    }
}
