
using Android.App;
using Android.OS;
using Android.Widget;
using CFBPickEm.Core.Model;
using CFBPickEm.Core.Service;
using CFBPickEm.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CFBPickEm
{
    [Activity(Label = "Team Detail", MainLauncher =true)]
    public class TeamDetailActivity : Activity
    {
        private ImageView teamDetailImageView;
        private TextView teamName;
        private TextView teamNickName;
        private Spinner conferenceSpinner;
        private Spinner teamSpinner;

        private Team selectedTeam;
        private List<Team> teams;
        private List<Conference> conferences;
        private Conference selectedConference;
        private CFBDataService cfbDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TeamDetailView);

            CFBDataService cfbDataService = new CFBDataService();
            selectedTeam = cfbDataService.GetTeamById(1);         
            conferences = cfbDataService.GetConferences();

            FindViews();
            BindData();
            SetEvents();
        }

        private void BindData()
        {
            teamName.Text = selectedTeam.TeamName;
            teamNickName.Text = selectedTeam.TeamNickName;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://a.espncdn.com/combiner/i?img=/i/teamlogos/ncaa/500/158.png&w=100&h=100&transparent=true");
            teamDetailImageView.SetImageBitmap(imageBitmap);

            //var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, 
            //    conferences.Select(c => c.ConferenceName).ToList());
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem,
                conferences);
            conferenceSpinner.Adapter = adapter;
        }

        private void SetEvents()
        {
            conferenceSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(ConferenceSpinner_ItemSelected);
        }

        private void ConferenceSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            var confId = spinner.GetItemAtPosition(e.Position).Cast<Conference>();
            CFBDataService cfbDataService = new CFBDataService();
            teams = cfbDataService.GetTeamsForConference(confId.ConferenceId);

            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem,
                teams);
            teamSpinner.Adapter = adapter;
        }

        private void FindViews()
        {
            teamDetailImageView = FindViewById<ImageView>(Resource.Id.teamDetailImageView);
            teamNickName = FindViewById<TextView>(Resource.Id.TeamNickNameTextView);
            teamName = FindViewById<TextView>(Resource.Id.TeamNameTextView);
            conferenceSpinner = FindViewById<Spinner>(Resource.Id.conferenceSpinner);
            teamSpinner = FindViewById<Spinner>(Resource.Id.teamSpinner);
        }
    }

    public static class ObjectTypeHelper {
        public static T Cast<T>(this Java.Lang.Object obj) where T : class {
            var propertyInfo = obj.GetType().GetProperty("Instance");
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
        }
    }
}