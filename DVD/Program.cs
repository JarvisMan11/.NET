using Raylib_cs;
using System.Numerics;

namespace DVD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 800, "DVD");
            int height = Raylib.GetScreenHeight();
            int width = Raylib.GetScreenWidth();
            int nextColorIndex = 0;
            var color = Color.Yellow;
            var variLista = new List<Color> { Color.Yellow, Color.Purple, Color.Red };
            Vector2 centerOfTheScreen = new Vector2(width / 2, height / 2);

            Vector2 textPosition = new Vector2(centerOfTheScreen.X, centerOfTheScreen.Y);
            Vector2 textDirection = new Vector2(1, 0.5f);
            float speed = 100.0f;

            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.Black);
                textPosition = textPosition + textDirection * speed * Raylib.GetFrameTime();
                Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), "DVD", 36, 1);
                Vector2 adjustedTextPosition = new Vector2(textPosition.X - textSize.X / 2, textPosition.Y - textSize.Y / 2);
                Raylib.DrawTextEx(Raylib.GetFontDefault(), "DVD", adjustedTextPosition, 36, 1, color);


                if (textPosition.X - textSize.X / 2 < 1 || textPosition.X + textSize.X / 2 > 799)
                {
                    nextColorIndex++;
                    if (nextColorIndex > 2)
                    {
                        nextColorIndex = 0;
                    }
                    color = variLista[nextColorIndex];
                    textDirection.X *= -1;
                    speed += 10f;
                }
                if (textPosition.Y - textSize.Y / 2 < 1 || textPosition.Y + textSize.Y / 2 > 799)
                {
                    nextColorIndex++;
                    if(nextColorIndex > 2)
                    {
                        nextColorIndex = 0;
                    }
                    color = variLista[nextColorIndex];
                    textDirection.Y *= -1;
                    speed += 10f;
                }
                Raylib.EndDrawing();
            }
        }
    }
}
