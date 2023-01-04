using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public float WaitToBring = 1;
    // Start is called before the first frame update
    public void LoadObject(string type)
    {
        StartCoroutine(Load_Object(type,WaitToBring));
    }
    private IEnumerator Load_Object(string type, float Time)
    {
        yield return new WaitForSeconds(Time);
        GameObject character = (GameObject)Instantiate(Resources.Load("ARItems/" + type));
        character.transform.SetParent(transform);
        character.transform.localPosition = Vector3.zero;
    }
}
 