    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string con = "server=localhost;port=3306;database=cinema;user=root;password=''";
            builder.UseMySQL(con);
        }

        // Tabelas

        public DbSet<Sessao> Sessoes => Set<Sessao>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Ingresso> Ingressos => Set<Ingresso>();
        public DbSet<Bomboniere> Bombonieres => Set<Bomboniere>();
    
    }
    public class Banco{

         //Lista de sessoes
        private static List<Sessao> Sessoes = new List<Sessao>();
        
        public static List<Sessao> getSessoes()
        {
            return Sessoes;
        }

        public static Sessao getSessao(int id)
        {
            return Sessoes.FirstOrDefault(f => f.id == id);
        }

        public static Sessao addSessao(Sessao sessao)
        {
            sessao.id = Sessoes.Count + 1;
            Sessoes.Add(sessao);
            return sessao;
        }

        public static Sessao updateSessao(int id, Sessao sessao)
        {
            var sessaoExistente = Sessoes.FirstOrDefault(f => f.id == id);
            if (sessaoExistente == null)
            {
                return null;
            }

                sessaoExistente.idFilme = sessao.idFilme;
                sessaoExistente.idSala = sessao.idSala;
                sessaoExistente.data = sessao.data;
            return sessaoExistente;
        }

        public static bool deleteSessao(int id)
        {
            var sessaoExistente = Sessoes.FirstOrDefault(f => f.id == id);
            if (sessaoExistente == null)
            {
                return false;
            }

            Sessoes.Remove(sessaoExistente);
            return true;
        }

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
        
         // Lista de ingressos
        private static List<Ingresso> Ingressos = new List<Ingresso>();
        
        public static List<Ingresso> getIngressos()
        {
            return Ingressos;
        }

        public static Ingresso getIngresso(int id)
        {
            return Ingressos.FirstOrDefault(i => i.id == id);
        }

        public static Ingresso addIngresso(Ingresso ingresso)
        {
            ingresso.id = Ingressos.Count + 1;
            Ingressos.Add(ingresso);
            return ingresso;
        }

        public static Ingresso updateIngresso(int id, Ingresso ingresso)
        {
            var ingressoExistente = Ingressos.FirstOrDefault(i => i.id == id);
            if (ingressoExistente == null)
            {
                return null;
            }

            ingressoExistente.idSessao = ingresso.idSessao;
            ingressoExistente.assento = ingresso.assento;
            return ingressoExistente;
        }

        public static bool deleteIngresso(int id)
        {
            var ingressoExistente = Ingressos.FirstOrDefault(i => i.id == id);
            if (ingressoExistente == null)
            {
                return false;
            }

            Ingressos.Remove(ingressoExistente);
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