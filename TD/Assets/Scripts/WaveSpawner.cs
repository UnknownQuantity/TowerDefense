using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 5f;

    public Text waveCountDownText;

    private int waveNumber = 1;
        

    private void Update()
    {
        if (countdown <= 0)
        {
            SpawnWave();
            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    void SpawnWave()
    {
        Debug.Log("Wave inc");

        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
        }

        waveNumber++;

        //numOfEnemies = waveNumber * waveNumber + 1;
    }


    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
