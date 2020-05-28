using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public enum State
    {
        Idle,
        Active,
        BattleOver
    }
    public State state;

    public Wave[] waveArray;

    public int totalEnemies;
    public int[] enemyNumbers;

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
                TestBattleOver();
                break;
        }
    }
    private void TestBattleOver()
    {
        if(state == State.Active)
        {
            if (AreWavesOver())
            {
                //Battle is over
                state = State.BattleOver;

            }
        }
    }
    private bool AreWavesOver()
    {
        foreach (Wave wave in waveArray)
        {
            if (wave.IsWaveOver())
            {
                //waves over
                
            }
            else
            {
                //wave not over
                return false;
            }
        }
        return true;
    }

    //Represents a single enemy spawn wave
    [System.Serializable]
    public class Wave
    {
         public GameObject enemy;
         public PlayerHealthScript playerHealth;
         public Transform[] spawnPoints;
        public EnemyHealthScript[] enemiesArray;

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
                enemiesArray = FindObjectsOfType<EnemyHealthScript>();
            }
            
        }
        public bool IsWaveOver()
        {
            if (timer < 0)
            {
                //wave spawned
                foreach(EnemyHealthScript enemyInstance in enemiesArray)
                {
                    if(enemyInstance.isAlive)
                    {
                        return false;
                        
                    }
                }
                return true;
                
            }
            else
            {
                //enemies haven't spawned yet
                return false;
            }
        }
    }
}
