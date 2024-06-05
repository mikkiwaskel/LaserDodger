using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera MainCamera;
    private bool isZoomIn = false;

    [Header("Texts")]
    public TextMeshProUGUI UI_CoinText, UI_WaveText, Retry_CoinText, Retry_WaveText, Win_CoinText, Win_WaveText;


    [Header("Coin Spawn Randomly")]
    public int CoinCounts = 0, WaveCounts = 1;
    public GameObject Coin_Prefab;
    public Animator CoinImage;
    public float spawnCoin_Min_Pos_X;
    public float spawnCoin_Max_Pos_X;
    public float spawnCoin_Min_Pos_Z;
    public float spawnCoin_Max_Pos_Z;
    public float spawnCoin_Pos_Y;

   

    [Header("Player Dead")]
    public bool isDead, isWon;
    public GameObject Pnl_Retry, Pnl_Win, Canvas_UI;
    public Transform YouAreDead_Ori, YouAreDead_Pos1, YouWon_Ori, YouWon_Pos1, Coin_Section_Ori, Coin_Section_Pos1, Wave_Section_Ori, Wave_Section_Pos1,
        Btn_Retry_Ori, Btn_Retry_Pos1;

    [Header("Sounds")]

    public AudioClip clickClip;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Pnl_Retry.SetActive(false);
        Pnl_Win.SetActive(false);
        Canvas_UI.SetActive(true);
        isDead = false;
        isWon = false;
    }
    private void Start()
    {
        SpawnCoin();
        isZoomIn = true;
        Sounds_Manager.instance.audioSource.volume = 0.2f;
    }
    // Update is called once per frame
    void Update()
    {

        UI_CoinText.text = CoinCounts.ToString();
        UI_WaveText.text = WaveCounts.ToString() + "/5";

        Retry_CoinText.text = CoinCounts.ToString();
        Retry_WaveText.text = WaveCounts.ToString() + "/5";

        Win_CoinText.text = CoinCounts.ToString();
        Win_WaveText.text = WaveCounts.ToString() + "/5";

        if (isDead) StartCoroutine(EndingFunction()); 
        if (isWon) Pnl_Win.SetActive(true);

        if (isZoomIn)
        {
            if(MainCamera.orthographicSize >= 32)
            {
                MainCamera.orthographicSize -= 10 * Time.deltaTime;
            }
        }
        else
        {
            if (MainCamera.orthographicSize <= 40)
            {
                MainCamera.orthographicSize += 10 * Time.deltaTime;
            }
        }
    }

    IEnumerator EndingFunction()
    {
        Canvas_UI.SetActive(false);
        yield return new WaitForSeconds(2f);

        if (isDead) 
        {
            Pnl_Retry.SetActive(true);
            Vector3 Smoothed_Position1 = Vector3.Lerp(YouAreDead_Ori.position, YouAreDead_Pos1.position, 3f * Time.deltaTime);
            YouAreDead_Ori.position = Smoothed_Position1;
            Vector3 Smoothed_Position2 = Vector3.Lerp(Coin_Section_Ori.position, Coin_Section_Pos1.position, 3f * Time.deltaTime);
            Coin_Section_Ori.position = Smoothed_Position2;
            Vector3 Smoothed_Position3 = Vector3.Lerp(Wave_Section_Ori.position, Wave_Section_Pos1.position, 3f * Time.deltaTime);
            Wave_Section_Ori.position = Smoothed_Position3;
            Vector3 Smoothed_Position4 = Vector3.Lerp(Btn_Retry_Ori.position, Btn_Retry_Pos1.position, 3f * Time.deltaTime);
            Btn_Retry_Ori.position = Smoothed_Position4;
        }

        if (isWon)
        {
            Pnl_Win.SetActive(true);
            Vector3 Smoothed_Position1 = Vector3.Lerp(YouWon_Ori.position, YouWon_Pos1.position, 3f * Time.deltaTime);
            YouWon_Ori.position = Smoothed_Position1;
        }

    }

    public void SpawnCoin()
    {
        CoinImage.SetTrigger("COIN");
        float spawn_Pos_x = (UnityEngine.Random.Range(spawnCoin_Min_Pos_X, spawnCoin_Max_Pos_X));
        float spawn_Pos_Z = (UnityEngine.Random.Range(spawnCoin_Min_Pos_Z, spawnCoin_Max_Pos_Z));
        Vector3 spawn_Position = new Vector3(spawn_Pos_x, spawnCoin_Pos_Y, spawn_Pos_Z);
        GameObject Coin_Clone = Instantiate(Coin_Prefab, spawn_Position, Quaternion.identity) as GameObject;
        Coin_Clone.transform.SetParent(this.transform);
        
    }

    public void OnClick_Retry()
    {
        Sounds_Manager.instance.SFX(clickClip);
        var thisLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisLevel);
    }
    public void OnClick_Menu()
    {
        Sounds_Manager.instance.SFX(clickClip);
        SceneManager.LoadScene(0);
    }
    public void OnClick_ZoomIn()
    {
        Sounds_Manager.instance.SFX(clickClip);
        isZoomIn = true; 
    }
    public void OnClick_ZoomOut()
    {
        Sounds_Manager.instance.SFX(clickClip);
        isZoomIn = false;
    }
}
