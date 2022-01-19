namespace CadastroWeb.Models{
    public class Usuario{
        public int Id {get; set;}
        public String Nome {get; set;}
        public int data {get; set;}
        public String Genero {get; set;}
        public String Desc {get; set;}
        private static List<Usuario> listagem = new List<Usuario>();
        public static IQueryable<Usuario> Listagem{
            get{
                return listagem.AsQueryable();
            }
        }
        static Usuario(){
            Usuario.listagem.Add( new Usuario{Id = 1, Nome = "The Walking Dead", data = 2011,Genero = "Ação",Desc = "Filme de Zumbi"});
        }
        public static void Salvar(Usuario usuario){
            //var exist = Usuario.listagem.Find(u => u.Id == usuario.Id );
            var exist = Usuario.listagem.Find(u => u.Nome == usuario.Nome );
            if(exist != null){
                exist.Nome = usuario.Nome;
                exist.data = usuario.data;
                exist.Genero = usuario.Genero;
                exist.Desc = usuario.Desc;
            }
            else{
                int maiorId = Usuario.listagem.Max(u=> u.Id);
                usuario.Id = maiorId + 1;
                Usuario.listagem.Add(usuario);
            }
        }
        public static void Excluir(int idUsuario){
            var exist = Usuario.listagem.Find(u => u.Id == idUsuario );
            if(exist != null){
                Usuario.listagem.Remove(exist);
            }
        }
    }
}