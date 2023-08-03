using UnityEngine;

[System.Serializable]
public class PlayerModel
{
    public float MoveSpeed = 20f;
    public int MaxHealth = 100;
    public int currentHealth;
    public int score;

    public PlayerModel()
    {
        currentHealth = MaxHealth;
        score = 0;
    }
}