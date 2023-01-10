using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    private bool firstwave = true;
    private int enemySpawnNum = 10;
    public int waveNum = 0;
    public Text WaveCounter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    public IEnumerator EnemyDrop()
    {
        
        while (enemyCount < enemySpawnNum)
        {
            
            xPos = Random.Range(-35, 35);
            zPos = Random.Range(-35, 35);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;

        }
        firstwave = false;
        waveNum += 1;
        WaveCounter.text = "Wave " + waveNum;
        enemySpawnNum += 5;
    }

    public void enemyDead()
    {
        if (!firstwave)
        {
        enemyCount--;
        Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            StartCoroutine(EnemyDrop());
            
        }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
