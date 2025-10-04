using System.Numerics;
using Raylib_cs;

namespace FlappyBird
{
    public class Bird
    {
        // Felder
        private Vector2 position;
        private Vector2 velocity; // X , Y -> höhe
        private float gravity;
        private const float flapStrength = -8.0f;
        private const int size = 20;
        private const float maxVelocity = 10.0f;

        public Vector2 Position => position;
        
        // Konstruktor
        public Bird(Vector2 startPosition, float gravity){
            this.position = startPosition;
            this.gravity = gravity;
            this.velocity = new Vector2(0,0);
        }
        
        // TODO: Update() Methode
        public void Update(){
            velocity.Y += gravity;
            position += velocity;

            if (velocity.Y > maxVelocity){
                velocity.Y = maxVelocity;
            }
            if(position.Y < 0){
                position.Y = 0;
                velocity.Y = 0;
            }
        }
        
        // Draw() Methode
        public void Draw(){
            Raylib.DrawCircleV(position, size, Color.Yellow);
        }
        
        // Flap() Methode
        public void Flap(){
            velocity.Y = flapStrength;
        }
        
        // CheckCollisionWithGround() Methode
        public bool CheckCollisionWithGround(int screenHeight){
            return position.Y + size > screenHeight;
        }
    }
}