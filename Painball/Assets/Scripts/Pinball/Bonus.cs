using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    //"стоимость" этого бонуса
    [SerializeField] int coefficient;

    private void OnTriggerEnter(Collider other)
    {
        //при столкновении с шариком
        if (other.gameObject.CompareTag("Ball"))
        {
            //добавляем очки
            GameController.AddBonus(coefficient);
            Debug.Log("Bonus triggered");
        }
    }
}
