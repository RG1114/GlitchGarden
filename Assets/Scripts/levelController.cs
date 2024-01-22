using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float waitToLoad=4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] public int attackerCount=0;
    public bool timerFinished=false;
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void addAttackerCount()
    {
        attackerCount+=1;
    }

    public void reduceAttackerCount(){
        attackerCount-=1;
        if(timerFinished && attackerCount<=0)
        {
            
            StartCoroutine(HandleWinCondition());
            
           
            
            
        }
    }

    IEnumerator HandleWinCondition()
    {

        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();

        
    }

    public void HandleLoseCondition(){
        loseLabel.SetActive(true);
        Time.timeScale=0;
    }

    public void setTimerFinished()
    {
        timerFinished=true;
        stopSpawner();
    }
    private void stopSpawner(){

        AttackerSpawn[] spawners=FindObjectsOfType<AttackerSpawn>();
            for(int i=0;i<spawners.Length;i++)
            {
                spawners[i].setSpawnoff();
            }

    }

   

    

}
