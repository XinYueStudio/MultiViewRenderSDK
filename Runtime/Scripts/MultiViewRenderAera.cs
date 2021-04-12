using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MicroLight.MultiView
{

    [AddComponentMenu("MicroLight/MultiViewRenderAera")]
    [ExecuteInEditMode]
    public class MultiViewRenderAera : MonoBehaviour
    {
        public EyeType eyeType;

        [HideInInspector]
        public Vector3 LeftBottomPoint;
        [HideInInspector]
        public Vector3 RightBottomPoint;
        [HideInInspector]
        public Vector3 LeftTopPoint;
        [HideInInspector]
        public Vector3 RightTopPoint;
       
  

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            LeftBottomPoint = MultiViewRenderUtilies.GetAeraCorner(transform, 3);
            RightBottomPoint = MultiViewRenderUtilies.GetAeraCorner(transform, 0);
            RightTopPoint = MultiViewRenderUtilies.GetAeraCorner(transform, 1);
            LeftTopPoint = MultiViewRenderUtilies.GetAeraCorner(transform,2);

        }

      

#if UNITY_EDITOR

        public class MultiViewRenderAeraGizmoDrawer
        {

            public static bool UpdateGLGrid = false;

            [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
            static void DrawGizmoForGrid(MultiViewRenderAera manager, GizmoType gizmoType)
            {
                MultiViewRenderAera mMultiViewRenderAera = manager;               
                Handles.color = Color.green;
                Handles.DrawLine(mMultiViewRenderAera.LeftBottomPoint, mMultiViewRenderAera.LeftTopPoint);
                Handles.DrawLine(mMultiViewRenderAera.RightBottomPoint, mMultiViewRenderAera.RightTopPoint);
                Handles.DrawLine(mMultiViewRenderAera.RightBottomPoint, mMultiViewRenderAera.LeftBottomPoint);
                Handles.DrawLine(mMultiViewRenderAera.LeftTopPoint, mMultiViewRenderAera.RightTopPoint);


            }
        }
#endif
    }






}


