using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Vector3 ReadDirectionInput()
    {
        float x = 0;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            x = Input.GetAxis("Horizontal");
        }

        float y = 0;
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            y = Input.GetAxis("Vertical");
        }

        if (x != 0 || y != 0)
        {
            Vector3 direction = new Vector3(x, y,0);
            return direction;
        }

        return Vector3.zero;
    }

    internal bool ReadShoot()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }    
    
    internal bool ReadBoost()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }
}
