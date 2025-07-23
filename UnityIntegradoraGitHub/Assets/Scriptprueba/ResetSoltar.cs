using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ResetAfterDelay : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private XRGrabInteractable grabInteractable;
    private Coroutine resetCoroutine;

    void Start()
    {
        // Guardar la posición y rotación inicial
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Obtener el componente XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            // 🔧 Desactivar el lanzamiento al soltar para evitar error con XRGazeAssistance
            grabInteractable.throwOnDetach = false;

            // Suscribirse al evento de soltado
            grabInteractable.selectExited.AddListener(OnRelease);
        }
        else
        {
            Debug.LogError("Falta XRGrabInteractable en " + gameObject.name);
        }
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }

        resetCoroutine = StartCoroutine(ResetAfterSeconds(3f));
    }

    private IEnumerator ResetAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        yield return null; // Esperar un frame extra

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Primero detener movimiento
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Luego poner en modo cinemático
            rb.isKinematic = true;
        }

        // Restaurar posición y rotación
        transform.SetPositionAndRotation(initialPosition, initialRotation);

        yield return null; // Esperar otro frame

        if (rb != null)
        {
            // Reactivar física
            rb.isKinematic = false;
        }
    }
}
