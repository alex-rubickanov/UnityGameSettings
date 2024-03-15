using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    public Vector2 Resolution;
    public bool FullScreen;
}
