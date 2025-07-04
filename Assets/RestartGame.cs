using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [Header("Player1")]
    public bool P1Past = false;

    [Header("Player2")]
    public bool P2Past = false;

    private GameObject VarManager;
    void Start()
    {
        VarManager = GameObject.FindGameObjectWithTag("VarManager");
    }

    private void Reset()
    {
        if (P1Past == true && P2Past == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GlobalVars Vars = VarManager.GetComponent(typeof(GlobalVars)) as GlobalVars;
        if (other.gameObject.CompareTag("Player"))
        {
            P1Past = true;
            Reset();
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            P2Past = true;
            Reset();
        }

    }
}
