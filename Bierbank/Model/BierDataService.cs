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
        public List<BierInLijst> GetBierInLijst()
        {
            string sql = "Select * from bierInLijst";

            return (List<BierInLijst>)db.Query<BierInLijst>(sql);
        }

        public void InsertBierInLijst(BierInLijst bierInLijst)
        {
            string sql = "Insert into bierInLijst (bierId, lijstId) values (@bierId, @lijstId)";

            db.Execute(sql, new
            {
                bierId = bierInLijst.BierId,
                lijstId = bierInLijst.LijstId
            });
        }

        public void DeleteBierInLijst(BierInLijst bierInLijst)
        {
            string sql = "Delete bierInLijst where id = @id";

            db.Execute(sql, new
            { bierInLijst.Id });
        }

        //Lijsten
        public List<Lijsten> GetLijsten()
        {
            string sql = "Select * from lijsten";

            return (List<Lijsten>)db.Query<Lijsten>(sql);
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
        public List<BierNotes> GetBierNotes()
        {
            string sql = "Select * from bierNotes";

            return (List<BierNotes>)db.Query<BierNotes>(sql);
        }

        public void UpdateBierNotes(BierNotes note)
        {
            string sql = "Update bierNotes set bierId = @bierId, onderwerp = @onderwerp, beschrijving = @beschrijving where id = @id";

            db.Execute(sql, new
            {
                naam = note.BierId,
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
                naam = note.BierId,
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
