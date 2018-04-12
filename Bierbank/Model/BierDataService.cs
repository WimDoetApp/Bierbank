using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;
using Bierbank.Extensions;

namespace Bierbank.Model
{
    class BierDataService
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        //Biertjes
        public ObservableCollection<Biertjes> GetBiertjes()
        {
            string sql = "Select * from biertjes";

            return db.Query<Biertjes>(sql).ToObservableCollection();
        }

        public ObservableCollection<Biertjes> GetBiertjesInLijst(string bierIds)
        {
            string sql = "Select * from biertjes where id in (" + bierIds +")";

            return db.Query<Biertjes>(sql, new { id = bierIds }).ToObservableCollection();
        }

        public void UpdateBiertje(Biertjes biertje)
        {
            string sql = "Update biertjes set naam = @naam, soort = @soort, percentage = @percentage, brouwerij = @brouwerij, image = @image where id = @id";

            db.Execute(sql, new
            {
                naam = biertje.Naam,
                soort = biertje.Soort,
                percentage = biertje.Percentage,
                brouwerij = biertje.Brouwerij,
                image = biertje.Image,
                biertje.Id
            });
        }

        public void InsertBiertje(Biertjes biertje)
        {
            string sql = "Insert into biertjes (naam, soort, percentage, brouwerij, image) values (@naam, @soort, @percentage, @brouwerij, @image)";

            db.Execute(sql, new
            {
                naam = biertje.Naam,
                soort = biertje.Soort,
                percentage = biertje.Percentage,
                brouwerij = biertje.Brouwerij,
                image = biertje.Image
            });
        }

        public void DeleteBiertje(Biertjes biertje)
        {
            string sql = "Delete biertjes where id = @id";

            db.Execute(sql, new
            { biertje.Id });
        }

        //BierInLijst
        public ObservableCollection<BierInLijst> GetBierInLijstByLijstId(int lijstId)
        {
            string sql = "Select * from bierInLijst where lijstId = @id";

            return db.Query<BierInLijst>(sql, new { id = lijstId }).ToObservableCollection();
        }

        public void InsertBierInLijst(int bierIdInput, int lijstIdInput)
        {
            string sql = "Insert into bierInLijst (bierId, lijstId) values (@bierId, @lijstId)";

            db.Execute(sql, new
            {
                bierId = bierIdInput,
                lijstId = lijstIdInput
            });
        }

        public void DeleteBierInLijst(int bierIdInput, int lijstIdInput)
        {
            string sql = "Delete bierInLijst where bierId = @bierId and lijstId = @lijstId";

            db.Execute(sql, new
            {
                bierId = bierIdInput,
                lijstId = lijstIdInput
            });
        }

        //Lijsten
        public ObservableCollection<Lijsten> GetLijsten()
        {
            string sql = "Select * from lijsten";

            return db.Query<Lijsten>(sql).ToObservableCollection();
        }

        public void UpdateLijsten(Lijsten lijst)
        {
            string sql = "Update lijsten set naam = @naam where id = @id";

            db.Execute(sql, new
            {
                naam = lijst.Naam,
                lijst.Id
            });
        }

        public void InsertLijsten(Lijsten lijst)
        {
            string sql = "Insert into lijsten (naam) values (@naam)";

            db.Execute(sql, new
            {
                naam = lijst.Naam,
            });
        }

        public void DeleteLijsten(Lijsten lijst)
        {
            string sql = "Delete lijsten where id = @id";

            db.Execute(sql, new
            { lijst.Id });
        }

        //Notes
        public ObservableCollection<BierNotes> GetBierNotes()
        {
            string sql = "Select * from bierNotes";

            return db.Query<BierNotes>(sql).ToObservableCollection();
        }

        public ObservableCollection<BierNotes> GetBierNotesBijBier(int bierId)
        {
            string sql = "Select * from bierNotes where bierId = @id";

            return db.Query<BierNotes>(sql, new { id = bierId }).ToObservableCollection();
        }

        public void UpdateBierNotes(BierNotes note)
        {
            string sql = "Update bierNotes set bierId = @bierId, onderwerp = @onderwerp, beschrijving = @beschrijving where id = @id";

            db.Execute(sql, new
            {
                bierId = note.BierId,
                onderwerp = note.Onderwerp,
                beschrijving = note.Beschrijving,
                note.Id
            });
        }

        public void InsertBierNotes(BierNotes note)
        {
            string sql = "Insert into bierNotes (bierId, onderwerp, beschrijving) values (@bierId, @onderwerp, @beschrijving)";

            db.Execute(sql, new
            {
                bierId = note.BierId,
                onderwerp = note.Onderwerp,
                beschrijving = note.Beschrijving
            });
        }

        public void DeleteBierNotes(BierNotes note)
        {
            string sql = "Delete bierNotes where id = @id";

            db.Execute(sql, new
            { note.Id });
        }
    }
}
