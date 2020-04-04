using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void Pause()
    {
        FindObjectOfType<AudioManager>().Play("PauseButton");
        Time.timeScale = 0;
    }

   public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("ResumeButton");
        Time.timeScale = 1;
    }
}
