using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MicroLight.MultiView
{
    public struct HoloGraphicFrustum
    {

        public Matrix4x4 ProjectionMatrix;
        public Quaternion Rotation;
        public bool GoodData;
    }

    public class MultiViewRenderUtilies 
    {
       




        public static HoloGraphicFrustum GetCalculateFrustumMatrix(float nearClipPlane, float farClipPlane, Vector3 Corner0, Vector3 Corner1, Vector3 Corner2, Vector3 Corner3, Vector3 pe)
        {
            float n = nearClipPlane;
            float f = farClipPlane;

            Vector3 pa = Corner0;
            Vector3 pb = Corner3;
            Vector3 pc = Corner1;

            // Compute an orthonormal basis for the screen. 计算屏幕的正交基。
            Vector3 vr = (pb - pa).normalized;
            Vector3 vu = (pc - pa).normalized;
            Vector3 vn = Vector3.Cross(vu, vr).normalized;

            // Compute the screen corner vectors. 计算屏幕角向量。
            Vector3 va = pa - pe;
            Vector3 vb = pb - pe;
            Vector3 vc = pc - pe;

            // Find the distance from the eye to screen plane.找出眼睛到屏幕平面的距离。
            float d = -Vector3.Dot(va, vn);

            //跑到反面去了
            if (d < 0)
            {

                pa = Corner3;
                pb = Corner0;
                pc = Corner2;

                // Compute an orthonormal basis for the screen. 计算屏幕的正交基。
                vr = (pb - pa).normalized;
                vu = (pc - pa).normalized;
                vn = Vector3.Cross(vu, vr).normalized;

                // Compute the screen corner vectors. 计算屏幕角向量。
                va = pa - pe;
                vb = pb - pe;
                vc = pc - pe;

                // Find the distance from the eye to screen plane.找出眼睛到屏幕平面的距离。
                d = -Vector3.Dot(va, vn);
            }

            // Find the extent of the perpendicular projection. 找出垂直投影的范围
            float nd = n / d * 1.0f;
            float l = Vector3.Dot(vr, va) * nd;
            float r = Vector3.Dot(vr, vb) * nd;
            float b = Vector3.Dot(vu, va) * nd;
            float t = Vector3.Dot(vu, vc) * nd;

            // Load the perpendicular projection. 加载垂直投影。
            Matrix4x4 P = Matrix4x4.Frustum(l, r, b, t, n, f);
            HoloGraphicFrustum mFrustum = new HoloGraphicFrustum();
            mFrustum.ProjectionMatrix = P;

            mFrustum.GoodData = true;
            mFrustum.Rotation = Quaternion.LookRotation(-vn, vu);


            Plane mPlane = new Plane(Corner0, Corner1, Corner2);
            Vector3 pec = mPlane.ClosestPointOnPlane(pe);
            if (pec == pe)
            {
                mFrustum.GoodData = false;
            }



            return mFrustum;
        }


        public static Vector3 GetAeraCorner(Transform aera, int index)
        {
                Vector3 AeraPos = aera.position;
                Vector3 AeraCorner = Vector3.zero;
                Vector3 Up = aera.up;
                Vector3 Forword = aera.forward;
                Vector3 Right = aera.right;
 
                switch (index)
                {
                    case 0:
                        AeraCorner = AeraPos + (-Right * aera.lossyScale.x * 0.5f);
                        AeraCorner = AeraCorner + (-Forword * aera.lossyScale.y * 0.5f);

                        break;
                    case 1:
                        AeraCorner = AeraPos + (-Right * aera.lossyScale.x * 0.5f);
                        AeraCorner = AeraCorner + (Forword * aera.lossyScale.y * 0.5f);

                        break;
                    case 2:
                        AeraCorner = AeraPos + (Right * aera.lossyScale.x * 0.5f);
                        AeraCorner = AeraCorner + (Forword * aera.lossyScale.y * 0.5f);

                        break;
                    case 3:
                        AeraCorner = AeraPos + (Right * aera.lossyScale.x * 0.5f);
                        AeraCorner = AeraCorner + (-Forword * aera.lossyScale.y * 0.5f);

                        break;
                    default:
                        break;
                }
              


                return AeraCorner;
           
        }

    }

}