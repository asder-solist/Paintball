
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// При столкновении
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //при столкновении с кикером
        if (collision.gameObject.CompareTag("Kicker"))
        {
            SlingshotPush();
        }
        //при столкновении со слингшотом
        else if (collision.gameObject.CompareTag("Slingshot"))
        {
            SlingshotPush();
        }
    }

    /// <summary>
    /// Запускается после столкновения с магнитом
    /// </summary>
    /// <returns></returns>
    public IEnumerator MagnetPush()
    {
        //ждем секунду
        yield return new WaitForSeconds(1);
        //уничтожаем соединение
        Destroy(gameObject.GetComponent<FixedJoint>());
        //поворачиваемся
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        //толкаем
        rb.AddForce(rb.transform.forward * 70, ForceMode.Impulse);
    }

    /// <summary>
    /// Запускается после столкновения со слингшотом
    /// </summary>
    /// <returns></returns>
    public void SlingshotPush()
    {
        //поворачиваемся
        transform.rotation = Quaternion.Euler(0, 360 + (Random.Range(-50, +50)), 0);
        //толкаем
        rb.AddForce(rb.transform.forward * 70, ForceMode.Impulse);
    }


}
