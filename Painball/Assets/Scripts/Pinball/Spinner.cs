using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //при каждом повороте
        if (other.gameObject.CompareTag("SpinnerTrigger"))
        {
            //добавляем очки
            GameController.AddPoints(10);
            Debug.Log("Spinner turned");
        }
    }
}
