using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManagerEV : MonoBehaviour
{
    public GameConstants gameConstants;
    void Start()
    {
        Debug.Log("Spawnmanager start");
        for (int j = 0; j < 2; j++) spawnNewEnemy();
    }

    void startSpawn(Scene scene, LoadSceneMode mode)
    {
        for (int j = 0; j < 1; j++) spawnFromPooler(ObjectType.gombaEnemy);
    }


    void spawnFromPooler(ObjectType i)
    {
        GameObject item = ObjectPooler.SharedInstance.GetPooledObject(i);

        if (item != null)
        {
            //set position
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.position = new Vector3(Random.Range(1.5f, 8.5f), gameConstants.groundDistance + item.GetComponent<SpriteRenderer>().bounds.extents.y, 0);
            item.SetActive(true);
        }
        else
        {
            Debug.Log("not enough items in the pool!");
        }
    }

    public void spawnNewEnemy()
    {
        Debug.Log("Spawning 1 new enemy!");
        ObjectType i = Random.Range(0, 2) == 0 ? ObjectType.gombaEnemy : ObjectType.greenEnemy;
        spawnFromPooler(i);
    }

}
