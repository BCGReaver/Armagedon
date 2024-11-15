using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArcangelHealt : MonoBehaviour
{
    [SerializeField] private Image Heart = null;
    private int _MaxHealth = 1, _Health = 1;

    [SerializeField] private ArcangelController _movementScript = null;   //AQUIIIIIIIIIIIIIIIIIIIIIII ME QUEDEEEEEEEEEEEEEEEE

    [SerializeField] private 

    // Start is called before the first frame update
    void Start()
    {
        _Health = _MaxHealth;
    }

    private void OnBecameInvisible()
    {
        if (_Health > 0) ;
        Invoke(nameof(GameOver), 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Proyectil"))
        {
            GetDamage(collision.gameObject);
        }
    }

    void GetDamage(GameObject _Proyectil)
    {
        Destroy(_Proyectil);

        if(_Health > 0)
        {
            _Health--;
            SetHearts();
            if(_Health <= 0)
            {
                Die();
            }
        }
    }

    void SetHearts()
    {
        if (_Health == 1)
        {
            Heart.enabled = true;
        }
        else if(_Health == 0)
        {
            Heart.enabled = false;
        }
    }

    void Die()
    {
        print("Murido");
    }

    void GameOver()
    {
        print("Game over");
    }
}
