using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active
    }
    private State state;

    public Wave[] waveArray;

    private void Awake()
    {
        state = State.Idle;
    }
    private void Start()
    {
        StartBattle();
    }
    private void StartBattle()
    {
        state = State.Active;
    }
    private void Update()
    {
        switch (state)
        {
            case State.Active:
                foreach (Wave wave in waveArray)
                {
                    wave.Update();
                }
                break;
        }
        
    }


    //Represents a single enemy spawn wave
    [System.Serializable]
    public class Wave
    {
         public GameObject enemy;
         public PlayerHealthScript playerHealth;
         public Transform[] spawnPoints;

        public int numberOfWaveEnemies;

         public float timer;

         public void Update()
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    SpawnEnemy();
                }
            }
        }
       
    public void SpawnEnemy()
        {
            for(int i = 0; i < numberOfWaveEnemies; i++)
            {
                if (playerHealth.currentHealth == 0)
                {
                    return;
                }
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            
        }
    }
}
