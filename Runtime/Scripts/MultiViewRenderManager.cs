using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MicroLight.MultiView
{
    [AddComponentMenu("MicroLight/MultiViewRenderManager")]
    [ExecuteInEditMode]
    public class MultiViewRenderManager : MonoSingletonBase<MultiViewRenderManager>
    {

 
        public MultiViewRenderCameraRig mMultiViewRenderCameraRig;
        [Header("左眼投影采集区域")]
        public MultiViewRenderAera mMultiViewRenderAeraLeft;
        [Header("右眼投影采集区域")]
        public MultiViewRenderAera mMultiViewRenderAeraRight;

        [Header("两眼的距离")]
        public float PDI = 0.064F;
        [Header("是否畸变")]
        public bool Distortion = true;
        //public Vector2 Resolution = new Vector2(3840,2160);
        [Header("裁剪Shader")]
        public Shader TrimBoundaryShader;
        [Header("左眼裁剪值")]
        public float TrimBoundaryLeft = 200;
        [Header("右眼裁剪值")]
        public float TrimBoundaryRight = 200;
        
        [Header("裁剪反向")]
        public bool TrimBoundaryInvert = false;

        [Header("使能左眼裁剪")]
        public bool DoTrimBoundaryLeft = true;
        [Header("使能右眼裁剪")]
        public bool DoTrimBoundaryRight = true;
        [Header("多屏显示")]
        public bool MutilDisplay = true;
        [Header("分辨率长度")]
        public float screenW = 1280;
        [Header("分辨率宽度")]
        public float screenH = 720;


        // Start is called before the first frame update
        void Start()
        {
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(this);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}