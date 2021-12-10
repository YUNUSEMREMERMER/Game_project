using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;

    EasyFileSave myNewFile;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); 
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET : " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED : " + enemyKilled.ToString();
            WinProcess();
        }
    }

    void StartProcess()
    {
        myNewFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myNewFile.Add("totalShotBullet", totalShotBullet);
        myNewFile.Add("totalEnemyKilled", totalEnemyKilled);

        myNewFile.Save();
    }

    public void LoadData()
    {
        if (myNewFile.Load())
        {
            totalShotBullet = myNewFile.GetInt("totalShotBullet");
            totalEnemyKilled = myNewFile.GetInt("totalEnemyKilled");
        }
    }

    public void WinProcess()
    {
        if (enemyKilled >= 5)
        {
            print("KAZANDINIZ");
        }
    }

    public void LoseProcess()
    {
        print("KAYBETT�N�Z");
    }
}