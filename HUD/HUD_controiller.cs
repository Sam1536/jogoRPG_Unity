using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // sempre que vc quiser usar o canvas e etc, precisa dessa biblioteca

public class HUD_controiller : MonoBehaviour
{
    [Header("Itens")]
    [SerializeField] private Image WaterUIbar;  
    [SerializeField] private Image WoodUIbar; 
    [SerializeField] private Image CarrotsUIbar;
    [SerializeField] private Image FishUIbar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;
    
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;
   
    private Player_itens playerItens;
    private Player player;

    

    private void Awake()
    {
        playerItens = FindObjectOfType<Player_itens>();
        player = playerItens.GetComponent<Player>();
    }


    // Start is called before the first frame update
    void Start()
    {
        WaterUIbar.fillAmount = 0f;
        WoodUIbar.fillAmount = 0f;
        CarrotsUIbar.fillAmount = 0f;
        FishUIbar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        WaterUIbar.fillAmount = playerItens.currentWater / playerItens.waterLimit;
        WoodUIbar.fillAmount = playerItens.totalWood / playerItens.woodLimit;
        CarrotsUIbar.fillAmount = playerItens.carrots / playerItens.carrotsLimit;
        FishUIbar.fillAmount = playerItens.fishes / playerItens.fishesLimit;

        //toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
