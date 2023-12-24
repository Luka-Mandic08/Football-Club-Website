using FootballClubBackend.Model.Enums;
using FootballClubBackend.Model;
using FootballClubBackend.Repository;
using FootballClubBackend.Model.DTO;

namespace FootballClubBackend.Service
{
    public class TableService
    {
        private readonly TableRepository _tableRepository;

        public TableService(TableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public void Create(CreateTable dto)
        {
            _tableRepository.Create(new Table(dto));
        }

        public ICollection<Table> GetAllBySeason(int season)
        {
            if(season == -1)
                season = GetCurrentSeason();
            return _tableRepository.GetAllBySeason(season);
        }

        public void Update(Table table)
        {
            foreach(var row in table.Rows)
            {
                if (row.Id == null)
                    row.Id = Guid.NewGuid();
            }
            _tableRepository.Update(table);
        }

        public void Delete(string id)
        {
            _tableRepository.Delete(Guid.Parse(id));
        }

        public int GetCurrentSeason()
        {
            if (DateTime.Now.Month >= 7)
                return DateTime.Now.Year;
            return DateTime.Now.Year - 1;
        }
    }
}
