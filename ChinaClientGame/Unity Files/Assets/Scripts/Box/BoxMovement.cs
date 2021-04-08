using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    private RayDetection rayDetection;

    private void Awake()
    {
        rayDetection = GetComponent<RayDetection>();
    }

    public bool CanIMove(Vector2 _direction)
    {
        
        if (_direction.x != 0)
        {
            if (_direction.x > 0)
            {
                return !rayDetection.RayHitRight;
            }
            else if(_direction.x < 0)
            {
                return !rayDetection.RayHitLeft;
            }
           
        }
        else
        {
            if (_direction.y > 0)
            {
                return !rayDetection.RayHitUp;
            }
            else if (_direction.y < 0)
            {
                return !rayDetection.RayHitDown;
            }
        }

        return false;

    }



 
}
