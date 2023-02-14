using Raylib_cs;

Engine e;

Setup();
Draw();

void Setup()
{
    Raylib.SetTargetFPS(30);
    Raylib.InitWindow(800, 800, "Game");
    e = new();
}

void Draw()
{
    while (!Raylib.WindowShouldClose())
    {
        e.Run();
    }
}