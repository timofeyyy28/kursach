﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace App5
{
    public class Recommendation
    {
        private static readonly HttpClient client = new HttpClient();
        private const string FunctionUrl = "https://functions.yandexcloud.net/d4e1ovaoj12no7nbndlb";

        public static async Task<int?> GetNearestNeighborAsync(int userId)
        {
            var requestData = new { user_id = userId };
            string json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(FunctionUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Dictionary<string, int>>(responseContent);

                if (responseData.TryGetValue("most_similar_place_id", out int mostSimilarPlaceId))
                {
                    return mostSimilarPlaceId;
                }
                else if (responseData.TryGetValue("random_place_id", out int randomPlaceId))
                {
                    return randomPlaceId;
                }
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {responseContent}");
            }

            return null;
        }
    }
}
