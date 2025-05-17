using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace UserInterface
{
    public class UIStageClear : UIBase
    {
        [SerializeField] private RectTransform rouletteRectTransform;
        [SerializeField] private RectTransform arrowRectTransform;

        private float _rouletteMaxX;
        private float _rouletteMinX;
        
        private void Awake()
        {
            _rouletteMaxX = rouletteRectTransform.rect.xMax;
            _rouletteMinX = rouletteRectTransform.rect.xMin;
            
            MoveMaxX();
        }

        void Start()
        {

        }

        void Update()
        {

        }
        
        private void MoveMaxX()
        {
            arrowRectTransform.DOLocalMoveX(_rouletteMaxX, 1f).OnComplete(MoveMinX);
        }

        private void MoveMinX()
        {
            arrowRectTransform.DOLocalMoveX(_rouletteMinX, 1f).OnComplete(MoveMaxX);
        }
    }
}