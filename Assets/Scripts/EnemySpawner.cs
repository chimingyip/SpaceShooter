using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // instantiate enemy prefabs within certain x coord range at regular time intervals
    // the time interval between spawns increases slowly over time --> difficulty increase
    // will need to ensure that enemies cannot spawn on top of each other 
        // option 1: perhaps take note of the position that the last enemy spawned and then exclude that position from the x coord range that the next enemy can spawn
        // option 2: if two enemies spawn on top of each other, destroy one of them 
        // option 3: destroy both enemies and just let it be a gap in the spawning
}
