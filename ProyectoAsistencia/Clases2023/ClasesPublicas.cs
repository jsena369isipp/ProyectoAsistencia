using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoAsistencia.Clases2023
{
    public static class ClasesPublicas
    {
        public static List<Alumno> ListaAlumnos = new List<Alumno>();

        public static void LeerArchivoAlumno()
        {
            try
            {
                if (File.Exists("Alumno.txt"))
                {
                    Alumno ObjAlumno;
                    ListaAlumnos = new List<Alumno>();

                    string textoCompleto = File.ReadAllText("Alumno.txt");
                    char[] delims = new[] { '\r', '\n' };
                    string[] lineas = textoCompleto.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string fila in lineas)
                    {
                        ObjAlumno = new Alumno();
                        string[] valores = fila.Split(';');
                        int contador = 0;

                        foreach (string val in valores)
                        {

                            if (contador == 0)
                            {
                                ObjAlumno.CodigoCurso = Convert.ToInt32(val);
                            }
                            else if (contador == 1)
                            {
                                ObjAlumno.CodigoAlumno = Convert.ToInt32(val);
                            }
                            else if (contador == 2)
                            {
                                ObjAlumno.Dni = Convert.ToInt64(val);
                            }
                            else if (contador == 3)
                            {
                                ObjAlumno.NombreApellido = val;
                            }
                            else if (contador == 4)
                            {
                                ObjAlumno.FechaNacimiento = Convert.ToDateTime(val);
                            }
                            else if (contador == 5)
                            {
                                ObjAlumno.Domicilio = val;
                            }
                            else if (contador == 6)
                            {
                                ObjAlumno.Tel = Convert.ToInt64(val);
                            }
                            else if (contador == 7)
                            {
                                ObjAlumno.CorreoElectronico = val;
                            }
                            else if (contador == 8)
                            {
                                ObjAlumno.Estado = Convert.ToBoolean(val);
                            }
                            else if (contador == 9)
                            {
                                ObjAlumno.FechaIngreso = Convert.ToDateTime(val);
                            }


                            contador = contador + 1;
                        }
                        ClasesPublicas.ListaAlumnos.Add(ObjAlumno);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
