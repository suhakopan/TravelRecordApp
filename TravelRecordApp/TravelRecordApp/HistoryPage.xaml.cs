using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*SQLite codes
             * using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            { 
                
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                postLisView.ItemsSource = posts;
            } */

            var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();
            postLisView.ItemsSource = posts;
        }

        private void postLisView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postLisView.SelectedItem as Post;

            if(selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
    }
}