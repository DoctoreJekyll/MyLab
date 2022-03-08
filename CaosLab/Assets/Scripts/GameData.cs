
[System.Serializable]
public class GameData
{
    public int playerHealth;
    public float playerScore;
    public float[] playerPos = new float[3];

    public GameData(Controller00 playerData)
    {
        playerHealth = playerData.health;
        playerScore = playerData.score;
        playerPos[0] = playerData.player.transform.position.x;
        playerPos[1] = playerData.player.transform.position.y;
        playerPos[2] = playerData.player.transform.position.z;
    }



}
