using System.Text.Json;
using RestSharp;
using Raylib_cs;

public class Player
{
    Position pos = new();
    bool isSamuel;

    // static string get = "/Get";
    // static string set = "/Set";

    public Player(bool player)
    {
        isSamuel = player;
        pos = new()
        {
            x = 100,
            y = 100
        };
    }

    public void UpdateLocal(ref RestClient client, string player)
    {
        // KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) pos.y -= 5;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) pos.y += 5;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) pos.x += 5;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) pos.x -= 5;

        var req = new RestRequest($"{player}/Set");
        var body = new Position { x = (int)pos.x, y = (int)pos.y };

        req.AddJsonBody(body);

        var response = client.PostAsync(req);
        System.Console.WriteLine(response);
    }

    public void Render()
    {
        Raylib.DrawCircle(pos.x, pos.y, 10, Color.BLUE);
    }

    public void UpdateOnline(ref RestClient client, string player)
    {
        RestRequest rr = new($"{player}/Get", Method.Get);

        RestResponse test = client.GetAsync(rr).Result;

        Position p = JsonSerializer.Deserialize<Position>(test.Content);

        pos = p;
    }
}
