using UnityEngine;
using System.Collections;
using System.Xml.Schema;

namespace RTS
{
    public static class ResourceManager
    {
        private static int _scrollWidth = 15;
        public static int ScrollWidth { get { return _scrollWidth; } }

        private static float _horizontalScrollSpeed = 25;
        public static float HorizontalScrollSpeed { get { return _horizontalScrollSpeed; } }

        private static float _verticalScrollSpeed = 50;
        public static float VerticalScrollSpeed { get { return _verticalScrollSpeed; } }

        private static float _rotateAmount = 10;
        public static float RotateAmount { get { return _rotateAmount; } }

        private static float _rotateSpeed = 100;
        public static float RotateSpeed { get { return _rotateSpeed; } }

        private static float _minCameraHeight = 10;
        public static float MinCameraHeight { get { return _minCameraHeight; } }

        private static float _maxCameraheight = 40;
        public static float MaxCameraHeight { get { return _maxCameraheight; } }
    }
}