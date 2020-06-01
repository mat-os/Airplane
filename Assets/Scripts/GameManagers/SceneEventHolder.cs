using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneEventHolder : MonoBehaviour
    {
        public void LoadSceen(int sceenNumber)
        {
            SceneManager.LoadScene(sceenNumber);
        }
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
            Time.timeScale = 1f;

            DOTween.KillAll();
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
