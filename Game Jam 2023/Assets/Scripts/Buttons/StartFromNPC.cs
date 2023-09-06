using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFromNPC : MonoBehaviour
{
    public void StartNPC01()
    {
        SceneManager.LoadScene("Level01");
    }
}
