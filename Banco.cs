    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string con = "server=localhost;port=3306;database=cinema;user=root;password=''";
            builder.UseMySQL(con);
        }

        // Tabelas
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        public DbSet<Bomboniere> Bombonieres => Set<Bomboniere>();
    
    }
    public class Banco{

        // Lista de usuários
        private static List<Usuario> Usuarios = new List<Usuario>();
        
        public static List<Usuario> getUsuarios()
        {
            return Usuarios;
        }

        public static Usuario getUsuario(int id)
        {
            return Usuarios.FirstOrDefault(u => u.id == id);
        }

        public static Usuario addUsuario(Usuario usuario)
        {
            usuario.id = Usuarios.Count + 1;
            Usuarios.Add(usuario);
            return usuario;
        }

        public static Usuario updateUsuario(int id, Usuario usuario)
        {
            var usuarioExistente = Usuarios.FirstOrDefault(u => u.id == id);
            if (usuarioExistente == null)
            {
                return null;
            }

            usuarioExistente.nome = usuario.nome;
            usuarioExistente.senha = usuario.senha;
            usuarioExistente.perfil = usuario.perfil;
            return usuarioExistente;
        }

        public static bool deleteUsuario(int id)
        {
            var usuarioExistente = Usuarios.FirstOrDefault(u => u.id == id);
            if (usuarioExistente == null)
            {
                return false;
            }

            Usuarios.Remove(usuarioExistente);
            return true;
        }

         // Lista de bombonieres
        private static List<Bomboniere> Bombonieres = new List<Bomboniere>();

        public static List<Bomboniere> getBombonieres()
        {
            return Bombonieres;
        }

        public static Bomboniere getBomboniere(int id)
        {
            return Bombonieres.FirstOrDefault(b => b.id == id);
        }

        public static Bomboniere addBomboniere(Bomboniere bomboniere)
        {
            bomboniere.id = Bombonieres.Count + 1;
            Bombonieres.Add(bomboniere);
            return bomboniere;
        }

        public static Bomboniere updateBomboniere(int id, Bomboniere bomboniere)
        {
            var bomboniereExistente = Bombonieres.FirstOrDefault(b => b.id == id);
            if (bomboniereExistente == null)
            {
                return null;
            }

            bomboniereExistente.produto = bomboniere.produto;
            bomboniereExistente.valor = bomboniere.valor;
            return bomboniereExistente;
        }

        public static bool deleteBomboniere(int id)
        {
            var bomboniereExistente = Bombonieres.FirstOrDefault(b => b.id == id);
            if (bomboniereExistente == null)
            {
                return false;
            }

            Bombonieres.Remove(bomboniereExistente);
            return true;
        }

    }