using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Place : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string name;
    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    private string description;
    public string Description
    {
        get => description;
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    private string location;
    public string Location
    {
        get => location;
        set
        {
            if (location != value)
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
    }

    private string path;
    public string Path
    {
        get => path;
        set
        {
            if (path != value)
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
        }
    }

    public async Task InitializeAsync(int id)
    {
        await FetchPlaceAsync(id);
        Path = $"https://storage.yandexcloud.net/placephotos/{id}.png";
    }

    private async Task FetchPlaceAsync(int id)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync($"https://functions.yandexcloud.net/d4efabacb9d3f3gupg8i?id={id}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                JsonConvert.PopulateObject(json, this);
            }
            else
            {
                throw new Exception($"Failed to retrieve place with ID {id}: {response.ReasonPhrase}");
            }
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
