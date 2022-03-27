using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{


    public static CoinManager instance;
    int coinCount = 0;
    public int maxCoinCount = 3;
    public HorizontalLayoutGroup coinUIContainer;
    public HorizontalLayoutGroup bombUIContainer;
    public GameObject coinUIPrefab;
    public GameObject bombUIPrefab;
    public GameObject bombPrefab;
    private GameObject player;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if(coinCount == maxCoinCount  && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBomb();
        }
    }
    public void UpdateCoinCount(GameObject coin)
    {
        if(coinCount < maxCoinCount)
        {

            ++coinCount;
            GameObject temp = GameObject.Instantiate(coinUIPrefab);
            temp.transform.SetParent(coinUIContainer.transform);
            Destroy(coin.gameObject);
            if (coinCount == maxCoinCount)
            {
                GameObject bomb = GameObject.Instantiate(bombUIPrefab);
                bomb.transform.SetParent(bombUIContainer.transform);
            }
        }
       
        
    }
    private void SpawnBomb()
    {
        GameObject.Instantiate(bombPrefab,player.transform.position,Quaternion.identity);
        coinCount = 0;
        int childcount = coinUIContainer.transform.childCount;
        for  (int i = childcount - 1; i>-1; --i)
        {
            GameObject temp = coinUIContainer.transform.GetChild(i).gameObject;

            Destroy(temp);
        }
    }

    
}
