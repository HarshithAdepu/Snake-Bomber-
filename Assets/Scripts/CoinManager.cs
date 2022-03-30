using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{


    public static CoinManager instance;
    int coinBagCount = 0;
    public int maxCoinBagCount = 3;
    public HorizontalLayoutGroup coinUIContainer;
    public HorizontalLayoutGroup bombUIContainer;
    public GameObject coinUIPrefab;
    public GameObject bombUIPrefab;
    public GameObject bombPrefab;
    private GameObject player;
    private GameObject bomb;
    public bool bombCarrier;

    void Start()
    {
        bombCarrier = false;    
        if(instance == null)
        {
            instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if(bombCarrier  && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBomb();
            Destroy(bomb);
            bombCarrier = false;
            
        }
    }
    public void UpdateCoinCount(GameObject coin)
    {
        if(coinBagCount < maxCoinBagCount)
        {

            ++coinBagCount;
            GameObject temp = GameObject.Instantiate(coinUIPrefab);
            temp.transform.SetParent(coinUIContainer.transform);
            Destroy(coin.gameObject);
            if (coinBagCount == maxCoinBagCount && !bombCarrier)
            {
                bombCarrier = true;
                bomb = GameObject.Instantiate(bombUIPrefab);
                bomb.transform.SetParent(bombUIContainer.transform);
                ResetCoinBagCount();
            }
            else if(coinBagCount == maxCoinBagCount && bombCarrier)
            {
                ResetCoinBagCount();
            }
            
        }

       
    }
    public void ResetCoinBagCount()
    {
        coinBagCount = 0;
        StartCoroutine(timer());
        
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 2; i > -1; i--)
        {

            Destroy(coinUIContainer.transform.GetChild(i).gameObject);
        }
    }
    private void SpawnBomb()
    {
        GameObject.Instantiate(bombPrefab,player.transform.position,Quaternion.identity);
    /*    coinBagCount = 0;
        int childcount = coinUIContainer.transform.childCount;
        for  (int i = childcount - 1; i>-1; --i)
        {
            GameObject temp = coinUIContainer.transform.GetChild(i).gameObject;

            Destroy(temp);
        }*/
    }
 
}
