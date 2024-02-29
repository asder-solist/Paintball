using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    //положение покоя
    [SerializeField] float restPosition = 0f;
    //положение после активации
    [SerializeField] float pressedPosition = 0f;
    //сила удара
    [SerializeField] float hitStrenght = 10000f;
    //сопротивление
    [SerializeField] float flipperDamper = 150f;

    /// <summary>
    /// "имя" инпута (настраиваем в инпут-менеджере)
    /// </summary>
    [SerializeField] string inputName;

    /// <summary>
    /// Шарнир
    /// </summary>
    HingeJoint hinge;

    /// <summary>
    /// Пружина
    /// </summary>
    JointSpring spring;

    void Start()
    {
        //шарнир
        hinge = GetComponent<HingeJoint>();

        //пружина
        spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = flipperDamper;

        //включаем пружину
        hinge.useSpring = true;
    }

    void Update()
    {
        //если нажата кнопка, ассоциированная с флиппером
        if (Input.GetAxis(inputName) == 1)
        {
            //стремимся к новому положению
            spring.targetPosition = pressedPosition;
        }
        else
        {
            //возвращаемся на место
            spring.targetPosition = restPosition;
        }
        hinge.spring = spring;
    }
}
