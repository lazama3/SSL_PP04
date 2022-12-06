using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public GameObject piso;
    public GameObject pipe;
    
    public float velocidad = 5;

    public List<GameObject> pisos;
    public List<GameObject> pipes;

    public bool gameOver = false;

    public bool start = false;

    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    float generar_random(float max, float min)
    {
        return(Random.Range(min, max));
    }

    // Start is called before the first frame update
    void Start()
    {

        //Crear mapa
        for(int i = 0; i < 21; i ++)
        {
           pisos.Add(Instantiate(piso, new Vector2(-10 + i, -3.77f), Quaternion.identity));
           //Instantiate(piso, new Vector2(-10 + i, -3.77f), Quaternion.identity);

        }

        for(int i = 0; i < 3; i ++)
        {

           pipes.Add(Instantiate(pipe, new Vector2(8 + i*8, generar_random(3f, -2)), Quaternion.identity));

        }
    }

    // Update is called once per frame
    void Update() {

        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X)) 
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {

            menuGameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X)) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    
        if (start == true && gameOver == false)
        {

            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f,0) * Time.deltaTime;   

            for(int i = 0; i < pisos.Count; i ++)
            {
                if (pisos[i].transform.position.x <= -10)
                {
                    pisos[i].transform.position = new Vector3(10, -3.77f, 0);
                }
            pisos[i].transform.position = pisos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;   
            } 


            for(int i = 0; i < pipes.Count; i ++)
            {
                if (pipes[i].transform.position.x <= -10)
                {
                    pipes[i].transform.position = new Vector3(14, generar_random(3f, -2), 0);
                }
            pipes[i].transform.position = pipes[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;   
            } 

        }

    }

}
