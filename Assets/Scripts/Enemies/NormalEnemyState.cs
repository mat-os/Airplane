using DG.Tweening;
using UnityEngine;
    public class NormalEnemyState : IEnemyState
    {
        public void Execute(Airplane airplane, GameObject target)
        {
            Vector3 diference = airplane.transform.position - target.transform.position;
            
            Vector3 targetDir = target.transform.position - airplane.transform.position;
            Vector3 forward = -airplane.transform.forward;
            
            //Расстояние до цели
            //float angleZ = Vector3.SignedAngle(targetDir, airplane.transform.right, Vector3.up);
            
            //X показывает 90 когда ровно напротив таргета
            float angleX = Vector3.SignedAngle( targetDir,  -airplane.transform.right, forward);
            //Y показывает 90 когда ровно напротив таргета
            float angleY = Vector3.SignedAngle(targetDir,   airplane.transform.up, forward);
           // 
           // Debug.Log(angleX + "AngelX");
           // Debug.Log(Mathf.Cos(angleX) + "COS");
           var rotation = Quaternion.LookRotation(targetDir);
           airplane.Rb.transform.rotation = Quaternion.Slerp(airplane.Rb.transform.rotation, rotation, Time.deltaTime * 0.5f);
           
           //airplane.Rb.transform.LookAt(target.transform.position);

            /*if (diference.y > 5.0F && Mathf.Abs(Mathf.Sin(angleY)) > 0.1f)
            {
                Debug.Log("turn down");
                airplane.ControlThrust(Mathf.Abs(Mathf.Sin(angleY)));
            }

            else if (diference.y < -5.0F && Mathf.Abs(Mathf.Sin(angleY)) > 0.1f)
            {
                Debug.Log("turn up");
                airplane.ControlThrust(-Mathf.Abs(Mathf.Sin(angleY)));
            }*/

            /*if (diference.y > 5.0F && angleY < 90)
            {
                airplane.ControlThrust(Mathf.Sin(angleY) * 5);
            }           
            else if (diference.y < -5.0F && angleY > 90)
            {
                airplane.ControlThrust(-Mathf.Abs(Mathf.Sin(angleY)* 5));
            }*/

            /*if (diference.y > 5.0F || diference.y < -5.0F)
            {
                airplane.ControlThrust(-Mathf.Sin(angleY));
                Debug.Log(Mathf.Sin(angleY) + " sin");
            }

            if (diference.x > 5.0F || diference.x < -5.0F)
            {
                //airplane.ControlThrust(Mathf.Sin(angleY));
                airplane.ControlRoll(Mathf.Cos(angleX));
            }*/

            /*if (diference.x < -5.0F || angleX > 5.0F)
            {
                Debug.Log("turn left");
                airplane.ControlRoll(-1);
            }

            else if (diference.x > 5.0F || angleX < -5.0F)
            {
                Debug.Log("turn right");
                airplane.ControlRoll(1);
            }*/
        }
            //airplane.ControlRoll(-1);
                
            //airplane.ControlThrust(-1);

}
