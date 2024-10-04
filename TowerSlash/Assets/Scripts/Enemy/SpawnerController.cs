using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : Singleton<SpawnerController>
{
    [SerializeField] Transform  _enemySpawnPoint;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _player;
    public List<GameObject> enemyList = new List<GameObject>();
    public float spawnerDelay;
    public void StartGame()
    {
        spawnerDelay = 1.3f;
        StartCoroutine(SpawnStart());
    }

    IEnumerator SpawnStart()
    {
        Debug.Log("Spawning...");

        while (GameManager.Instance.Player.IsAlive)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnerDelay);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemyObj = (GameObject)Instantiate(_enemyPrefab);
        enemyObj.transform.position = _enemySpawnPoint.position;
        enemyObj.GetComponent<Enemy>()._player = _player;
        enemyList.Add(enemyObj);
    }

    public void RemoveEnemy(GameObject obj)
    {
        if (obj != null && enemyList.Contains(obj))
        {
            enemyList.Remove(obj);
            Destroy(obj);
        }
    }

    public void Reset()
	{
        // Create a temporary list to store enemies to remove
        List<GameObject> enemiesToRemove = new List<GameObject>();

        // Collect enemies to remove after the loop
        foreach (GameObject enemyObj in enemyList)
        {
            if (enemyObj != null)
            {
                enemiesToRemove.Add(enemyObj); // Add enemy to the removal list
            }
        }

        // Remove the collected enemies
        foreach (GameObject enemyObj in enemiesToRemove)
        {
            RemoveEnemy(enemyObj); // This also removes it from enemyList
        }

        enemyList.Clear();

        spawnerDelay = 1.3f;
    }
}
