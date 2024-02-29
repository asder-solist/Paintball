using UnityEngine;

public class Lighter : MonoBehaviour
{
    //"стоимость" этого лайтера
    [SerializeField] int points;

    private void OnTriggerEnter(Collider other)
    {
        //при столкновении с шариком
        if (other.gameObject.CompareTag("Ball"))
        {
            //добавляем очки
            GameController.AddPoints(points);
            Debug.Log("Lighter triggered");
        }
    }
}
