
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

            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem,
                conferences.Select(c => c.ConferenceName).ToList());
            //var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, conferences);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            
            conferenceSpinner.Adapter = adapter;
        }

        private void SetEvents()
        {
            conferenceSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(ConferenceSpinner_ItemSelected);
            teamSpinner.ItemSelected += TeamSpinner_ItemSelected;
        }

        private void TeamSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string teamSelectedItem = spinner.SelectedItem.ToString();

            if (teamSelectedItem != null)
            {
                IEnumerable<Team> selectedTeam =
                    from team in teams
                    where team.TeamName == teamSelectedItem
                    select team;

                CFBDataService cfbDataService = new CFBDataService();
                Team teamSelected = selectedTeam.FirstOrDefault();
                teamSelected = cfbDataService.GetTeamById(teamSelected.TeamId);

                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(String.Format("http://a.espncdn.com/combiner/i?img=/i/teamlogos/ncaa/500/{0}.png&w=100&h=100&transparent=true", teamSelected.TeamLogo));
                teamDetailImageView.SetImageBitmap(imageBitmap);

                teamNickName.Text = teamSelected.TeamNickName;
                teamName.Text = teamSelected.TeamName;
                //var adapter = new ArrayAdapter(this,
                //    Android.Resource.Layout.SimpleSpinnerItem,
                //    teams.Select(t => t.TeamName).ToList());
                //teamSpinner.Adapter = adapter;
            }


        }

        private void ConferenceSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string conf = spinner.SelectedItem.ToString(); //.Cast<Conference>();
            
            if (conf != null)
            {
                IEnumerable<Conference> selectedConf =
                    from conference in conferences
                    where conference.ConferenceName == conf
                    select conference;

                CFBDataService cfbDataService = new CFBDataService();
                Conference confSelected = selectedConf.FirstOrDefault();
                teams = cfbDataService.GetTeamsForConference(confSelected.ConferenceId);

                var adapter = new ArrayAdapter(this, 
                    Android.Resource.Layout.SimpleSpinnerItem, 
                    teams.Select(t => t.TeamName).ToList());
                teamSpinner.Adapter = adapter;
            }            
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