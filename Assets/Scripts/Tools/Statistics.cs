using UnityEngine;

public struct Statistics
{
    public int towerHeight;
    public int highestStreak;
    public int score;

    public Statistics(int height, int streak, int score)
    {
        towerHeight = height;
        highestStreak = streak;
        this.score = score;
    }
}
