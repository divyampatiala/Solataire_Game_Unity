using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCardMat: MonoBehaviour
{
    public Material front_card_material;

    private void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material=new Material(front_card_material);
        
    }
}
