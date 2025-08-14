using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private GameObject Huevo;
    [SerializeField] private float tiempoHuevo;
    public float tiempoSiguienteHuevo;


    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        girar();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteHuevo += Time.deltaTime;
        if (tiempoSiguienteHuevo >= tiempoHuevo)
        {
            tiempoSiguienteHuevo = 0;
            PonerHuevo();
        }
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
            girar();
        }
    }
    private void girar()
    {
        if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void PonerHuevo()
    {
        Instantiate(Huevo, transform.position, Quaternion.identity);
    }
}
