using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameTimer : MonoBehaviour
{
    [Tooltip("level timer in Seconds")]
    [SerializeField] float levelTime;
    bool triggerLevelFinsh=false;

    void Start(){
        
        levelTime=(playerPrefsController.GetMasterDifficulty()+1)*3 + levelTime;
    }
    void Update()
    {

        if(triggerLevelFinsh)
        {
            return;
        }
        GetComponent<Slider>().value=Time.timeSinceLevelLoad/levelTime;

        bool timerFinished=(Time.timeSinceLevelLoad>=levelTime);
        if(timerFinished )

        {

            FindObjectOfType<levelController>().setTimerFinished();
            triggerLevelFinsh=true;
            
            
        }
    }
}
