using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour
{
    #region vars
    public static GameManager inst;
    public int preguntasCorrectas,preguntasIncorrectas,index=0;
     public List <Pregunta> preguntas,cincoPreguntas;
    public Pregunta preguntaActual;
    public Text preguntaTexto,b1t,b2t,b3t,b4t,respuestasTexto;
    public string input;
    public GameObject panelResultados;
    bool juegoTerminado;
    #endregion
    public void MostrarResultados()
    {
        if (juegoTerminado)
        {
          panelResultados.gameObject.SetActive(true);
           respuestasTexto.text=$@"  
                    Respuestas correctas: {preguntasCorrectas}  


                     Respuestas incorrectas: {preguntasIncorrectas}
           ";
        }

        else 
        {
            panelResultados.gameObject.SetActive(false);
            
        }
    }
    public void GetInput(int buttonID)
    {
        input = GameObject.Find($"r{buttonID}").gameObject.transform.GetComponentInChildren<Text>().text;
        ActualizaPregunta();
    }
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
             DontDestroyOnLoad(gameObject);       
        }
        Comenzar();
    }
    public void Comenzar()
    {  
        preguntasCorrectas = 0; preguntasIncorrectas = 0;
        juegoTerminado = false;
        MostrarResultados();
        index = 0;
       preguntas=   Desordenar(preguntas);
        for (int i = 0; i < 5; i++)
        {
            cincoPreguntas.Add(preguntas[i]);
        }
        preguntaActual = cincoPreguntas[0];
        preguntaTexto.text = cincoPreguntas[index].pregunta;
        b1t.text = cincoPreguntas[index].respuestas[0];
        b2t.text = cincoPreguntas[index].respuestas[1];
        b3t.text = cincoPreguntas[index].respuestas[2];
        b4t.text = cincoPreguntas[index].respuestas[3];
    }
    private List<Pregunta> Desordenar(List<Pregunta> arr)
    {
        List <Pregunta> arrDes = new List<Pregunta>();
        System.Random randNum = new System.Random();
        while (arr.Count > 0)
        {
            int val = randNum.Next(0, arr.Count - 1);
            arrDes.Add(arr[val]);
            arr.RemoveAt(val);
        }
        return arrDes;
    }
    public bool Comprobar()
    {
        index++;
        if (preguntaActual.respuestaCorrecta == input)
        {
            preguntasCorrectas++;
            return true;
        }
        else
        {
            preguntasIncorrectas++;
            return false;
        }
    }
    public void  ActualizaPregunta()
    {
        if (index>=4)
        {
            Comprobar();
            juegoTerminado = true;
               MostrarResultados();
        }
        else
        {
           Comprobar();
            preguntaActual = cincoPreguntas[index];
            preguntaTexto.text = cincoPreguntas[index].pregunta;
            b1t.text = cincoPreguntas[index].respuestas[0];
            b2t.text = cincoPreguntas[index].respuestas[1];
            b3t.text = cincoPreguntas[index].respuestas[2];
            b4t.text = cincoPreguntas[index].respuestas[3];
        }
    }    
}
