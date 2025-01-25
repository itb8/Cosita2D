using UnityEngine;

public class Rubbish : MonoBehaviour
{
    public int points = -1;
    public GameManager gameMan;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.layer);

        switch (collision.gameObject.layer)
        {
            case 9:
                gameMan.rubbishSound();
                Invoke(nameof(Despawn), 0.25f);
                break;
            case 10:
                gameMan.rubbishSound();
                Invoke(nameof(Despawn), 0.25f);
                break;
            case 11:
                gameMan.rubbishSound();
                Invoke(nameof(Despawn), 0.25f);
                break;
            case 12:
                //gameMan.addCrabPoints(points); METODO DE MOVER AL REVES EL JUGADOR 1 5 SEC
                gameMan.rubbishSound();
                Invoke(nameof(Despawn), 0f);
                break;
            case 13:
                //gameMan.addOctoPoints(points); METODO DE MOVER AL REVES EL JUGADOR 2 5 SEC
                gameMan.rubbishSound();
                Invoke(nameof(Despawn), 0f);
                break;
            default:
                break;
        }
    }

    private void Despawn()
    {
        this.gameObject.SetActive(false);
    }
}
