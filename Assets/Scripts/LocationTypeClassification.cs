using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTypeClassification : MonoBehaviour
{
    enum Level
    {
        Bus,
        Car,
        bike,
        Cycle,
        House
    }

    private void Start()
    {
        Level myVar = Level.Bus;
        Debug.Log("Enum = " + myVar);
    }

    static void SelectCar()
    {
        Level myVar = Level.Car;
        Debug.Log("Enum = " + myVar);
    }
}
