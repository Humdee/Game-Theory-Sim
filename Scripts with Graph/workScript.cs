using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workScript : MonoBehaviour
{
    public float randomNum;
    public string Strat;
    public void GenerateRandomNum() {
        randomNum = Mathf.Round(Random.value * 100f);
    }
    public void StratChosen() {
        if (randomNum <= 50)
        {
            Strat = "Fix";
        } else
        {
            Strat = "Kludge";
        }
    }
}
