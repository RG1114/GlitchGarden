using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class AttackerSpawn : MonoBehaviour
{
    [SerializeField] float minSpawnDelay=7f;
    [SerializeField] float maxSpawnDelay=10f;
    [SerializeField] private bool spawn=true;
    [SerializeField] Attacker[] attackerPrefabs;
    //[SerializeField] float yOffset=3f;
    //public Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {

        minSpawnDelay=Math.Abs(minSpawnDelay-playerPrefsController.GetMasterDifficulty());
        maxSpawnDelay=Math.Abs( maxSpawnDelay-playerPrefsController.GetMasterDifficulty());
        StartCoroutine(spawner());
        

    }
    IEnumerator spawner()
    {
        while (spawn)
        {
            //spawnPos=new Vector2(transform.position.x,transform.position.y-Random.Range(0,5));
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay,maxSpawnDelay));
            SpawnAttacker();
           
        }
    }

    private void SpawnAttacker()
    {   
        
        int indexSpawner= UnityEngine.Random.Range(0,attackerPrefabs.Length);
        Spawn(attackerPrefabs[indexSpawner]);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        double yPos=transform.position.y+ 0.5;
        UnityEngine.Vector3 spawnPoint=new UnityEngine.Vector3(transform.position.x,(float)yPos,transform.position
        .z);
        Attacker newAttacker=Instantiate
        (attackerPrefab,spawnPoint,transform.rotation) as Attacker;
        newAttacker.transform.parent=transform;

       
    }

    public void setSpawnoff()
    {
        spawn=false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
