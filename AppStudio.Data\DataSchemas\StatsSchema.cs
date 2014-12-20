using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the StatsSchema class.
    /// </summary>
    public class StatsSchema : BindableSchemaBase, IEquatable<StatsSchema>, ISyncItem<StatsSchema>
    {
        private string _title;
        private string _subtitle;
        private string _imageUrl;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
 
        public string Subtitle
        {
            get { return _subtitle; }
            set { SetProperty(ref _subtitle, value); }
        }
 
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        public override string DefaultTitle
        {
            get { return Title; }
        }

        public override string DefaultSummary
        {
            get { return Subtitle; }
        }

        public override string DefaultImageUrl
        {
            get { return ImageUrl; }
        }

        public override string DefaultContent
        {
            get { return Subtitle; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "title":
                        return String.Format("{0}", Title); 
                    case "subtitle":
                        return String.Format("{0}", Subtitle); 
                    case "imageurl":
                        return String.Format("{0}", ImageUrl); 
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }

        public bool Equals(StatsSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(StatsSchema other)
        {

            return this.Id == other.Id && (this.Title != other.Title || this.Subtitle != other.Subtitle || this.ImageUrl != other.ImageUrl);
        }

        public void Sync(StatsSchema other)
        {
            this.Title = other.Title;
            this.Subtitle = other.Subtitle;
            this.ImageUrl = other.ImageUrl;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StatsSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
