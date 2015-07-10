using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrigamiCore.Data
{
	public class Step
	{
		public string Header { get; set; }
		public string Image { get; set; }
		public string Tutorial { get; set; }
	}
    public class OrigamiItem
    {
        public OrigamiItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content)
        {
			this.UniqueId = uniqueId;
			this.Title = title;
			this.Subtitle = subtitle;
			this.Description = description;
			this.ImagePath = imagePath;
        }

		public string UniqueId { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public List<Step> Steps { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class OrigamiGroup
    {
        public OrigamiGroup(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Items = new ObservableCollection<OrigamiItem>();
        }

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public ObservableCollection<OrigamiItem> Items { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
    public sealed class DataProvider
    {
        public ObservableCollection<OrigamiItem> Items { get; private set; }
        public DataProvider()
        {
            this.Items = new ObservableCollection<OrigamiItem>();
        }
        private static DataProvider _dataprovider = new DataProvider();
        private ObservableCollection<OrigamiGroup> _groups = new ObservableCollection<OrigamiGroup>();
        public ObservableCollection<OrigamiGroup> Groups
        {
            get { return this._groups; }
        }

        public async static Task<IEnumerable<OrigamiGroup>> GetGroupsAsync()
        {
            await _dataprovider.GetDataAsync();
            return _dataprovider.Groups;
        }
        public static async Task<OrigamiGroup> GetGroupAsync(string uniqueId)
        {
            await _dataprovider.GetDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _dataprovider.Groups.Where((group) => group.UniqueId.Equals(uniqueId));
            return matches.First();
        }

        public static async Task<OrigamiItem> GetItemAsync(string uniqueId)
        {
            await _dataprovider.GetDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _dataprovider.Groups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            return matches.First();
        }
        private async Task GetDataAsync()
        {
            if (this._groups.Count != 0)
                return;
            var s = Assembly.Load(new AssemblyName("OrigamiCore")).GetManifestResourceStream(@"OrigamiCore.Data.SampleData.json");
            StreamReader sr = new StreamReader(s);
            string fileContentPortable = sr.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<OrigamiGroup>>(fileContentPortable);
            foreach (var gr in list)
                this.Groups.Add(gr);
        }
    }
}


