using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public SlingShooter SlingShooter;
    public TrailController TrailController;
    public List<Bird> Birds;
    public List<Enemy> Enemies;

    public BoxCollider2D TapCollider;

    public GameObject GameOver;
    public Text conditionText;

    public bool _isGameEnded = false;
    [SerializeField] private Bird _shotBird;
    void Start()
    {

        for (int i = 0; i < Birds.Count; i++)
        {
            Birds[i].OnBirdDestroyed += ChangeBird;
            Birds[i].OnBirdShot += AssignTrail;
        }
        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].OnEnemyDestroyed += CheckGameEnd;
        }

        GameOver.SetActive(false);
        TapCollider.enabled = false;
        SlingShooter.InitiateBird(Birds[0]);
        _shotBird = Birds[0];
    }
    public void ChangeBird()
    {
        TapCollider.enabled = false;
        if (_isGameEnded)
        {
            return;
        }
        Birds.RemoveAt(0);
        if (Birds.Count > 0)
        {
            _shotBird = Birds[0];
            SlingShooter.InitiateBird(Birds[0]);
        }

        //Game over kondisi
        if (Enemies.Count == 0)
        {
            conditionText.text = "You Win !!!";
            GameOver.SetActive(true);
        }
        else if (Birds.Count == 0 && Enemies.Count > 0)
        {
            conditionText.text = "You Lose !!!";
            GameOver.SetActive(true);
        }
    }
    public void CheckGameEnd(GameObject destroyedEnemy)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].gameObject == destroyedEnemy)
            {
                Enemies.RemoveAt(i);
                break;
            }
        }
    }
    public void AssignTrail(Bird bird)
    {
        TrailController.SetBird(bird);
        StartCoroutine(TrailController.SpawnTrail());
        TapCollider.enabled = true;
    }
    void OnMouseUp()
    {
        if (_shotBird != null)
        {
            _shotBird.OnTap();
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
        TapCollider.enabled = true;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
