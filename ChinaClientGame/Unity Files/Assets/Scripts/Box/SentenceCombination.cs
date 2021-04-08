using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SentenceCombination
{
    [Header("PlayerStatus")]
    public PlayerStateType playerStateType;
    
    [Header("WordTypes")]
    public WordType firstWord;
    public WordType secoundWord;
    public WordType thirdWord;
    public WordType fourthWord;
    public WordType fifthWord;
}
