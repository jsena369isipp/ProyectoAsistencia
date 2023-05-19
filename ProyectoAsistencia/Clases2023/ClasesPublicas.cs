using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsistencia.Clases2023
{
    public static class ClasesPublicas
    {
        internal static List<Cursos> listaCursos = new List<Cursos>();
        public static void leerArchivoCursos()
        {

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

        }
    }
}
