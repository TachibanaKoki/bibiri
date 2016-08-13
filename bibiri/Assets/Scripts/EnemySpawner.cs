using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    float SpawnTime=1.0f;

	// Use this for initialization
	void Start () {
       // StartCoroutine("EnemySpawn");
       for(int i = 0;i<100;i++)
        {
            ObjectSpawn();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator EnemySpawn()
    {
        while(true)
        {
            ObjectSpawn();
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    void ObjectSpawn()
    {
        GameObject obj;
        obj = GameObject.Instantiate(EnemyPrefab, gameObject.transform) as GameObject;
        obj.transform.position = gameObject.transform.position;
    }
}
