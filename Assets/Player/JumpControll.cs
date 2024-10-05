using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControll : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField, Range(0.5f, 1f)] private float MinNormalY;

    public bool Grounded { get; private set; }
    private bool _jumped;
    private bool _jumpedFlag;

    [SerializeField] private float jumpStrenght;
    [SerializeField] private float jumpMaxTime;
    [SerializeField] private int punchCount;
    [SerializeField] private float buffMultlipier;
    private Vector2 jumpSpeedVector;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Collision")) 
        {
            foreach (var i in collision.contacts)
            {
                if (i.normal.y >= MinNormalY)
                {
                    Grounded = true;
                    break;
                }
            } 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Collision"))
            Grounded = false;
    }

    public void ChangeJumpState(bool state) => _jumped = (Grounded && state);

    private void Update()
    {
        if (_jumped != _jumpedFlag)
        {
            _jumpedFlag = _jumped;

            jumpSpeedVector.y = jumpStrenght;

            if (_jumped == true)
            {
                _rigidbody2D.velocity += jumpSpeedVector;
                StartCoroutine(JumpBuffing());
            }
        }
    }

    private IEnumerator JumpBuffing()
    {
        float buffingStr = jumpStrenght;

        for (int i = 0; i < punchCount; i++)
        {
            buffingStr *= buffMultlipier;

            jumpSpeedVector.y = buffingStr;

            yield return new WaitForSeconds(jumpMaxTime / punchCount);

            if (_jumped == false) yield break;

            _rigidbody2D.velocity += jumpSpeedVector;
        }

        yield break;
    }
}
