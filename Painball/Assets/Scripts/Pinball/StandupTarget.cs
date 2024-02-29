using UnityEngine;

public class StandupTarget : MonoBehaviour
{
    //"стоимость" этого таргета
    [SerializeField] int points;

    private void OnCollisionEnter(Collision collision)
    {
        //при столкновении с шариком
        if (collision.gameObject.CompareTag("Ball"))
        {
            //добавляем очки
            GameController.AddPoints(points);
            Debug.Log("StandupTarget kicked");
        }
    }
}
