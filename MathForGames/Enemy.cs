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
        private Player _player;
        private Vector2 _velocity;

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

        public Enemy(char icon, float x, float y, Color color, float speed, Player player, string name)
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _player = player;
        }

        public override void Update(float deltaTime)
        {

            Vector2 enemyDistance = _player.Position - Position;

            Velocity = enemyDistance.Normalized * _speed * deltaTime;

            Position += Velocity;

            base.Update(deltaTime);

            Console.WriteLine("hey");

        }
    }
}
