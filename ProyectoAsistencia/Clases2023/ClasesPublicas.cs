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
        //XX
        //PRUEBA
        public static List<Materia> ListaMaterias = new List<Materia>();
        public static void LeerArchivoMateria()
        {
            try
            {
                if (File.Exists("Materias.txt"))
                {
                    Materia ObjetoMateria;
                    string txtCompleto = File.ReadAllText("Materia.txt");
                    char[] delims = new[] { '\n' };
                    string[] lineas = txtCompleto.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string fila in lineas)
                    {
                        ObjetoMateria = new Materia();
                        string[] valores = fila.Split(';');
                        int cont = 0;

                        foreach (string val in valores)
                        {
                            if (cont == 0)
                            {
                                ObjetoMateria.IdMateria = Convert.ToInt32(val);
                            }
                            else if (cont == 1)
                            {
                                ObjetoMateria.NombreMateria = val;
                            }
                            else if (cont == 2)
                            {
                                ObjetoMateria.IdProfesor = Convert.ToInt32(val);
                            }
                            else if (cont == 3)
                            {
                                ObjetoMateria.IdCurso = Convert.ToInt32(val);
                            }
                            else if (cont == 4)
                            {
                                ObjetoMateria.HsCatedra = Convert.ToInt32(val);
                            }
                            cont += 1;
                        }
                        ListaMaterias.Add(ObjetoMateria);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al leer: " + err.Message, "Apliación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

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
