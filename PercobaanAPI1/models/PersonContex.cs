using PercobaanApi1.Helpers;
using Npgsql;

namespace PercobaanApi1.Models
{
    public class PersonContext
    {
        private string __constr;
        public string __ErrorMsg;

        public PersonContext(string pConstr)
        {
            __constr = pConstr;
        }
        public List<Murid> ListPerson()
        {
            List<Murid> list1 = new List<Murid>();
            string query = string.Format(@"SELECT id_murid, nama, alamat, email FROM person");

            sqlDBHelper db = new sqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Murid()
                    {
                        id_murid = int.Parse(reader["id_murid"].ToString()),
                        nama = reader["nama"].ToString(),
                        alamat = reader["alamat"].ToString(),
                        email = reader["email"].ToString()
                    });
                }
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
            return list1;
        }

        public void AddMurid(Murid person)
        {
            string query = string.Format("INSERT INTO person (nama, alamat, email) VALUES (@nama, @alamat, @email)");

            sqlDBHelper db = new sqlDBHelper(this.__constr);

            try
            {
                using (NpgsqlCommand cmd = db.GetNpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@nama", person.nama);
                    cmd.Parameters.AddWithValue("@alamat", person.alamat);
                    cmd.Parameters.AddWithValue("@email", person.email);

                    cmd.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        public void UpdateMurid(int id_murid, Murid person)
        {

            string query = string.Format(@"UPDATE person SET nama = @nama, alamat = @alamat, email = @email WHERE id_murid = @id_murid");
            sqlDBHelper db = new sqlDBHelper(this.__constr);



            using (NpgsqlCommand cmd = db.GetNpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@id_murid", person.id_murid);
                cmd.Parameters.AddWithValue("@nama", person.nama);
                cmd.Parameters.AddWithValue("@alamat", person.alamat);
                cmd.Parameters.AddWithValue("@email", person.email);

                cmd.ExecuteNonQuery();
            }

        }


        public void DeleteMurid(int id_murid)
        {

            string query = string.Format(@"DELETE FROM person WHERE id_murid = @id_murid");
            sqlDBHelper db = new sqlDBHelper(this.__constr);



            using (NpgsqlCommand cmd = db.GetNpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@id_murid", id_murid);
                cmd.ExecuteNonQuery();
            }

        }



    }
}
