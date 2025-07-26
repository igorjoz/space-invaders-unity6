using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FleetScript : MonoBehaviour
{
    //czas co ile porusza si� flota
    public float moveTime = 2;
    //pr�dko��
    public float moveSpeed = 0.3f;
    //licznik ruch�w
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
            //je�eli gra trwa i we flocie nie ma ju� obcych to zatrzymujemy gr�
            StopGame(true);
        }

        //reset gdy naci�niemy R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void StopGame(bool win)
    {
        //Zatrzymujemy ruch i gr�
        CancelInvoke("Move");
        gameRun = false;

        endText.gameObject.SetActive(true);
        endText.text = win ? "You Win!" : "You Lose!";
    }
    public void StartGame()
    {
        //rozpoczynamy wywo�ywanie metody ruch co wybrany czas
        InvokeRepeating("Move", moveTime, moveTime);
        //aktywujemy gr� i wy��czamy widoczno�� tekstu
        gameRun = true;

        endText.gameObject.SetActive(false);
    }
    void Move()
    {
        //w zale�no�ci od kierunku przesuwamy si� i zmieniamy licznik
        transform.position += new Vector3(moveSpeed * moveDir, 0, 0);
        moveCounter += moveDir;
        //Je�eli licznik zejdzie do -4 lub 4 przesuwamy si� w d�
        if (moveCounter <= -4 || moveCounter >= 4)
        {
            moveDir *= -1;
            transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }
}
