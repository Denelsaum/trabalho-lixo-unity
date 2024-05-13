using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurarEPegarObjetos : MonoBehaviour
{
    public float distanciaMaxima = 2000.0f;

    public LayerMask layer;

    public List<string> tagsObjetosSeguraveis;

    public List<string> tagsObjetosPegaveis;

    public List<Transform> posicoesMao;

    private bool segurando = false;

    private Transform objeto;




    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            segurando = false;
        }


        if (segurando)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                segurando = false;
            }

            int index = 0;
            objeto.position = posicoesMao[index].position;
            objeto.rotation = posicoesMao[index].rotation;
        }
        else
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaMaxima, layer, QueryTriggerInteraction.Ignore))
            {
                if (Input.GetMouseButton(0))
                {
                    string tagObjeto = tagsObjetosPegaveis.Find((tag) => {
                        if (hit.transform.gameObject.tag == tag)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });

                    if (tagObjeto != null)
                    {
                        segurando = true;
                        objeto = hit.transform;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    string tagObjeto = tagsObjetosSeguraveis.Find((tag) => {
                        if (hit.transform.gameObject.tag == tag)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });

                    if (tagObjeto != null)
                    {
                        segurando = true;
                        objeto = hit.transform;
                    }
                }

            }
        }
    }
}