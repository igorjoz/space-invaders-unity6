using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FleetScript : MonoBehaviour
{
    //czas co ile porusza siê flota
    public float moveTime = 2;
    //prêdkoœæ
    public float moveSpeed = 0.3f;
    //licznik ruchów
    int moveCounter = 0;
    //kierunek poruszania
    int moveDir;
    public bool gameRun;

    public TMP_Text endText;


    void Start()
    {
        moveDir = 1;
        StartGame();
    }
    private void Update()
    {
        if (gameRun && transform.childCount == 0)
        {
            //je¿eli gra trwa i we flocie nie ma ju¿ obcych to zatrzymujemy grê
            StopGame(true);
        }

        //reset gdy naciœniemy R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void StopGame(bool win)
    {
        //Zatrzymujemy ruch i grê
        CancelInvoke("Move");
        gameRun = false;

        endText.gameObject.SetActive(true);
        endText.text = win ? "You Win!" : "You Lose!";
    }
    public void StartGame()
    {
        //rozpoczynamy wywo³ywanie metody ruch co wybrany czas
        InvokeRepeating("Move", moveTime, moveTime);
        //aktywujemy grê i wy³¹czamy widocznoœæ tekstu
        gameRun = true;

        endText.gameObject.SetActive(false);
    }
    void Move()
    {
        //w zale¿noœci od kierunku przesuwamy siê i zmieniamy licznik
        transform.position += new Vector3(moveSpeed * moveDir, 0, 0);
        moveCounter += moveDir;
        //Je¿eli licznik zejdzie do -4 lub 4 przesuwamy siê w dó³
        if (moveCounter <= -4 || moveCounter >= 4)
        {
            moveDir *= -1;
            transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }
}
