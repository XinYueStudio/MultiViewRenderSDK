using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MicroLight.MultiView
{
    [AddComponentMenu("MicroLight/MultiViewRenderCameraRig")]
    [ExecuteInEditMode]
    public class MultiViewRenderCameraRig : MonoBehaviour
    {
        MultiViewRenderTrackingSpace _FrontMultiViewRenderTrackingSpace;

        public MultiViewRenderTrackingSpace FrontMultiViewRenderTrackingSpace
        {
            get
            {
                if (_FrontMultiViewRenderTrackingSpace == null)
                {
                    _FrontMultiViewRenderTrackingSpace = GetComponentInChildren<MultiViewRenderTrackingSpace>();
                }
                return _FrontMultiViewRenderTrackingSpace;
            }

            set
            {
                _FrontMultiViewRenderTrackingSpace = value;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}