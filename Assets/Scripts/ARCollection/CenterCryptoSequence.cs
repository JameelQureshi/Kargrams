using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCryptoSequence : MonoBehaviour
{
    private Material material;
    public Texture[] coinTextures;

    // Start is called before the first frame update
    public void AssignTexture(string itemType)
    {

        material = GetComponent<MeshRenderer>().material;

        foreach (Texture texture in coinTextures)
        {
            if (texture.name.Equals(itemType))
            {
                material.mainTexture = texture;
            }
        }
    }
}
