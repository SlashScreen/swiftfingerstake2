using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FINAL STRUCTURE
//Movement (this): Handles movement along the grid
//Behavior: Handles behavior
//Sensory: Handles finidng player

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.AI.NavMeshAgent nav;
    void Start()
    {
        nav.SetDestination( new Vector3(0,0,0) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
