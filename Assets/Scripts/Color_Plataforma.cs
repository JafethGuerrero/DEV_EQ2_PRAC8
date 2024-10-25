using System.Collections;
using UnityEngine;
using TMPro;

public class Color_Plataforma : MonoBehaviour
{
    // Referencias a los cubos y sus posiciones iniciales
    public GameObject CVerde, CAzul, CAmarillo;
    private Vector3 CVerdeInitialPos, CAzulInitialPos, CAmarilloInitialPos;
    private Vector3 CVerdeInitialScale, CAzulInitialScale, CAmarilloInitialScale;

    // Colores
    private string[] colores = { "Verde", "Amarillo", "Azul" };
    private string colorActual;

    // TextMeshPro para mostrar el color objetivo
    public TextMeshProUGUI colorText;

    // Renderer de la plataforma
    private Renderer plataformaRenderer;

    void Start()
    {
        // Guardar posiciones y escalas iniciales de los cubos
        CVerdeInitialPos = CVerde.transform.position;
        CAzulInitialPos = CAzul.transform.position;
        CAmarilloInitialPos = CAmarillo.transform.position;

        CVerdeInitialScale = CVerde.transform.localScale;
        CAzulInitialScale = CAzul.transform.localScale;
        CAmarilloInitialScale = CAmarillo.transform.localScale;

        // Obtener el Renderer de la plataforma
        plataformaRenderer = GetComponent<Renderer>();

        // Seleccionar el primer color aleatorio
        SeleccionarColorAleatorio();
    }

    void SeleccionarColorAleatorio()
    {
        // Seleccionar un color aleatorio como objetivo
        int index = Random.Range(0, colores.Length);
        colorActual = colores[index];

        // Mostrar el color objetivo en el TextMeshPro
        colorText.text = "Color a buscar: " + colorActual;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró en el trigger es uno de los cubos
        if (other.gameObject == CVerde || other.gameObject == CAzul || other.gameObject == CAmarillo)
        {
            VerificarCubo(other.gameObject);
        }
    }

    void VerificarCubo(GameObject cubo)
    {
        // Verificar si el nombre del cubo coincide con el color objetivo
        if (cubo.name == "C" + colorActual)
        {
            // Cambiar el color de la plataforma al color del cubo correcto
            switch (colorActual)
            {
                case "Verde":
                    plataformaRenderer.material.color = Color.green;
                    break;
                case "Amarillo":
                    plataformaRenderer.material.color = Color.yellow;
                    break;
                case "Azul":
                    plataformaRenderer.material.color = Color.blue;
                    break;
            }
        }

        // Siempre resetear el cubo a su posición y escala originales
        ResetCubo(cubo);

        // Seleccionar un nuevo color objetivo después de verificar
        SeleccionarColorAleatorio();
    }

    void ResetCubo(GameObject cubo)
    {
        // Regresar el cubo a su posición y escala iniciales y restaurar su color
        if (cubo == CVerde)
        {
            cubo.transform.position = CVerdeInitialPos;
            cubo.transform.localScale = CVerdeInitialScale;
            cubo.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (cubo == CAzul)
        {
            cubo.transform.position = CAzulInitialPos;
            cubo.transform.localScale = CAzulInitialScale;
            cubo.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (cubo == CAmarillo)
        {
            cubo.transform.position = CAmarilloInitialPos;
            cubo.transform.localScale = CAmarilloInitialScale;
            cubo.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
