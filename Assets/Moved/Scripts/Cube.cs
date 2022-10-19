using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    // [SerializeField]float Xpos;
    // [SerializeField]float Ypos;
    // [SerializeField]float Zpos;
    // [SerializeField]float AnimationDuration;
    // [SerializeField]Vector3 Pos;
    // [SerializeField]Vector3 EndPos;
    // [SerializeField]Ease ease;
    // [SerializeField]AnimationCurve curve;
    void Start()
    {
        // transform.DOMoveX(Xpos,AnimationDuration);
        // transform.DOMoveY(Ypos,AnimationDuration);
        // transform.DOMoveZ(Zpos,AnimationDuration);

        // transform.DOMove(Pos,AnimationDuration);

        // transform.DOLocalMove(Pos,AnimationDuration);

        //transform.DORotate(new Vector3(30,60,90),AnimationDuration);
        //transform.DOScale(new Vector3(3,5,7),AnimationDuration);
        //transform.DOJump(EndPos,10,1,AnimationDuration).SetLoops(2,LoopType.Incremental);

        // transform.DOScale(2,AnimationDuration).SetLoops(3,LoopType.Yoyo);
        // transform.DOScale(2,AnimationDuration).SetLoops(3,LoopType.Restart);
        // transform.DOScale(2,AnimationDuration).SetLoops(3,LoopType.Incremental);

        // transform.DOMoveX(Xpos,AnimationDuration).SetLoops(2,LoopType.Restart).SetEase(ease);
        // transform.DOMoveX(Xpos,AnimationDuration).OnComplete(() =>
        // {
        //     transform.DOMoveY(Ypos,AnimationDuration).OnComplete(() =>
        // {
        //       transform.DOMoveX(Xpos,AnimationDuration).OnComplete(() =>
        // {
        //         transform.DOMoveY(0,AnimationDuration);
        //       });
        //     });
        // });

         var seq = DOTween.Sequence();

        // seq.Append(transform.DOMoveX(5,1));
        // seq.Append(transform.DOMoveY(5,1));
        // seq.Append(transform.DOMoveX(-5,1));
        // seq.Append(transform.DOMoveY(0,1));

        // seq.SetLoops(-1,LoopType.Restart);

        // seq.Append(transform.DOMoveX(5,2)).Join(transform.DORotate(new Vector3(180,0,0),2));
        // seq.SetLoops(-1,LoopType.Yoyo);
        // seq.Append(transform.DOMoveX(5,5)).Insert(2,transform.DORotate(new Vector3(0,0,180),2));
        // seq.SetLoops(-1,LoopType.Yoyo);
        // seq.Append(transform.DOMoveY(5,3)).Insert(0.5f,transform.DOMoveX(5,1)).Insert(1.5f,transform.DOMoveX(-5,1)).Insert(2.5f,transform.DOMoveX(0,1));
        
        // seq.Append(transform.DOMoveX(5,1));
        // seq.AppendCallback(() =>
        //  {
        //      Debug.Log(transform.position);
        //  });
        // seq.Append(transform.DOMoveY(5,1));
        // seq.AppendCallback(() =>
        //  {
        //      Debug.Log(transform.position);
        //  });
        // seq.Append(transform.DOMoveX(-5,1));
        // seq.AppendCallback(() =>
        //  {
        //      Debug.Log(transform.position);
        //  });
        // seq.Append(transform.DOMoveY(0,1));
        // seq.AppendCallback(() =>
        //  {
        //      Debug.Log(transform.position);
        //  });

        // seq.Append(transform.DOMoveX(5,5)).InsertCallback(2,()=>
        // {
        //     transform.DORotate(new Vector3(0,0,90),0.5f).SetLoops(-1,LoopType.Yoyo);
        //     Debug.Log(transform.position);
        // });
        seq.AppendCallback(() => {Debug.Log("Bekeleiyio"); });
        seq.AppendInterval(2);
        seq.AppendCallback(() => {Debug.Log("Bekeleiyio bitdi"); });
        seq.Append(transform.DOMoveX(5,2));
        seq.AppendInterval(2);
        seq.Append(transform.DOMoveY(5,2));
        seq.AppendInterval(2);
        seq.Append(transform.DOMoveX(-5,2));
        seq.AppendInterval(2);
        seq.Append(transform.DOMoveY(0,2));
        seq.SetLoops(-1,LoopType.Yoyo);
    }
    // private void OnMouseDown()
    // {
    //     transform.DOShakeScale(2f,1);
    //     transform.DOShakePosition(0.5f,1);
    // }
}

