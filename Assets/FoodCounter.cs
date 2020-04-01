using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodCounter : MonoBehaviour
{
     public static FoodCounter instance;
     public TextMeshProUGUI text;
     int food;

     // Start is called before the first frame update
     void Start()
     {
          if (instance == null)
          {
               instance = this;
          }
     }

     public void GainFoodAmount(int foodValue)
     {
          food += foodValue;
          text.text = "X" + food.ToString();

     }

     public void LoseFoodAmount(int foodValue)
     {
          food -= foodValue;
          text.text = "X" + food.ToString();

     }
}
