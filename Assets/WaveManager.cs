using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public List<GameObject> waveList = new List<GameObject>();
    public List<GameObject> bossWaveList = new List<GameObject>();
    public int waveNumber = 0;
    public int currentIndex = -1;
    public int currentBossIndex = 0;
    public bool isWave = false;
    public GameObject currentWave;
    public int enemyCount = 0;

    private bool isRandom = false;
    private bool isBossRandom = false;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        
        startNextWave();
    }

    private void FixedUpdate()
    {
        //update enemy count
        if(currentWave != null)
            enemyCount = currentWave.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 0)
        {   //All enemies are dead
            Debug.Log("All enemies are dead. Starting next wave");
            isWave = false;
        }
        if(!isWave)
            startNextWave();
    }

    public GameObject getNextWave()
    {
        if(waveNumber % 5 != 0)
        {
            //get Normal wave
            
            if (isRandom)
            {
                //cycled through each wave so now they will become random
                isRandom = true;
                currentIndex = Random.Range(0, waveList.Count);
            }
            else
            {
                currentIndex++;
            }

            if (currentIndex >= waveList.Count)
            {
                isRandom = true;
                currentIndex %= waveList.Count;
            }
            Debug.Log("isRandom: " + isRandom + " wavelist.count: " + waveList.Count);
            Debug.Log("Wave at index " + currentIndex + " gets started");
            return waveList[currentIndex];
        }
        else
        {
            //should be a boss wave
            currentBossIndex++;
            if (isBossRandom)
            {
                //cycled through each wave so now they will become random
                currentBossIndex = Random.Range(0, bossWaveList.Count);
            }
            else
            {
                currentBossIndex++;
            }

            if (currentBossIndex >= bossWaveList.Count())
            {
                isBossRandom = true;
                currentBossIndex %= bossWaveList.Count();
            }
            return bossWaveList[currentBossIndex];
        }

    }

    public void startNextWave()
    {
        //destroy current wave
        Destroy(currentWave);
        waveNumber++;
        currentWave = Instantiate(getNextWave());
        enemyCount = currentWave.transform.childCount;
        Debug.Log("Found " + enemyCount + " enemies in current wave");
        isWave = true;
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(1f);
        if(waveNumber % 5 != 0)
            Manager.Instance.WaveTextMesh.text = "Current Wave\n" + (waveNumber);
        else
            Manager.Instance.WaveTextMesh.text = "Current Wave\n" + (waveNumber) + "\n<color=red>BOSS Wave</color>";
        Manager.Instance.WavePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        currentWave.SetActive(true);
        yield return new WaitForSeconds(1f);
        Manager.Instance.WavePanel.SetActive(false);
        yield return null;
    }
}
