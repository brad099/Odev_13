using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FloatingJoystick joystick;
    [SerializeField] float Speed;
    [SerializeField] Transform detectTransform;
    [SerializeField] Transform holdTransform;
    [SerializeField] Transform dropZoneTransform;
    [SerializeField] float DetectionRange = 1f;
    [SerializeField] float ItemDistanceBetween = 0.5f;
    [SerializeField] float SmoothTurnTime = 0.1f;
    [SerializeField] LayerMask layer;
    private Rigidbody rb;
    Vector3 direction;
    float Horizontal;
    float Vertical;
    private int itemplyCount;
    private int itemstoCount;
    float CurrentTurnAngle;
    Collider[] colliders;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectTransform.position, DetectionRange);
    }

    private void Update()
    {
        {
            colliders = Physics.OverlapSphere(detectTransform.position, DetectionRange, layer);
            foreach (var hit in colliders)
            {
                if (hit.CompareTag("Collectable"))
                {
                    hit.tag = "Collected";
                    hit.transform.parent = holdTransform;
                    var seq = DOTween.Sequence();
                    seq.Append(hit.transform.DOLocalJump(new Vector3(0, itemplyCount * ItemDistanceBetween, 0), 2, 1, 0.2f).
                        Join(hit.transform.DOScale(1.25f, 0.1f)).Insert(0.1f, hit.transform.DOScale(1f, 0.1f)));
                    seq.AppendCallback(() => { hit.transform.localRotation = Quaternion.Euler(0, 0, 0); });
                    itemplyCount++;
                }
                if (hit.CompareTag("Dropzone"))
                {
                    foreach (Transform obs in holdTransform)
                    {
                        obs.transform.parent = dropZoneTransform;
                        var seq = DOTween.Sequence();
                        seq.Append(obs.transform.DOLocalJump(new Vector3(0, itemstoCount * ItemDistanceBetween, 0), 2, 1, 0.5f).
                            Join(obs.transform.DOScale(1.25f, 0.1f)).
                            Insert(0.1f, obs.transform.DOScale(1f, 0.1f)));
                        seq.AppendCallback(() => { obs.transform.localRotation = Quaternion.Euler(0, 0, 0); });
                        itemstoCount++;
                        if (hit.CompareTag("Dropzone"))
                        {
                            itemplyCount = 0;
                        }
                    }
                }
            }
        }
    }


    //Moving
    private void FixedUpdate()
    {
        //Horizontal = Input.GetAxis("Horizontal");
        Horizontal = joystick.Horizontal;
        // = Input.GetAxis("Vertical");
        Vertical = joystick.Vertical;
        direction = new Vector3(Horizontal, 0, Vertical);
        if (direction.magnitude > 0.01f)
        {
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref CurrentTurnAngle, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0, Angle, 0);
            rb.MovePosition(transform.position + (direction * Speed * Time.deltaTime));
        }
    }
}



