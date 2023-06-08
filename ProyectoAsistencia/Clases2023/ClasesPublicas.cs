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
        //xxc
        //PRUEBA
        public static List<Materia> ListaMaterias = new List<Materia>();
        public static void LeerArchivoMateria()
        {
            try
            {
                if (File.Exists("Materias.txt"))
                {
                    ListaMaterias = new List<Materia>();
                    Materia ObjetoMateria;
                    string txtCompleto = File.ReadAllText("Materias.txt");
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
                                ObjetoMateria.CodigoMateria = Convert.ToInt32(val);
                            }
                            else if (cont == 1)
                            {
                                ObjetoMateria.NombreMateria = val;
                            }
                            else if (cont == 2)
                            {
                                ObjetoMateria.IDProfesor = Convert.ToInt32(val);
                            }
                            else if (cont == 3)
                            {
                                ObjetoMateria.CodigoCursos = Convert.ToInt32(val);
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
                                ObjAlumno.CodigoCurso = Convert.ToInt32(val.Trim());
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

        public static List<Cursos> ListaCursos = new List<Cursos>();
        public static void LeerArchivoCursos()
        {
            try
            {
                if (File.Exists("Cursos.txt"))
                {
                    ListaCursos = new List<Cursos>();
                    Cursos objCursos;
                    ListaCursos = new List<Cursos>();

                    string textoCompleto = File.ReadAllText("Cursos.txt");
                    char[] delims = new[] { '\r', '\n' };
                    string[] lineas = textoCompleto.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string fila in lineas)
                    {
                        objCursos = new Cursos();
                        string[] valores = fila.Split(';');
                        int contador = 0;

                        foreach (string valor in valores)
                        {
                            if (contador == 0)
                            {
                                objCursos.Descripcion = Convert.ToString(valor);
                            }
                            else if (contador == 1)
                            {
                                objCursos.Estado = Convert.ToBoolean(valor);
                            }
                            else if (contador == 2)
                            {
                                objCursos.CodigoPreceptor = Convert.ToInt32(valor);
                            }
                            else if (contador == 3)
                            {
                                objCursos.CodigoCursos = Convert.ToInt32(valor);
                            }
                            contador++;
                        }
                        ClasesPublicas.ListaCursos.Add(objCursos);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer: " + ex.Message, "Aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static List<Asistencia> listaAsistencias = new List<Asistencia>();
        internal static List<Asistencia> ListaAsistencias { get => listaAsistencias; set => listaAsistencias = value; }
        public static void LeerArchivoAsistencia()
        {
            try
            {
                if(File.Exists("Asistencias.txt"))
                {
                    Asistencia ObjetoAsistencia;
                    ListaAsistencias = new List<Asistencia>();

                    string textoCompleto = File.ReadAllText("Asistencias.txt");
                    char[] delims = new[] { '\r', '\n' };
                    string[] lineas = textoCompleto.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string fila in lineas)
                    {
                        ObjetoAsistencia = new Asistencia();
                        string[] valores = fila.Split(';');
                        int i = 0;

                        foreach (string val in valores)
                        {
                            if(i == 0)
                            {
                                ObjetoAsistencia.CodigoAsistencia = Convert.ToInt32(val);
                            }
                            else if(i == 1)
                            {
                                ObjetoAsistencia.Fecha = Convert.ToDateTime(val);
                            }
                            else if(i == 2)
                            {
                                ObjetoAsistencia.CodigoCursos = Convert.ToInt32(val);
                            }
                            else if(i == 3)
                            {
                                ObjetoAsistencia.CodigoPreceptor = Convert.ToInt32(val);
                            }
                            else if(i == 4)
                            {
                                ObjetoAsistencia.CodigoMateria = Convert.ToInt32(val);
                            }
                            else if(i == 5)
                            {
                                ObjetoAsistencia.AlumnoAsistencia = Convert.ToBoolean(val);
                            }
                            i++;
                        }
                        ListaAsistencias.Add(ObjetoAsistencia);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static List<Profesores> ListaProfesores = new List<Profesores>();
        public static void LeerArchivoProfesores()
        {
            try
            {
                if (File.Exists("Profesores.txt"))
                {
                    ListaProfesores = new List<Profesores>();
                    Profesores objetoProfe;
                    ListaProfesores = new List<Profesores>();

                    string textoCompleto = File.ReadAllText("Profesores.txt");
                    char[] delims = new[] { '\r', '\n' };
                    string[] lineas = textoCompleto.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string fila in lineas)
                    {
                        objetoProfe = new Profesores();
                        string[] valores = fila.Split(';');
                        int contador = 0;

                        foreach (string val in valores)
                        {

                            if (contador == 0)
                            {//PRIMER VALOR 
                                objetoProfe.NombreProfe = val;
                            }
                            else if (contador == 1)
                            {
                                objetoProfe.IDProfesor = Convert.ToInt32(val);
                            }
                            else if (contador == 2)
                            {
                                objetoProfe.DNI = Convert.ToInt32(val);
                            }
                            else if (contador == 3)
                            {
                                objetoProfe.FechaDeAlta = DateTime.Parse(val);
                            }
                            else if (contador == 4)
                            {
                                objetoProfe.Tel = Convert.ToInt64(val);
                            }
                            else if (contador == 5)
                            {
                                objetoProfe.Correo = val;
                            }
                            else if (contador == 6)
                            {
                                objetoProfe.Domicilio = val;
                            }
                            else if (contador == 7)
                            {
                                objetoProfe.Estado = Convert.ToBoolean(val);
                            }
                            contador++;

                        }
                        ListaProfesores.Add(objetoProfe);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Leer: " + ex.Message, "Aplicación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static List<Preceptor> ListaPreceptor = new List<Preceptor>();
        public static void LeerPreceptor()
        {
            if (File.Exists("Preceptor.txt"))
            {
                ListaPreceptor = new List<Preceptor>();
                Preceptor objetoPreceptor;
                string textoCompleto = File.ReadAllText("Preceptor.txt");
                char[] delims = new[] { '\r', '\n' };
                string[] lineas = textoCompleto.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                foreach (string fila in lineas)
                {
                    objetoPreceptor = new Preceptor();
                    string[] valores = fila.Split(';');
                    int contador = 0;

                    foreach (string val in valores)
                    {
                        if (contador == 0)
                        {//PRIMER VALOR
                            objetoPreceptor.CodigoPreceptor = Convert.ToInt16(val);
                        }
                        else if (contador == 1)
                        {
                            objetoPreceptor.ApellidoNombre = val;
                        }
                        if (contador == 2)
                        {
                            objetoPreceptor.CodigoCursos = Convert.ToInt16(val);
                        }
                        else if (contador == 3)
                        {
                            objetoPreceptor.DNI = Convert.ToInt32(val);
                        }
                        if (contador == 4)
                        {
                            objetoPreceptor.FechaNacimiento = Convert.ToDateTime(val);
                        }
                        else if (contador == 5)
                        {
                            objetoPreceptor.Estado = Convert.ToBoolean(val);
                        }
                        contador = contador + 1;
                    }
                    ListaPreceptor.Add(objetoPreceptor);
                }

            }
        }

    }
}
