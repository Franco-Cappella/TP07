public class Tarea
{
    public int id;
    public int idU;
    public string titulo;
    public string descripcion;
    public DateTime fecha = new DateTime();
    public bool finalizada;
    public List<Tarea> Papelera = new List<Tarea>();

    public Tarea() { }
    public Tarea(int pIdU, string pTitulo, string pDescripcion, DateTime pFecha)
    {
        idU = pIdU;
        titulo = pTitulo;
        descripcion = pDescripcion;
        fecha = pFecha;
    }
}