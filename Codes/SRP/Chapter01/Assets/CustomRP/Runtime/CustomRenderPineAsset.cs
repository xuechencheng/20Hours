using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
[CreateAssetMenu(menuName ="Rendering/CreateCustomRenderPipeline")]
public class CustomRenderPineAsset : RenderPipelineAsset
{
    /// <summary>
    /// Done
    /// </summary>
    /// <returns></returns>
    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRenderPipeline();
    }
}
