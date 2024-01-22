using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class SpawnDefender : MonoBehaviour
{

    const string DEFENDER_PARENT_NAME="Defenders";
    Defender defender; 
    GameObject defenderParent;

    private void Start(){
        CreateDefenderParent();
    }
    private void CreateDefenderParent(){
        defenderParent=GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent=new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    
    

    
    void OnMouseDown() 
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender=defenderToSelect;
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 WorldPos= Camera.main.ScreenToWorldPoint(clickPos);
        WorldPos=SnapToGrid(WorldPos);
        return WorldPos;
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX=Mathf.RoundToInt(rawWorldPos.x);
        float newY=Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        StarDisplay starText=FindObjectOfType<StarDisplay>();
        int defenderCost=defender.starsCost();
        if(starText.haveEnoughStars(defenderCost)){
            spawnDefender(gridPos);
            starText.SpendStars(defenderCost);
        }
    }

    private void spawnDefender(Vector2 roundedpos )
    {
        
        
        
        
        
        Defender newDefender =Instantiate(defender,roundedpos,Quaternion.identity) as Defender;
        newDefender.transform.parent=defenderParent.transform;
        
        
    }
   
}
