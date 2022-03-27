using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreUpdater : MonoBehaviour
{
    PhotonView pView;
    public static ScoreUpdater _Instance;
    public  int playerScore_1;
    public  int playerScore_2;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        _Instance = this;
        
        SetScore();
    }

    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
       SetScore();
    }

    void SetScore()
    {
        player1ScoreText.text = playerScore_1.ToString();
        player2ScoreText.text = playerScore_2.ToString();   
    }
}
