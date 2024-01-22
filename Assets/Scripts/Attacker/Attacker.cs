using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range (0f,5f)]
    float currentSpeed=1f;
    //[SerializeField] public GameObject deathVFX;
    GameObject currentTarget;     
    

    private void Awake(){
         FindAnyObjectByType<levelController>().addAttackerCount();
    }

    private void OnDestroy()
    {
        
            
        levelController levelController=FindAnyObjectByType<levelController>();
         if(levelController!= null)
         {
            levelController.reduceAttackerCount();
         }
            
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector2.left*currentSpeed*Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {if
    (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking",false);
            return;
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking",true);
        currentTarget=target;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget)
        {
            
            return;
        }
        Health health=currentTarget.GetComponent<Health>();
        if(health)
        {
            health.HealthReduce(damage);
        }
    }

    



}


