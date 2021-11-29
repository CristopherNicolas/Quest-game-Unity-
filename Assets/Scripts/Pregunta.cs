using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pregunta", menuName = "ScriptableObjects/Preguntas", order = 1)]
public class Pregunta : ScriptableObject
{
    public string pregunta, respuestaCorrecta;
    public List<string> respuestas;
    
}
