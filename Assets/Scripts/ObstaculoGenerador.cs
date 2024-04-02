using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoGenerador : MonoBehaviour
{
    public GameObject[] obstaculos; // Array de prefabs de obstáculos
    public float tiempoEntreGeneracion = 1.5f; // Tiempo entre generación de obstáculos
    public Transform[] posicionesGeneracion; // Posiciones en las que se generarán los obstáculos
    public float alturaGeneracion = 20f; // Altura desde la cual se generarán los obstáculos
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del generador en el eje X y Z


    void Start()
    {
        // Comenzar a generar obstáculos de manera aleatoria
        StartCoroutine(GenerarObstaculos());
        // Iniciar el movimiento aleatorio del generador
        StartCoroutine(MoverGenerador());
    }

    IEnumerator GenerarObstaculos()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio antes de generar el siguiente obstáculo
            yield return new WaitForSeconds(Random.Range(0.5f, tiempoEntreGeneracion));

            // Seleccionar una posición aleatoria de generación
            Transform posicionGeneracion = posicionesGeneracion[Random.Range(0, posicionesGeneracion.Length)];

            // Generar un obstáculo aleatorio en la posición de generación
            GameObject obstaculoAleatorio = obstaculos[Random.Range(0, obstaculos.Length)];
            Instantiate(obstaculoAleatorio, posicionGeneracion.position + Vector3.up * alturaGeneracion, Quaternion.identity);
        }
    }

    IEnumerator MoverGenerador()
    {
        while (true)
        {
            // Calcular una dirección de movimiento aleatoria en el plano XZ
            Vector3 direccionMovimiento = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            // Mover el generador en la dirección calculada
            transform.position += direccionMovimiento * velocidadMovimiento * Time.deltaTime;

            // Esperar un momento antes de calcular la siguiente dirección de movimiento
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }
}