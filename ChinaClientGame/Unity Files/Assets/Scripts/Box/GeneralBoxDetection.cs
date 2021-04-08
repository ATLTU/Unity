using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBoxDetection : MonoBehaviour
{
    public string BoxType;
    public WordType BoxWord;

    private RayDetection rayDetection;

    GameObject LeftGameObject;
    GameObject RightGameObject;

    private bool twoBlocks;
    public bool TwoBlocks { get => twoBlocks;}
    private GameObject thirdBox;
    
    private void Awake()
    {
        rayDetection = gameObject.GetComponent<RayDetection>();
    }

    private void Update()
    {
        BoxTypeDetection();
        SendThirdBox();
    }

    private void SendThirdBox()
    {
        if(thirdBox != null)
        {
            if(thirdBox == LeftGameObject)
            {
                RightGameObject.GetComponent<VerbumBoxDetection>().BoxTypeDetectionThirdBox(LeftGameObject);
            }
            else if(thirdBox == RightGameObject)
            {
                LeftGameObject.GetComponent<VerbumBoxDetection>().BoxTypeDetectionThirdBox(RightGameObject);
            }
        }
    }

    private void BoxTypeDetection()
    {
        if (rayDetection.RayHitGameObjectLeft != null && rayDetection.RayHitGameObjectRight != null)
        {
            LeftGameObject = rayDetection.RayHitGameObjectLeft;
            RightGameObject = rayDetection.RayHitGameObjectRight;
            CheckVerbum(LeftGameObject);
            CheckVerbum(RightGameObject);
        }
    }

    private void CheckVerbum(GameObject gameObject)
    {
        if(gameObject.GetComponent<VerbumBoxDetection>() == null)
        {
            thirdBox = gameObject;
            twoBlocks = true;
        }
    }
}
