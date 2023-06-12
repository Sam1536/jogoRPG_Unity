using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_itens : MonoBehaviour
{
    [Header("Amounts")] // quanto o player tem
    public int totalWood;
    public int carrots;
    public float currentWater;
    public int fishes;
    
    
    [Header("Limits")] //o tanto que o player pode carregar
    public  float waterLimit = 50;
    public  float woodLimit = 4;
    public  float carrotsLimit = 7;
    public float fishesLimit= 3f;
    
        
        
        
    public void WaterLimit(float water)
    {
        
        if(currentWater <= waterLimit)
        {
            currentWater += water;
        }
        
    }


}
