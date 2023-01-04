using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoTextureSelecter : MonoBehaviour
{
    public Material[] materials;
    public SkinnedMeshRenderer skinned;

    // Start is called before the first frame update
    public void AssignType(int index)
    {
        skinned.material = materials[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
