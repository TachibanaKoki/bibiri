using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour {

    List<GameObject> targets;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        targets = new List<GameObject>();
        targets.AddRange( GameObject.FindGameObjectsWithTag("Target"));
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targets[0].transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	}

}
