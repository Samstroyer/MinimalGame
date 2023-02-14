using System.Text.Json;
using RestSharp;
using Raylib_cs;

public class Player
{
    Position pos = new();
    bool isSamuel;

    static string get = "/Get";
    static string set = "/Set";

    public Player(bool player)
    {
        isSamuel = player;
        pos = new()
        {
            X = 100,
            Y = 100
        };
    }

    public void UpdateLocal(ref RestClient client, string player)
    {
        // KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) pos.Y -= 5;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) pos.Y += 5;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) pos.X += 5;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) pos.X -= 5;

        var req = new RestRequest($"{player}/Set");
        var body = new Position { X = (int)pos.X, Y = (int)pos.Y };

        req.AddJsonBody(body);

        var response = client.Post(req).Content;
        Console.WriteLine(response);
    }

    public void Render()
    {
        Raylib.DrawCircle(pos.X, pos.Y, 10, Color.BLUE);
    }

    public void UpdateOnline(ref RestClient client, string player)
    {
        RestResponse test = client.GetAsync(new(player + get)).Result;
        Position p = JsonSerializer.Deserialize<Position>(test.Content);

        pos.X = p.X;
        pos.Y = p.Y;
    }
}
