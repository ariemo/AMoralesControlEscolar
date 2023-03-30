using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BL
{
    public class Alumnos
    {
        public static ML.Result Add(ML.Alumnos alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnosAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] parameters = new SqlParameter[3];
                        parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        parameters[0].Value = alumno.Nombre;
                        parameters[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        parameters[1].Value = alumno.ApellidoPaterno;
                        parameters[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        parameters[2].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "AlumnosGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                       
                        DataTable tableAlumnos = new DataTable();

                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                       
                        adapter.Fill(tableAlumnos);

                        if (tableAlumnos.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAlumnos.Rows)
                            {
                                ML.Alumnos alumno = new ML.Alumnos();

                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                

                                result.Objects.Add(alumno);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(ML.Alumnos alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnosGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        SqlParameter[] parameters = new SqlParameter[1];
                        parameters[0] = new SqlParameter("@IdAlumno", System.Data.SqlDbType.Int);
                        parameters[0].Value = alumno.IdAlumno;


                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Open();
                        
                        DataTable tableAlumno = new DataTable();

                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        
                        adapter.Fill(tableAlumno);

                        if (tableAlumno.Rows.Count > 0)
                        {

                            result.Objects = new List<object>();
                            foreach (DataRow row in tableAlumno.Rows)
                            {

                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                

                                result.Objects.Add(alumno);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Delete(ML.Alumnos alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnosDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        SqlParameter[] parameters = new SqlParameter[1];
                        parameters[0] = new SqlParameter("@IdAlumno", System.Data.SqlDbType.Int);
                        parameters[0].Value = alumno.IdAlumno;

                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;

        }
        public static ML.Result Update(ML.Alumnos alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnosUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        SqlParameter[] parameters = new SqlParameter[4];
                        parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        parameters[0].Value = alumno.Nombre;
                        parameters[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        parameters[1].Value = alumno.ApellidoPaterno;
                        parameters[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        parameters[2].Value = alumno.ApellidoMaterno;
                        parameters[3] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        parameters[3].Value =alumno.IdAlumno;
                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }
}
