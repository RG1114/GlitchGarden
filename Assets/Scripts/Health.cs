using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    
    [SerializeField] float health=100;
    [SerializeField] public GameObject deathVFX;
    // Start is called before the first frame update
    void Start(){
        if(this.GetComponentInParent<Attacker>()){
            health+=playerPrefsController.GetMasterDifficulty()*3;

        }
        
    }
    

    public void HealthReduce(float damage)
    {
        health-=damage;
        if(health <= 0)
        {
            TriggerdeathVFX();
            //Destroy(DeathVFX);
            Destroy(gameObject);

            
            
        }
    }
    public void TriggerdeathVFX()
    {
        GameObject DeathVFX=Instantiate(deathVFX,transform.position,transform.rotation) as GameObject;
        Destroy(DeathVFX,1f);
    }
}
