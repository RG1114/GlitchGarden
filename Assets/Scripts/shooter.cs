using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{

    private const string PROJECTILE_PARENT_NAME="projectiles";
    [SerializeField] GameObject projectilePrefab,gun;
    AttackerSpawn myLaneSpawner;
    Animator animator;
    GameObject projectileParent;

    void Start(){
        SetLaneSpawner();
        animator=GetComponent<Animator>();
         CreateProjectileParent();
    }



    private void CreateProjectileParent(){
        projectileParent=GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent=new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    void Update(){
        if(IsAttackerInLane()){
           animator.SetBool("isAttacking",true);
        }
        else{
            animator.SetBool("isAttacking",false);
        }
    }



    private void SetLaneSpawner()
    {
        AttackerSpawn[] spawners=FindObjectsOfType<AttackerSpawn>();
        foreach(AttackerSpawn spawner in spawners)
        {
            bool isCloseEnough=Mathf.Abs(spawner.transform.position.y-transform.position.y)<=0.5;
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane(){

        if(myLaneSpawner.transform.childCount<=0)
        {
            return false;
        }
        else{
            return true;
        }
    }
    
    public void Fire()
    {
        GameObject projectile= Instantiate(projectilePrefab,gun.transform.position,projectilePrefab.transform.rotation) as GameObject;
        projectile.transform.parent=projectileParent.transform;

        
    }

}
