using RestSharp;
using Raylib_cs;
using System.Net;

public class Engine
{
    // RestClient client = new RestClient("http://10.151.169.12:3000")
    // {

    // };
    RestClient client = new RestClient("http://2.249.166.70:3000")
    {

    };

    static string paul = "/Paul";
    static string samuel = "/Samuel";


    public bool isSamuel = false;

    Player Samuel = new(true);
    Player Paul = new(false);

    public Engine()
    {
        // while (true)
        // {
        //     Raylib.BeginDrawing();
        //     Raylib.ClearBackground(Color.WHITE);

        //     Raylib.DrawText("Click LMB for Samuel\nClick RMB for Paul", 100, 100, 24, Color.RED);

        //     Raylib.EndDrawing();

        //     if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        //     {
        //         isSamuel = true;
        //         return;
        //     }
        //     else if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
        //     {
        //         isSamuel = false;
        //         return;
        //     }
        // }

        ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

        isSamuel = true;
    }

    public void Run()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.WHITE);

        Paul.Render();
        Samuel.Render();

        Raylib.EndDrawing();

        if (isSamuel)
        {
            Samuel.UpdateLocal(ref client, samuel);
            Paul.UpdateOnline(ref client, paul);
        }
        else
        {
            Samuel.UpdateOnline(ref client, samuel);
            Paul.UpdateLocal(ref client, paul);
        }
    }
}
