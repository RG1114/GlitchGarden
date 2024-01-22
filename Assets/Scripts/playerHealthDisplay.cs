using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthDisplay : MonoBehaviour
{
    Text Healthtext;
    [SerializeField] int hp; 
    
    void Start()
    {
        
        Healthtext=GetComponent<Text>();
        hp=hp-playerPrefsController.GetMasterDifficulty();
        UpdateDisplay();

        
    }

    public void reduceHealth(int n)
    {
        if(hp>=1)
        {
            hp=hp-1;
            UpdateDisplay();
        }
        if(hp<=0)
        {
           FindObjectOfType<levelController>().HandleLoseCondition();
        }
        
    }
    private void UpdateDisplay()
    {
        Healthtext.text=hp.ToString();

    }
    // Update is called once per frame
    
}
