using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MicroLight.MultiView
{
    public enum EyeType
    {
        Left,
        Right,
        Center
    }
    [AddComponentMenu("MicroLight/MultiViewRenderCamera")]
    [ExecuteInEditMode, RequireComponent(typeof(Camera))]
    public class MultiViewRenderCamera : MonoBehaviour
    {
        public EyeType eyeType;
        private Camera _TargetCamera;

        public Camera TargetCamera
        {
            get
            {
                if (_TargetCamera == null)
                {
                    _TargetCamera = GetComponent<Camera>();

                }
                return _TargetCamera;
            }
            set
            {
                _TargetCamera = value;
            }
        }

        MultiViewRenderTrackingSpace _mMultiViewRenderTrackingSpace;
        public MultiViewRenderTrackingSpace mMultiViewRenderTrackingSpace
        {
            get
            {
                if (_mMultiViewRenderTrackingSpace == null)
                {
                    _mMultiViewRenderTrackingSpace = GetComponentInParent<MultiViewRenderTrackingSpace>();
                }
                return _mMultiViewRenderTrackingSpace;
            }

            set
            {
                _mMultiViewRenderTrackingSpace = value;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (MultiViewRenderManager.Instance)
            {
                if (MultiViewRenderManager.Instance.Distortion)
                    if (eyeType == EyeType.Left)
                    {

                        if (mMultiViewRenderTrackingSpace && TargetCamera && mMultiViewRenderTrackingSpace.mMultiViewRenderAeraLeft)
                        {
                            HoloGraphicFrustum frustum = MultiViewRenderUtilies.GetCalculateFrustumMatrix(TargetCamera.nearClipPlane,
                           TargetCamera.farClipPlane,
                           mMultiViewRenderTrackingSpace.mMultiViewRenderAeraLeft.LeftBottomPoint,
                           mMultiViewRenderTrackingSpace.mMultiViewRenderAeraLeft.LeftTopPoint,
                            mMultiViewRenderTrackingSpace.mMultiViewRenderAeraLeft.RightTopPoint,
                            mMultiViewRenderTrackingSpace.mMultiViewRenderAeraLeft.RightBottomPoint,
                           transform.position);
                            if (frustum.GoodData)
                            {
                                TargetCamera.transform.rotation = frustum.Rotation;
                                TargetCamera.projectionMatrix = frustum.ProjectionMatrix;

                            }
                        }
                    }
                    else
                    {
                        if (mMultiViewRenderTrackingSpace && TargetCamera && mMultiViewRenderTrackingSpace.mMultiViewRenderAeraRight)
                        {
                            HoloGraphicFrustum frustum = MultiViewRenderUtilies.GetCalculateFrustumMatrix(TargetCamera.nearClipPlane,
                           TargetCamera.farClipPlane,
                           mMultiViewRenderTrackingSpace.mMultiViewRenderAeraRight.LeftBottomPoint,
                           mMultiViewRenderTrackingSpace.mMultiViewRenderAeraRight.LeftTopPoint,
                            mMultiViewRenderTrackingSpace.mMultiViewRenderAeraRight.RightTopPoint,
                            mMultiViewRenderTrackingSpace.mMultiViewRenderAeraRight.RightBottomPoint,
                           transform.position);
                            if (frustum.GoodData)
                            {
                                TargetCamera.transform.rotation = frustum.Rotation;
                                TargetCamera.projectionMatrix = frustum.ProjectionMatrix;

                            }
                        }
                    }
            }
        }


     public   Material _RenderMat;

        Material RenderMat
        {
            get
            {
                if(_RenderMat==null)
                {
                    _RenderMat = new Material( MultiViewRenderManager.Instance.TrimBoundaryShader);
                }
                return _RenderMat;
            }
            set
            {
                _RenderMat = value;
            }
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (RenderMat&& MultiViewRenderManager.Instance)
            {
                if (eyeType == EyeType.Left)
                {

                    RenderMat.SetInt("IsLeft",1);
                    if (MultiViewRenderManager.Instance.DoTrimBoundaryLeft)
                    {

                        RenderMat.SetFloat("TrimBoundary", MultiViewRenderManager.Instance.TrimBoundaryLeft);
                    }
                    else
                    {
                        RenderMat.SetFloat("TrimBoundary",0);
                    }

                }
                else
                {
                    RenderMat.SetInt("IsLeft", 0);
                    RenderMat.SetFloat("TrimBoundary", MultiViewRenderManager.Instance.TrimBoundaryRight);

                    if (MultiViewRenderManager.Instance.DoTrimBoundaryRight)
                    {

                        RenderMat.SetFloat("TrimBoundary", MultiViewRenderManager.Instance.TrimBoundaryRight);
                    }
                    else
                    {
                        RenderMat.SetFloat("TrimBoundary", 0);
                    }

                }
                RenderMat.SetInt("TrimBoundaryInvert", MultiViewRenderManager.Instance.TrimBoundaryInvert==true?1:0);

                Graphics.Blit(source, destination, RenderMat);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }




    }

}