using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace JD_AnimationEditor
{
    class Camera
    {
        private static Vector3 m_v3CameraPosition;
        private static Vector3 m_v3CameraLook;

        public static void SetCamera(Vector3 point)
        {
            m_v3CameraPosition = point;
        }

        public static void SetLookAt(Vector3 point)
        {
            m_v3CameraLook = point;
        }

        public static void RotateCamera(float yaw, float pitch)
        {
            yaw = (float)(yaw * Math.PI / 180);
            pitch = (float)(pitch * Math.PI / 180);
            m_v3CameraLook = new Vector3((float)((Math.Cos(yaw) * Math.Cos(pitch)) + m_v3CameraPosition.X),
                                        (float)((Math.Sin(yaw) * Math.Cos(pitch)) + m_v3CameraPosition.Y),
                                        (float)(Math.Sin(pitch) + m_v3CameraPosition.Z));
        }
    }
}
