using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefsController : MonoBehaviour
{
   const string MASTER_VOLUME_KEY="master volume";
   const string DIFFICULTY_KEY="difficulty";
   const float MIN_VOLUME=0f;
   const float MAX_VOLUME=1f;

   const int MIN_DIFFICULTY=0;
   const int MAX_DIFFICULTY=9;

   public static void SetMasterVolume(float volume)
   {
    if(volume >= MIN_VOLUME && volume <=MAX_VOLUME)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY,volume);
    }
    else{
        Debug.LogError("MASTER VOL IS out of range");
    }
    
   }
   public static float GetMasterVolume()
   {
    return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
   }


   public static void SetMasterDifficulty(int difficulty)
   {
    if(difficulty >= MIN_DIFFICULTY && difficulty <=MAX_DIFFICULTY)
    {
        PlayerPrefs.SetInt(DIFFICULTY_KEY,difficulty);
    }
    else{
        Debug.LogError("Difficulty IS out of range");
    }
    
   }
   public static int GetMasterDifficulty()
   {
    return PlayerPrefs.GetInt(DIFFICULTY_KEY);
   }
}
