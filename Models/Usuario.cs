public class Usuario{
    public int id {get; private set;}
    public string username {get; private set;}
    public string password {get; private set;}
    public string nombre {get; private set;}
    public string apellido {get; private set;}
    public string foto {get; private set;}
    public DateTime ultimoLogin = new DateTime();



    public Usuario(){}
}