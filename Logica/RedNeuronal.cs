using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Logica
{
    public class RedNeuronal
    {
        public string Nombre { get; set; }
        public int M { get; set; }
        public int N { get; set; }
        public int Patrones { get; set; }
        public int NumeroIteraciones { get; set; }
        public float RataAprendizaje { get; set; }
        public float ErrorMaximo { get; set; }
        public float[,] X { get; set; }
        public float[,] Yd { get; set; }
        public float[] U  { get; set; }
        public float[,] W { get; set; }
        public float[,] WAnt { get; set; }

        public string FuncionActivacion { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public IEntrenamiento FormEntrenamiento { get; set; }

        public RedNeuronal(string nombre, int m, int n, int patrones, int numeroIteraciones, float rataAprendizaje, float errorMaximo, float[,] x, float[,] yd, float[,] w, float[,] wAnt, string funcionActivacion, IEntrenamiento formEntrenamiento)
        {
            Nombre = nombre;
            M = m;
            N = n;
            Patrones = patrones;
            NumeroIteraciones = numeroIteraciones;
            RataAprendizaje = rataAprendizaje;
            ErrorMaximo = errorMaximo;
            X = x;
            Yd = yd;
            W = w;
            WAnt = wAnt;
            FuncionActivacion = funcionActivacion;
            FormEntrenamiento = formEntrenamiento;
        }

        public RedNeuronal()
        {
        }

        public int Entrenar()
        {

            float sumaEl = 0;
            float sumaEp = 0;


            float[] El = new float[N];
            float[] Y = new float[N];
            float[] Ep = new float[Patrones];
            float erms;
            float[] soma = new float[N];
            //U = new float[n];

            List<float> listaErrores = new List<float>();
            List<float> listaErrorMaestro = new List<float>();

            float[,] listaPeso = new float[M, N];
            float[] listaumbrales = new float[N];


            for (int e = 1; e <= NumeroIteraciones; e++)
            {

                for (int p = 0; p < Patrones; p++)
                {

                    for (int i = 0; i < N; i++)
                    {
                        soma[i] = 0;
                        El[i] = 0;
                        for (int j = 0; j < M; j++)
                        {
                            soma[i] = soma[i]  + X[p, j] *W[j, i];

                        }//ciclo de salidas

                        soma[i] = soma[i] + U[i];
                        Y[i] = Activacion(soma[i]);
                        El[i] = Yd[p, i] - Y[i];
                        Console.WriteLine(string.Format("el[{0}]={1} - {2} ", i, Yd[p, i], Y[i]));
                        Console.WriteLine(string.Format("el[{0}]:{1} ", i, El[i]));
                        sumaEl = sumaEl + Math.Abs(El[i]);
                    }//ciclo entradas

                    //actualizacion de pesos y umbrales
                    for (int i = 0; i < N; i++)
                    {
                        U[i] = U[i] + RataAprendizaje * El[i];
                        //listaumbrales[i] = U[i];
                        for (int j = 0; j < M; j++)
                        {
                            W[j, i] = W[j, i] + RataAprendizaje * El[i] * X[p, j];
                            listaPeso[j, i] = W[j, i];
                        }
                    }

                    Console.WriteLine("Suma El " + sumaEl);
                    Ep[p] = sumaEl / Patrones;
                    sumaEl = 0;
                    sumaEp = sumaEp + Ep[p];
                    Console.WriteLine(string.Format("Ep[{0}]: {1} ", p, Ep[p]));

                }//ciclo recorrido de patrones

                Console.WriteLine("Suma Ep " + sumaEp);
                erms = sumaEp / Patrones;
                sumaEp = 0;
                Console.WriteLine("iteraciones " + e);
                Console.WriteLine("ERMS " + erms);

                listaErrores.Add(erms);
                listaErrorMaestro.Add(ErrorMaximo);
                //Thread.Sleep(1000);

                FormEntrenamiento.graficarErrorIteracion(listaErrores, listaErrorMaestro);
                FormEntrenamiento.mostrarErrrorIteracion(e, erms);
                FormEntrenamiento.actualizarProgreso(e);

                if (erms <= ErrorMaximo)
                {
                    FormEntrenamiento.actualizarProgreso(NumeroIteraciones);
                    FormEntrenamiento.finalizarEntrenamiento(true);
                    guardar();
                    Console.WriteLine("iteraciones " + e);
                    return 1;
                }
                //Console.WriteLine(" ERROR ERMS "+sumaEp+"  "+e+" iteraciones");
                Console.WriteLine("\n");
            }
            FormEntrenamiento.finalizarEntrenamiento(false);
            return 0;
        }

        public void InicializacionPesos(int m, int n)
        {
            U = new float[n];
            W = new float[m, n];
            WAnt = new float[m, n];
            var random = new Random(-1);
            for (int i = 0; i < n; i++)
            {
                U[i] = (float)random.NextDouble();
                Console.WriteLine(string.Format("U[{0}] = {1} %n", i, U[i]));
                Console.WriteLine("");
                for (int j = 0; j < m; j++)
                {
                    W[j, i] = (float)random.Next(-1, 1);
                    WAnt[j, i] = (float)random.Next(-1, 1);
                }
            }

            Console.WriteLine("Umbrales");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Format("U[{0}] = {1} \t", i, U[i]));
            }

            Console.WriteLine("Pesos");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine(string.Format("W[{0},{1}] = {2} \t", j, i, W[j, i]));
                }
                Console.WriteLine("");
            }

            MessageBox.Show(null, "Good  !! Pesos inicializados de manera correcta", "Inicializacion de pesos");
        }

        private void guardar()
        {
            IEntrenamiento entrenamiento = this.FormEntrenamiento;
            RedNeuronal perceptronSimple = this;
            perceptronSimple.FormEntrenamiento = null;

            string json = JsonConvert.SerializeObject(perceptronSimple);
            //obtenemos la carpeta y ejecutable de nuestra aplicación 
            string rutaFichero = Environment.GetCommandLineArgs()[0];
            //obtenemos sólo la carpeta (quitamos el ejecutable) 
            string carpeta = Path.GetDirectoryName(rutaFichero);
            //Montamos la carpeta y el fichero temporal con el 
            //primer parámetro que es el código de solicitud 
            rutaFichero = Path.Combine(carpeta, Nombre + ".json");
            try
            {
                //si no existe la carpeta temporal la creamos 
                if (!(Directory.Exists(carpeta)))
                {
                    Directory.CreateDirectory(carpeta);
                }

                if (Directory.Exists(carpeta))
                {
                    //Creamos el fichero temporal y 
                    //añadimos el texto pasado como parámetro 
                    System.IO.StreamWriter ficheroTemporal =
                        new System.IO.StreamWriter(rutaFichero);
                    ficheroTemporal.WriteLine(json);
                    ficheroTemporal.Close();
                }
            }
            catch (Exception errorC)
            {

            }
            this.FormEntrenamiento = entrenamiento;
        }



        private float Activacion(float soma)
        {
            float respuesta = 0;
            switch (this.FuncionActivacion)
            {
                case "escalon":
                    {

                        if (soma > 0)
                        {
                            respuesta = 1;
                        }
                        else
                        {
                            respuesta = 0;
                        };
                        Console.WriteLine(string.Format("Funcion de Activacion escalon soma = {0} => salida: {1}", soma, respuesta));

                        break;
                    }
                case "rampa":
                    {
                        if (soma < 0)
                        {
                            respuesta = 0;
                        }
                        else if (soma >= 0 && soma <= 1)
                        {
                            respuesta = soma;
                        }
                        else if (soma > 1)
                        {
                            respuesta = 1;
                        }

                        Console.WriteLine(string.Format("Funcion de Activacion rampa soma = {0} => salida: {1}", soma, respuesta));


                        break;
                    }
            }
            return respuesta;

        }

    }
}
