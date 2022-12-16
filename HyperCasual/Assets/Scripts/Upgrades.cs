using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Upgrades:MonoBehaviour
{

    public static float track_speed = 1f;

    public static int track_upgrade = 3;

    public static float spawn_time = 1f;

    public void UpdateTrackSpeed(int multiplier)
    {
       track_speed *= multiplier;
    }

    public void UpdateSpawnTime(int number_mult)
    {
        spawn_time += number_mult; 
    }
    
}
