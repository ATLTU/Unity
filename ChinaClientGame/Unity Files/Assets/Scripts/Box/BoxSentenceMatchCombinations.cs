using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSentenceMatchCombinations : MonoBehaviour
{
    public List<SentenceCombination> _sentenceCombinations = new List<SentenceCombination>();
    public List<string> SentenceCombinations;
    public Dictionary<string, PlayerStateType> SentenceCombinations02 = new Dictionary<string, PlayerStateType>();
    
    private void Awake()
    {
        SentenceCombinations = new List<string>();
    }

    private void Start()
    {
        FindAllWords();
    }

    private void FindAllWords()
    {
        foreach (SentenceCombination item in _sentenceCombinations)
        {
            string tmp = "";
            tmp += (item.firstWord == WordType.None ? "" : item.firstWord.ToString());
            tmp += (item.secoundWord == WordType.None ? "" : item.secoundWord.ToString());
            tmp += (item.thirdWord == WordType.None ? "" : item.thirdWord.ToString());
            tmp += (item.fourthWord == WordType.None ? "" : item.fourthWord.ToString());
            tmp += (item.fifthWord == WordType.None ? "" : item.fifthWord.ToString());
            SentenceCombinations.Add(tmp);
            SentenceCombinations02.Add(tmp,item.playerStateType);
        }
    }

    public bool SentenceCompare(string BoxMadeString)
    {
        bool found = false;

        foreach (string item in SentenceCombinations)
        {
            if(string.Equals(item, BoxMadeString))
            {
                found = true;
                break;
            }
        }

        if(found == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
