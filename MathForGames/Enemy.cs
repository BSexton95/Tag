using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Actor _target;

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Enemy(char icon, float x, float y, Color color, float speed, Actor target, string name)
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _target = target;
        }

        public override void Update(float deltaTime)
        {

            Vector2 enemyDistance = (_target.Position - Position).Normalized;

            Velocity = enemyDistance * _speed * deltaTime;

            if(GetTargetInSight() && Vector2.Distance( Position, _target.Position) < 200 )
                Position += Velocity;

            base.Update(deltaTime);
        }

        public bool GetTargetInSight()
        {
            Vector2 directionOfTarget = (_target.Position - Position).Normalized;

            return Vector2.DotProduct(directionOfTarget, Forward) > 0.5;
        }
    }
}
