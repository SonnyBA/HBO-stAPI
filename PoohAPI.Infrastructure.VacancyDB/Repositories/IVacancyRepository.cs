﻿using PoohAPI.Infrastructure.VacancyDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoohAPI.Infrastructure.VacancyDB.Repositories
{
    public interface IVacancyRepository
    {
        IEnumerable<DBVacancy> GetListVacancies(string query);
        IEnumerable<DBVacancy> GetListVacancies(string query, Dictionary<string, object> parameters);
        DBVacancy GetVacancy(string query);
        DBVacancy GetVacancy(string query, Dictionary<string, object> parameters);
        void AddFavouriteVacanacy(string query, Dictionary<string, object> parameters);
        void DeleteFavouriteVacanacy(string query, Dictionary<string, object> parameters);
        IEnumerable<DBVacancyId> GetListVacancyIds(string query, Dictionary<string, object> parameters);
        void IncrementTimesSeen(string query, Dictionary<string, object> parameters);
    }
}
