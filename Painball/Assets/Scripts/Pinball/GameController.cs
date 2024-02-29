using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            if (_instance == null) _instance = new GameController();
            return _instance;
        }
    }

    /// <summary>
    /// Изменился счет
    /// </summary>
    public static event Action<string> OnScorePointsChanged;

    /// <summary>
    /// Получен бонус
    /// </summary>
    public static event Action<string> OnBonusReceived;

    /// <summary>
    /// Набранные очки
    /// </summary>
    static int totalScore;

    private void Start()
    {
        totalScore = 0;
    }

    /// <summary>
    /// Добавляет очки
    /// </summary>
    /// <param name="points"></param>
    internal static void AddPoints(int points)
    {
        OnBonusReceived?.Invoke($"+{points}");
        totalScore += points;
        OnScorePointsChanged(totalScore.ToString());
    }

    /// <summary>
    /// Применяет бонус умножения
    /// </summary>
    /// <param name="coefficient"></param>
    internal static void AddBonus(int coefficient)
    {
        OnBonusReceived?.Invoke($"х{coefficient}");
        totalScore *= coefficient;
        OnScorePointsChanged(totalScore.ToString());
    }

    /// <summary>
    /// Обнуляет счет
    /// </summary>
    internal static void ResetScore()
    {
        totalScore = 0;
        OnBonusReceived?.Invoke($"");
        OnScorePointsChanged(totalScore.ToString());
    }
}
