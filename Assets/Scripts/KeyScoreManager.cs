using UnityEngine;

public class KeyScoreManager : MonoBehaviour
{
    public static int keyAmount;

    // Add any initialization or functionality here if needed

    // Example: Increment key count
    public void IncrementKeyCount()
    {
        keyAmount++;
    }

    //Reset key Count to zero
    public static void ResetKeyCount()
    {
        keyAmount = 0;
    }
}