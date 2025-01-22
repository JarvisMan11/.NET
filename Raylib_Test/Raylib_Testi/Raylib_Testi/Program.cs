using Raylib_cs;
using System.Numerics;

class Program
{
    static void Main()
    {
        // IKKUNAN ALUSTAMINEN
        Raylib.InitWindow(800, 800, "Näytönsäästäjä");
        Raylib.SetTargetFPS(240);

        // PISTEET A, B JA C
        Vector2 A = new Vector2(400, 0);
        Vector2 B = new Vector2(0, 400);
        Vector2 C = new Vector2(800, 600);

        // SUUNTAVEKTORIT
        Vector2 directionA = new Vector2(1, 1);
        Vector2 directionB = new Vector2(1, -1);
        Vector2 directionC = new Vector2(-1, 1);

        // NOPEUS
        float speed = 50.0F;

        // PELI IKKUNAN PÄIVITYSSILMUKKA
        while (!Raylib.WindowShouldClose())
        {
            // PISTEIDEN LIIKUTUS
            A = A + directionA * speed * Raylib.GetFrameTime();
            B = B + directionB * speed * Raylib.GetFrameTime();
            C = C + directionC * speed * Raylib.GetFrameTime();

            if (A.X < 0 || A.X > Raylib.GetScreenWidth()) directionA.X *= -1;
            if (A.Y < 0 || A.Y > Raylib.GetScreenHeight()) directionA.Y *= -1;

            if (B.X < 0 || B.X > Raylib.GetScreenWidth()) directionB.X *= -1;
            if (B.Y < 0 || B.Y > Raylib.GetScreenHeight()) directionB.Y *= -1;

            if (C.X < 0 || C.X > Raylib.GetScreenWidth()) directionC.X *= -1;
            if (C.Y < 0 || C.Y > Raylib.GetScreenHeight()) directionC.Y *= -1;

            // PELIRUUDUN PIIRTÄMINEN
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // VIIVAT PISTEIDEN VÄLIIN
            Raylib.DrawLineV(A, B, Color.Green);
            Raylib.DrawLineV(B, C, Color.Yellow);
            Raylib.DrawLineV(C, A, Color.Blue);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow(); 
    }
}