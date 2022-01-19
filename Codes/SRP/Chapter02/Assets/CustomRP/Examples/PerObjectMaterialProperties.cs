using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 挂到同材质对象上，可以为每个对象设置不同的属性
/// </summary>
[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{
    static int baseColorId = Shader.PropertyToID("_BaseColor");
    static int cutoffId = Shader.PropertyToID("_Cutoff");

    [SerializeField]
    Color baseColor = Color.white;
    [SerializeField, Range(0f, 1f)]
    float cutoff = 0.5f;

    static MaterialPropertyBlock block;
    /// <summary>
    /// Inspector中的任何值被修改时会调用
    /// </summary>
    void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        //设置材质属性
        block.SetColor(baseColorId, baseColor);
        block.SetFloat(cutoffId, cutoff);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
    void Awake()
    {
        OnValidate();
    }
}
