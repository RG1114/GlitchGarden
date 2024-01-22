using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Defender defenderPrefab;

    private void Start(){
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText=GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogError(name+"has no cost text ");
        }
        else{
            costText.text=defenderPrefab.starsCost().ToString();
        }
    }

    void OnMouseDown()
    {
        var buttons=FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color=new Color32(104,90,90,255);
        }
        GetComponent<SpriteRenderer>().color=Color.white;
        FindObjectOfType<SpawnDefender>().SetSelectedDefender(defenderPrefab); 
    }
}
