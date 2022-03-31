using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerChanger : MonoBehaviour
{
    public SpriteRenderer playerSprite; 

    public List<Color> options = new List<Color>();

    private int currentOption = 0;

    public TMP_InputField nickNameInputField;

    //public GameObject playerPrefab;

    public static PlayerChanger _instance; [HideInInspector]

    public TMP_Text nickNameText;
    private void Awake()
    {
        _instance = this;
    }

    public void NextOption()
    {
        Debug.Log("Call Ho raha hai 1");
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }

        playerSprite.color = options[currentOption];

    }

    public void PrevOption()
    {
        Debug.Log("Call Ho raha hai");
        currentOption--;
        if (currentOption <= options.Count-1)
        {
            currentOption = options.Count-1;
        }

        playerSprite.color = options[currentOption];
    }

    public void Submit()
    {
       nickNameText.text = nickNameInputField.text;
    }


}
