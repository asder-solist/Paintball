using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    /// <summary>
    /// Текст "счет"
    /// </summary>
    [SerializeField] TextMeshProUGUI scoreText;

    /// <summary>
    /// Текст "бонус"
    /// </summary>
    [SerializeField] TextMeshProUGUI bonusText;

    // Start is called before the first frame update
    void Start()
    {
        GameController.OnScorePointsChanged += ShowScore;
        GameController.OnBonusReceived += ShowBonus;
    }

    /// <summary>
    /// Показывает последний полученный бонус
    /// </summary>
    /// <param name="obj"></param>
    private void ShowBonus(string bonus)
    {
        bonusText.text = bonus;
    }

    /// <summary>
    /// Показывает счет
    /// </summary>
    /// <param name="points"></param>
    private void ShowScore(string points)
    {
        scoreText.text = points;
    }
}
