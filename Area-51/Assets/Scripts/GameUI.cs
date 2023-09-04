using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject restartMenu;
    [SerializeField] public GameObject inGameUI;
    [SerializeField] public TMP_Text restartTimeText;
    [SerializeField] private PlayerManager _playerManager;
    private int realScore;
    private bool isPaused = false;
    public List<GameObject> healthBars;

    private void Start()
    {
        UpdateScore(0);
        pauseMenu.SetActive(false);
    }
  

    public void UpdateScore(int score)
    {

        int scoreIncrement = score;
        realScore += scoreIncrement;
        scoreText.text = "Score: " + realScore.ToString();
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        Time.timeScale = isPaused ? 0 : 1; // Pause or resume the game time
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    public void HealtBars()
    {
        StartCoroutine(HpBars());
    }


    public IEnumerator HpBars()
    {
        GameObject hpBar = healthBars[healthBars.Count - 1];
        hpBar.transform.SetParent(this.transform);
        var sequence = DOTween.Sequence();
        sequence.Append(hpBar.transform.DOLocalMoveY(510, 0.3f).SetEase(Ease.InFlash));
        sequence.Append(hpBar.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.4f).SetEase(Ease.InFlash));
        sequence.Append(hpBar.transform.DOShakePosition(duration: 0.5f, strength: new Vector3(10, 0, 0), vibrato: 10, randomness: 90, fadeOut: true));
        sequence.Append(hpBar.transform.DOLocalMoveY(-700, 0.75f).SetEase(Ease.InFlash));
        yield return new WaitForSeconds(3.5f);
        healthBars.Remove(hpBar);
        Destroy(hpBar);
    }




























    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
