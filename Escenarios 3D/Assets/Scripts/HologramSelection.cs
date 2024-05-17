using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class HologramSelection : MonoBehaviour
{
    [SerializeField] Texture2D[] selectedTexture;
    [SerializeField] Texture2D[] baseTexture;
    ExposedProperty texture = "SelectionTexture";
    ExposedProperty baseTex = "RenderTexture";
    VisualEffect graph;
    int index = 0;
    int max = 1;

    private void Start()
    {
        graph = GetComponent<VisualEffect>();
        graph.SetTexture(texture, selectedTexture[0]);
        graph.SetTexture(baseTex, baseTexture[0]);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I)) 
        {
            if (index < max) index++;
            else index = 0;
            graph.SetTexture(texture, selectedTexture[index]);
            graph.SetTexture(baseTex, baseTexture[index]);
        }
    }
}
