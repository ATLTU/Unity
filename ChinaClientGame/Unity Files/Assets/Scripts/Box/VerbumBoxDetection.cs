using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbumBoxDetection : MonoBehaviour
{
    private BoxSentenceMatchCombinations box;
    public string BoxType;
    public WordType BoxWord;
    private RayDetection rayDetection;
    [SerializeField] private bool sentenceCorrect;
    string SentenceCombination;

    public GameObject thirdGameObject;

    public bool SentenceCorrect { get => sentenceCorrect; set => sentenceCorrect = value; }

    private void Awake()
    {
        box = FindObjectOfType<BoxSentenceMatchCombinations>();
        rayDetection = GetComponent<RayDetection>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.CallPlayerState(PlayerStateType.EnemeyAttackMe);
    }

    // Update is called once per frame
    void Update()
    {
        BoxTypeDecetion();
    }

    private void BoxTypeDecetion()
    {
        if (rayDetection.RayHitGameObjectLeft != null && rayDetection.RayHitGameObjectRight != null)
        {
            GameObject LeftGameObject = rayDetection.RayHitGameObjectLeft;
            GameObject RightGameObject = rayDetection.RayHitGameObjectRight;

            if (BoxTypeCheck(LeftGameObject) && BoxTypeCheck(RightGameObject))
            {
                //SentenceCombination = LeftGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString() + BoxWord.ToString() + RightGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString();

                if (LeftGameObject.GetComponent<GeneralBoxDetection>().BoxWord != WordType.None)
                {
                    SentenceCombination = LeftGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString() + BoxWord.ToString();
                }
                else if(RightGameObject.GetComponent<GeneralBoxDetection>().BoxWord != WordType.None)
                {
                    SentenceCombination = BoxWord.ToString() + RightGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString();
                }

                if (thirdGameObject != null)
                {
                    if(BoxTypeCheck(thirdGameObject))
                    {
                        if (LeftGameObject.GetComponent<GeneralBoxDetection>().TwoBlocks == true)
                        {
                            string tmp = SentenceCombination;
                            SentenceCombination = thirdGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString() + tmp;
                        }
                        else if(RightGameObject.GetComponent<GeneralBoxDetection>().TwoBlocks == true)
                        {
                            string tmp = SentenceCombination;
                            SentenceCombination = tmp + thirdGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString();
                        }
                    }
                }

                if (box.SentenceCombinations.Contains(SentenceCombination))
                {
                    GameEvent.current.CallPlayerState(box.SentenceCombinations02[SentenceCombination]);
                }

                SentenceCorrect = box.SentenceCompare(SentenceCombination);
            }
        }
    }

    public void BoxTypeDetectionThirdBox(GameObject thirdBox)
    {
        thirdGameObject = thirdBox;
    }

    private bool BoxTypeCheck(GameObject gameObject)
    {
        string BoxTypeGameObject = gameObject.GetComponent<GeneralBoxDetection>().BoxType;
        if (BoxType != BoxTypeGameObject)
        {
            return true;
        }

        return false;
    }
}
