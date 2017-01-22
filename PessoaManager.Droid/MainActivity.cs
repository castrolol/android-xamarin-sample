using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;
using System;
using System.Net;
using Android.Graphics.Drawables;
using Android.Graphics;
using System.Threading.Tasks;
using Android.Support.V7.App;
using Newtonsoft.Json;

[assembly: Application(Theme = "@style/Theme.AppCompat.Light")]
namespace PessoaManager.Droid
{
    [Activity(Label = "Pessoa Manager", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {

         TextView nomeText;
        TextView loginText;
        TextView followersText;
        TextView followingText;
        ImageView avatarImage;

        ProgressDialog progresDialog;

         //PessoaArrayAdapter meuArrayBom;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            progresDialog = new ProgressDialog(this);
            progresDialog.Indeterminate = true;
            progresDialog.SetMessage("Buscando...D:");

            SupportActionBar.SetBackgroundDrawable(new ColorDrawable(Color.Argb(255, 63, 74, 220)));
            SupportActionBar.SetWindowTitle("Github Serach");
                                                   

            nomeText = FindViewById<TextView>(Resource.Id.nome_text);
            loginText = FindViewById<TextView>(Resource.Id.login_text);
            followersText = FindViewById<TextView>(Resource.Id.followers_text);
            followingText = FindViewById<TextView>(Resource.Id.following_text);
            avatarImage = FindViewById<ImageView>(Resource.Id.avatar_image);
 

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MainMenu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.ItemId == Resource.Id.buscar_github)
            {
                MostrarJanelaBuscar();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        void MostrarJanelaBuscar()
        {
            var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
            var view = LayoutInflater.Inflate(Resource.Layout.Dialog, null);
            var textView = view.FindViewById<TextView>(Resource.Id.busca_text);
            builder.SetView(view);

            builder.SetPositiveButton("Ok", async (sender, e) =>
            {

                await BuscarUser(textView.Text);

            });

            builder.Show();

        }

        async Task BuscarUser(string text)
        {
            progresDialog.Show();


            var client = new WebClient
            {
               
            };


            client.Headers.Add(HttpRequestHeader.UserAgent, "Awesome-DUDU-App");

            var json = await client.DownloadStringTaskAsync($"https://api.github.com/users/{text}");

            var user = JsonConvert.DeserializeObject<User>(json);

            await PreencheUsuario(user);
            progresDialog.Hide();

        }

        async Task PreencheUsuario(User user)
        {

            nomeText.Text = user.Name;
            loginText.Text = user.Login;
            followersText.Text = user.Followers.ToString();
            followingText.Text = user.Following.ToString();

            await DownloadImage(user);

        }

        async Task DownloadImage(User user)
        {

            var url = user.AvatarUrl;

            var client = new WebClient();

            var bytes = await client.DownloadDataTaskAsync(new Uri(url));


            Drawable image = new BitmapDrawable(BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length));

            avatarImage.SetImageDrawable(image);

        }
    }
}

