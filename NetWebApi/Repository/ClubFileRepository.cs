﻿using Model;
using Model.Entities;
using Newtonsoft.Json;

namespace Repository
{
    public class ClubFileRepository : IClubRepository
    {
        private readonly string _path;

        public ClubFileRepository(string path)
        {
            this._path = path;
        }

        public Task ChangeName(int cludId, string newName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Club>> GetAllAsync()
        {
            StreamReader sr = new StreamReader(Path.Combine(this._path, "Clubs.json"));
            string json = await sr.ReadToEndAsync();
            sr.Close();
            return JsonConvert.DeserializeObject<List<Club>>(json);
        }

        public Task<List<ShortClub>> GetAllShortAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(Club club)
        {
            throw new NotImplementedException();
        }
    }
}