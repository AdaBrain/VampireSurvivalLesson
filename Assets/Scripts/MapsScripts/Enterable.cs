using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enterable : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    [SerializeField] Vector3 origin;    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.transform.position = origin;
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
    }
}
