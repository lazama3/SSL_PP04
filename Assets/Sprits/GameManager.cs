using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public GameObject piso;
    public GameObject pipe;
    
    public float velocidad = 5;

    public List<GameObject> pisos;
    public List<GameObject> pipes;

    // Start is called before the first frame update
    void Start()
    {

        //Crear mapa
        for(int i = 0; i < 21; i ++)
        {
           pisos.Add(Instantiate(piso, new Vector2(-10 + i, -3.77f), Quaternion.identity));
           //Instantiate(piso, new Vector2(-10 + i, -3.77f), Quaternion.identity);

        }

        for(int i = 0; i < 4; i ++)
        {

           pipes.Add(Instantiate(pipe, new Vector2(8 + i*8, Random.Range(2, 4)), Quaternion.identity));

        }
    }

    // Update is called once per frame
    void Update()
    {
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
                pipes[i].transform.position = new Vector3(18, Random.Range(2, 4), 0);
            }
           pipes[i].transform.position = pipes[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;   
        } 
    }
}
