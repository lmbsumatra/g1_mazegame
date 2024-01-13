/*using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //Sound that we'll play when picking up a new checkpoint
    private Transform currentCheckpoint; //We'll store our last checkpoint here
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position; //love player to checkpoint position 
        playerHealth.Respawn();  //Restore player health and reset anination
    }

    //Activate Checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //Store the checkpoint that activated as current one
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider>().enabled = false; //Deactivate Checkpoint Collider
            collision.GetComponent<Animator>().SetTrigger("Appear"); //Trigger Checkpoint Location
        }
    }

}
*/