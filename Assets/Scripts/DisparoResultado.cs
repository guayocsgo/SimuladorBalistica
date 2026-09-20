using System;
using System.Collections.Generic;

[Serializable]
public class DisparoResultado
{
    public float angulo;
    public float anguloHorizontal;
    public float fuerza;
    public float masaProyectil;
    public bool acierto;
    public float distancia;
    public int objetosAfectados;
    public string fecha;
}

[Serializable]
public class HistorialDisparos
{
    public List<DisparoResultado> disparos = new List<DisparoResultado>();
}