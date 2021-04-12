using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MicroLight.MultiView
{
    [AddComponentMenu("MicroLight/MultiViewRenderTrackingSpace")]
    [ExecuteInEditMode]
    public class MultiViewRenderTrackingSpace : MonoBehaviour
    {

        MultiViewRenderCamera _LeftEye;
        public MultiViewRenderCamera LeftEye
        {
            get
            {
                if (_LeftEye == null)
                {
                    MultiViewRenderCamera[] cameras = GetComponentsInChildren<MultiViewRenderCamera>();

                    for (int i = 0; i < cameras.Length; i++)
                    {
                        if (cameras[i].eyeType == EyeType.Left)
                        {
                            _LeftEye = cameras[i];
                            break;
                        }
                    }
                }

                return _LeftEye;
            }

            set
            {
                _LeftEye = value;
            }
        }

        MultiViewRenderCamera _RightEye;
        public MultiViewRenderCamera RightEye
        {
            get
            {
                if (_RightEye == null)
                {
                    MultiViewRenderCamera[] cameras = GetComponentsInChildren<MultiViewRenderCamera>();

                    for (int i = 0; i < cameras.Length; i++)
                    {
                        if (cameras[i].eyeType == EyeType.Right)
                        {
                            _RightEye = cameras[i];
                            break;
                        }
                    }
                }

                return _RightEye;
            }
            set
            {
                _RightEye = value;
            }
        }
        private MultiViewRenderAera _mMultiViewRenderAeraLeft;

        public MultiViewRenderAera mMultiViewRenderAeraLeft
        {
            get
            {
                if (_mMultiViewRenderAeraLeft == null&& MultiViewRenderManager.Instance)
                {
                    _mMultiViewRenderAeraLeft = MultiViewRenderManager.Instance.mMultiViewRenderAeraLeft;

                  
                }

                return _mMultiViewRenderAeraLeft;
            }
            set
            {
                _mMultiViewRenderAeraLeft = value;
            }
        }
        private MultiViewRenderAera _mMultiViewRenderAeraRight;

        public MultiViewRenderAera mMultiViewRenderAeraRight
        {
            get
            {
                if (_mMultiViewRenderAeraRight == null && MultiViewRenderManager.Instance)
                {
                    _mMultiViewRenderAeraRight = MultiViewRenderManager.Instance.mMultiViewRenderAeraRight;


                }

                return _mMultiViewRenderAeraRight;
            }
            set
            {
                _mMultiViewRenderAeraRight = value;
            }
        }




        // Start is called before the first frame update
        void Start()
        {
            UpdatePDI();
        }

        public void UpdatePDI()
        {
            if (MultiViewRenderManager.Instance)
            {
                if (LeftEye)
                {
                    LeftEye.transform.localPosition = new Vector3(-MultiViewRenderManager.Instance.PDI * 0.5f, 0, 0);
                    LeftEye.TargetCamera.stereoTargetEye = StereoTargetEyeMask.Left;
                    if (MultiViewRenderManager.Instance.MutilDisplay)
                    {
                        
                        LeftEye.TargetCamera.targetDisplay = 0;
                        LeftEye.TargetCamera.rect = new Rect(0,0,0.5f,1);

                    }
                }
                if (RightEye)
                {
                    RightEye.transform.localPosition = new Vector3(MultiViewRenderManager.Instance.PDI * 0.5f, 0, 0);
                    RightEye.TargetCamera.stereoTargetEye = StereoTargetEyeMask.Right;
                    if (MultiViewRenderManager.Instance.MutilDisplay)
                    {
                        RightEye.TargetCamera.targetDisplay = 0;
                        RightEye.TargetCamera.rect = new Rect(0.5f, 0, 0.5f, 1);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}