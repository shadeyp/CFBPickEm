
using Android.App;
using Android.OS;
using Android.Widget;
using CFBPickEm.Core.Model;
using CFBPickEm.Core.Service;
using CFBPickEm.Utility;

namespace CFBPickEm
{
    [Activity(Label = "Team Detail", MainLauncher =true)]
    public class TeamDetailActivity : Activity
    {
        private ImageView teamDetailImageView;
        private TextView teamName;
        private TextView teamNickName;

        private Team selectedTeam;
        private CFBDataService cfbDataService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TeamDetailView);

            CFBDataService cfbDataService = new CFBDataService();
            selectedTeam = cfbDataService.GetTeamById(1);

            FindViews();
            BindData();
        }

        private void BindData()
        {
            teamName.Text = selectedTeam.TeamName;
            teamNickName.Text = selectedTeam.TeamNickName;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://a.espncdn.com/combiner/i?img=/i/teamlogos/ncaa/500/158.png&w=100&h=100&transparent=true");
            teamDetailImageView.SetImageBitmap(imageBitmap);
        }

        private void FindViews()
        {
            teamDetailImageView = FindViewById<ImageView>(Resource.Id.teamDetailImageView);
            teamNickName = FindViewById<TextView>(Resource.Id.TeamNickNameTextView);
            teamName = FindViewById<TextView>(Resource.Id.TeamNameTextView);
        }
    }
}