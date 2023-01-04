using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoSequence : MonoBehaviour
{
    private Material material;
    public Texture[] coinTextures;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        material.mainTexture = coinTextures[Random.Range(0,coinTextures.Length)];
    }

}
