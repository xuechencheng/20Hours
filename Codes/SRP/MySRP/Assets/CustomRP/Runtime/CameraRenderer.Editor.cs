using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
/// <summary>
/// 相机渲染管理类
/// </summary>
public partial class CameraRenderer
{
    partial void DrawUnsupportedShaders();
    partial void DrawGizmos();
    partial void PrepareForSceneWindow();
    partial void PrepareBuffer();
#if UNITY_EDITOR
    //SRP不支持的着色器标签类型
    static ShaderTagId[] legacyShaderTagIds = {new ShaderTagId("Always"),new ShaderTagId("ForwardBase"),new ShaderTagId("PrepassBase"),
        new ShaderTagId("Vertex"),new ShaderTagId("VertexLMRGBM"),new ShaderTagId("VertexLM")};
    //绘制成使用错误材质的粉红颜色
    static Material errorMaterial;
    string SampleName { get; set; }
    /// <summary>
    /// 绘制SRP不支持的内置shader类型
    /// </summary>
    partial void DrawUnsupportedShaders()
    {
        if (errorMaterial == null){
            errorMaterial = new Material(Shader.Find("Hidden/InternalErrorShader"));
        }
        var drawingSettings = new DrawingSettings(legacyShaderTagIds[0], new SortingSettings(camera)){overrideMaterial = errorMaterial };
        for (int i = 1; i < legacyShaderTagIds.Length; i++){
            drawingSettings.SetShaderPassName(i, legacyShaderTagIds[i]);
        }
        //使用默认设置即可，反正画出来的都是错误的
        var filteringSettings = FilteringSettings.defaultValue;
        context.DrawRenderers(cullingResults, ref drawingSettings, ref filteringSettings);
    }
    partial void DrawGizmos()
    {
        if (Handles.ShouldRenderGizmos()){
            context.DrawGizmos(camera, GizmoSubset.PreImageEffects);
            context.DrawGizmos(camera, GizmoSubset.PostImageEffects);
        }
    }
    partial void PrepareForSceneWindow()
    {
        if (camera.cameraType == CameraType.SceneView){
            ScriptableRenderContext.EmitWorldGeometryForSceneView(camera);
        }
    }
    /// <summary>
    /// 设置buffer缓冲区的名字
    /// </summary>
    partial void PrepareBuffer(){
        //设置一下只有在编辑器模式下才分配内存
        Profiler.BeginSample("Editor Only");
        buffer.name = SampleName = camera.name;
        Profiler.EndSample();
    }
#else
	const string SampleName = bufferName;
#endif
}
