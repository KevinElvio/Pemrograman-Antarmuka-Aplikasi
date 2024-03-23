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
        public List<Person> ListPerson()
        {
            List<Person> list1 = new List<Person>();
            string query = string.Format(@"SELECT id_person, nama, alamat, email FROM person");

            sqlDBHelper db = new sqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Person()
                    {
                        id_person = int.Parse(reader["id_person"].ToString()),
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

        public void AddPerson(Person person)
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

        public void UpdatePerson(int id_person, Person person)
        {

            string query = string.Format(@"UPDATE person SET nama = @nama, alamat = @alamat, email = @email WHERE id_person = @id_person");
            sqlDBHelper db = new sqlDBHelper(this.__constr);



            using (NpgsqlCommand cmd = db.GetNpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@id_person", person.id_person);
                cmd.Parameters.AddWithValue("@nama", person.nama);
                cmd.Parameters.AddWithValue("@alamat", person.alamat);
                cmd.Parameters.AddWithValue("@email", person.email);

                cmd.ExecuteNonQuery();
            }

        }


        public void DeletePerson(int id_person)
        {

            string query = string.Format(@"DELETE FROM person WHERE id_person = @id_person");
            sqlDBHelper db = new sqlDBHelper(this.__constr);



            using (NpgsqlCommand cmd = db.GetNpgsqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@id_person", id_person);
                cmd.ExecuteNonQuery();
            }

        }



    }
}
