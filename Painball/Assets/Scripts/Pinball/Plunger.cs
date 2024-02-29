using UnityEngine;
using UnityEngine.UI;

public class Plunger : MonoBehaviour
{
    //сила толчка
    float power;

    //минимальная сила
    float minPower = 0f;

    //шарик в зоне запуска
    bool hasBall;

    //максимальная сила
    [SerializeField] float maxPower = 100f;

    //слайдер
    [SerializeField] Slider powerSlider;

    //толкающий элемент
    [SerializeField] Rigidbody pusher;

    void Start()
    {
        //устанавливаем границы слайдеру
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
    }

    void Update()
    {
        //если шарик в зоне запуска
        if (hasBall)
        {
            //показываем слайдер
            powerSlider.gameObject.SetActive(true);

            //если нажат пробел
            if (Input.GetKey(KeyCode.Space))
            {
                //если есть куда набирать силу толчка
                if (power < maxPower)
                {
                    //делаем это
                    power += (maxPower / 5) * Time.deltaTime;
                }
            }
            //когда отпущен пробел
            if (Input.GetKeyUp(KeyCode.Space))
            {
                pusher.AddForce(power * 10 * Vector3.forward, ForceMode.Impulse);
                //забываем про шарик
                hasBall = false;
                //обнуляем силу толчка
                power = minPower;
                //скрываем слайдер
                powerSlider.gameObject.SetActive(false);
            }
        }
        else
        {
            //скрываем слайдер
            powerSlider.gameObject.SetActive(false);
        }

        //привязываем значение слайдера к текущему значению силы толчка
        powerSlider.value = power;
    }

    private void OnTriggerEnter(Collider other)
    {
        //если шарик вошел в зону триггера
        if (other.gameObject.CompareTag("Ball"))
        {
            hasBall = true;
            //обнуляем значения UI элементов
            GameController.ResetScore();
        }
    }
}
